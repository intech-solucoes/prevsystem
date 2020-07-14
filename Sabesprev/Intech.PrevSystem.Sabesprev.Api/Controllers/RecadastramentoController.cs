﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Transactions;
using Intech.Lib.Email;
using Intech.Lib.SMS;
using Intech.Lib.Util.Validacoes;
using Intech.Lib.Web;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecadastramentoController : BaseController
    {
        /*
            Normalmente, um metodo com escolha (enviar pelo email ou pelo celular?) usaria um boolean para essa escolha.
            Infelizmente, booleans tem apenas 2 estados e consequentemente abranje somente duas escolhas.
            Caso venha a ser implementado novos metodos de envio (push notification por exemplo) tera que ser implementados mais booleans
            para abranjer todas as possibilidades...
            Com isso em mente, foi utilizado um mapa de metodos de envio.
        */
        [HttpGet("[action]/{metodoEnvio}/{alvoEnvio}/{cpf}")]
        public IActionResult GerarToken(string metodoEnvio, string alvoEnvio, string cpf = "")
        {
            try
            {
                var token = Math.Truncate(new Random(DateTime.Now.Millisecond).NextDouble() * 1000000).ToString();

                if (metodoEnvio == "email")
                {
                    EnviarTokenEmail(token, alvoEnvio);
                }
                else if (metodoEnvio == "sms")
                {
                    EnviarTokenCelular(token, alvoEnvio, cpf);
                }
                else
                {
                    return BadRequest("Método de envio do Token não informado.");
                }

                return Json(new
                {
                    Mensagem = "Token enviado.",
                    Token = token.ToString()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    text = ex.Message,
                    line = ex.ToString()
                });
            }
        }

        [HttpPost("[action]")]
        public IActionResult Upload([FromForm] FileUploadViewModel Arquivo)
        {
            try
            {
                var file = Arquivo.File;
                decimal oid = 0;

                if (!Directory.Exists("Upload"))
                    Directory.CreateDirectory("Upload");

                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var extension = fileName.Split(".").Last()?.ToUpper();
                    if (extension != "TIF" && extension != "JPG" && extension != "BMP" && extension != "PNG" && extension != "PDF") {
                        // TIF, JPG, BMP, PNG e PDF
                        return BadRequest("Arquivo inválido. Por favor utilizar arquivos das seguintes extensões: TIF, JPG, BMP, PNG e PDF.");
                    }
                    string fullPath = Path.Combine("Upload", fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var f = new ArquivoUploadEntidade();
                    f.DTA_UPLOAD = DateTime.Now;
                    f.IND_STATUS = 2;
                    f.NOM_ARQUIVO_LOCAL = fileName;
                    f.NOM_ARQUIVO_ORIGINAL = Guid.NewGuid().ToString();
                    f.NOM_DIRETORIO_LOCAL = "Upload";
                    //oid = new ArquivoUploadProxy().Inserir(f);
                    new ArquivoUploadProxy().Insert(f.DTA_UPLOAD, f.IND_STATUS, f.NOM_ARQUIVO_LOCAL, f.NOM_ARQUIVO_ORIGINAL, f.NOM_DIRETORIO_LOCAL);
                    var a = new ArquivoUploadProxy().BuscarPorNome(f.NOM_ARQUIVO_ORIGINAL).LastOrDefault();
                    oid = a != null ? a.OID_ARQUIVO_UPLOAD : 0;
                }


                return Json(oid);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult Concluir([FromBody] WebRecadDadosConclusaoEntidade Dados)
        {
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var dataAtual = DateTime.Now;

                    var recad = new WebRecadPublicoAlvoProxy().BuscarPorCpfDataAtual(Dados.CPF_Original.LimparMascara(), dataAtual).FirstOrDefault();
                    recad.IND_SITUACAO_RECAD = "SOL";
                    recad.NOM_USUARIO_ACAO = Dados.Participante.NOME_ENTID;

                    var atualizar = new WebRecadPublicoAlvoProxy().AtualizarUsuarioAcao(recad.OID_RECAD_PUBLICO_ALVO, recad.IND_SITUACAO_RECAD, recad.NOM_USUARIO_ACAO);
                    //new WebRecadPublicoAlvoProxy().Atualizar(recad);

                    var refEspecieINSS = new EspecieINSSProxy().BuscarPorCdEspecieINSS(Dados.Participante.CD_ESPECIE_INSS);

                    var especieINSS = refEspecieINSS != null ? refEspecieINSS.DS_ESPECIE_INSS : null;

                    var pais = new PaisProxy().BuscarPorCdPais(Dados.Participante.CD_PAIS).DS_PAIS;

                    var ufEndereco = new UFProxy().BuscarPorCdUF(Dados.Participante.UF_ENTID).DS_UNID_FED;

                    var ufNaturalidade = new UFProxy().BuscarPorCdUF(Dados.Participante.UF_NATURALIDADE).DS_UNID_FED;

                    var estadoCivil = new EstadoCivilProxy().BuscarPorCodigo(Dados.Participante.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;

                    var dadosAntigos = new WebRecadPublicoAlvoProxy().BuscarDadosPorCdFundacaoSeqRecebedor(recad.CD_FUNDACAO, recad.SEQ_RECEBEDOR).FirstOrDefault();

                    if ((dadosAntigos.CPF_CONJUGE == null && dadosAntigos.NOME_CONJUGE == null) || (dadosAntigos.CPF_CONJUGE == "" && dadosAntigos.NOME_CONJUGE == ""))
                    {
                        var conjuge = new DependenteProxy().BuscarPorFundacaoInscricaoCdGrauParentescoPlanoPrevidencialFixo(dadosAntigos.CD_FUNDACAO, dadosAntigos.NUM_INSCRICAO, 2);
                        if (conjuge.Count > 0)
                        {
                            dadosAntigos.CPF_CONJUGE = conjuge.First().CPF;
                            dadosAntigos.NOME_CONJUGE = conjuge.First().NOME_DEP;
                        }
                    }

                    var dadosInsert = new WebRecadDadosEntidade();
                    dadosInsert.OID_RECAD_PUBLICO_ALVO = recad.OID_RECAD_PUBLICO_ALVO;
                    dadosInsert.DTA_SOLICITACAO = dataAtual;
                    dadosInsert.DES_ORIGEM = "PORTAL SABESPREV";
                    dadosInsert.COD_PROTOCOLO = dataAtual.ToString("yyyyMMddHHmmss") + recad.SEQ_RECEBEDOR;
                    dadosInsert.DTA_RECUSA = null;
                    dadosInsert.TXT_MOTIVO_RECUSA = null;
                    dadosInsert.NOM_PESSOA = Dados.Participante.NOME_ENTID?.ToUpper() != dadosAntigos.NOME_ENTID?.ToUpper() ? Dados.Participante.NOME_ENTID?.ToUpper() : null;
                    dadosInsert.DTA_NASCIMENTO = Dados.Participante.DT_NASCIMENTO != dadosAntigos.DT_NASCIMENTO ? DateTime.ParseExact(Dados.Participante.DT_NASCIMENTO, "MM/dd/yyyy", null) : (DateTime?)null;
                    dadosInsert.COD_CPF = Dados.Participante.CPF_CGC.LimparMascara() != dadosAntigos.CPF_CGC.LimparMascara() ? Dados.Participante.CPF_CGC.LimparMascara() : null;
                    dadosInsert.COD_RG = Dados.Participante.NU_IDENT != dadosAntigos.NU_IDENT ? Dados.Participante.NU_IDENT : null;
                    dadosInsert.DES_ORGAO_EXPEDIDOR = Dados.Participante.ORG_EMIS_IDENT?.ToUpper() != dadosAntigos.ORG_EMIS_IDENT?.ToUpper() ? Dados.Participante.ORG_EMIS_IDENT?.ToUpper() : null;
                    dadosInsert.DTA_EXPEDICAO_RG = Dados.Participante.DT_EMIS_IDENT != dadosAntigos.DT_EMIS_IDENT ? DateTime.ParseExact(Dados.Participante.DT_EMIS_IDENT, "MM/dd/yyyy", null) : (DateTime?)null;
                    dadosInsert.DTA_ADMISSAO = null;
                    dadosInsert.DES_NATURALIDADE = Dados.Participante.NATURALIDADE?.ToUpper() != dadosAntigos.NATURALIDADE?.ToUpper() ? Dados.Participante.NATURALIDADE?.ToUpper() : null;
                    dadosInsert.COD_UF_NATURALIDADE = Dados.Participante.UF_NATURALIDADE != dadosAntigos.UF_NATURALIDADE ? Dados.Participante.UF_NATURALIDADE : null;
                    dadosInsert.DES_UF_NATURALIDADE = ufNaturalidade;
                    dadosInsert.COD_NACIONALIDADE = null;
                    dadosInsert.DES_NACIONALIDADE = null;
                    dadosInsert.NOM_MAE = Dados.Participante.NOME_MAE?.ToUpper() != dadosAntigos.NOME_MAE?.ToUpper() ? Dados.Participante.NOME_MAE?.ToUpper() : null;
                    dadosInsert.NOM_PAI = Dados.Participante.NOME_PAI?.ToUpper() != dadosAntigos.NOME_PAI?.ToUpper() ? Dados.Participante.NOME_PAI?.ToUpper() : null;
                    dadosInsert.COD_ESTADO_CIVIL = Dados.Participante.CD_ESTADO_CIVIL != dadosAntigos.CD_ESTADO_CIVIL ? Dados.Participante.CD_ESTADO_CIVIL : null;
                    dadosInsert.DES_ESTADO_CIVIL = estadoCivil;
                    dadosInsert.NOM_CONJUGE = Dados.Participante.NOME_CONJUGE?.ToUpper() != dadosAntigos.NOME_CONJUGE?.ToUpper() ? Dados.Participante.NOME_CONJUGE?.ToUpper() : null;
                    dadosInsert.COD_CPF_CONJUGE = Dados.Participante.CPF_CONJUGE.LimparMascara() != dadosAntigos.CPF_CONJUGE.LimparMascara() ? Dados.Participante.CPF_CONJUGE.LimparMascara() : null;
                    dadosInsert.DTA_NASC_CONJUGE = null;
                    dadosInsert.COD_CEP = Dados.Participante.CEP_ENTID.LimparMascara() != dadosAntigos.CEP_ENTID.LimparMascara() ? Dados.Participante.CEP_ENTID.LimparMascara() : null;
                    dadosInsert.DES_END_LOGRADOURO = Dados.Participante.END_ENTID?.ToUpper() != dadosAntigos.END_ENTID?.ToUpper() ? Dados.Participante.END_ENTID?.ToUpper() : null;
                    dadosInsert.DES_END_NUMERO = Dados.Participante.NR_END_ENTID?.ToUpper() != dadosAntigos.NR_END_ENTID?.ToUpper() ? Dados.Participante.NR_END_ENTID?.ToUpper() : null;
                    dadosInsert.DES_END_COMPLEMENTO = Dados.Participante.COMP_END_ENTID?.ToUpper() != dadosAntigos.COMP_END_ENTID?.ToUpper() ? Dados.Participante.COMP_END_ENTID?.ToUpper() : null;
                    dadosInsert.DES_END_BAIRRO = Dados.Participante.BAIRRO_ENTID?.ToUpper() != dadosAntigos.BAIRRO_ENTID?.ToUpper() ? Dados.Participante.BAIRRO_ENTID?.ToUpper() : null;
                    dadosInsert.DES_END_CIDADE = Dados.Participante.CID_ENTID?.ToUpper() != dadosAntigos.CID_ENTID?.ToUpper() ? Dados.Participante.CID_ENTID?.ToUpper() : null;
                    dadosInsert.COD_END_UF = Dados.Participante.UF_ENTID != dadosAntigos.UF_ENTID ? Dados.Participante.UF_ENTID : null;
                    dadosInsert.DES_END_UF = ufEndereco;
                    dadosInsert.COD_PAIS = Dados.Participante.CD_PAIS != dadosAntigos.CD_PAIS ? Dados.Participante.CD_PAIS : null;
                    dadosInsert.DES_PAIS = pais;
                    dadosInsert.COD_EMAIL = Dados.Participante.EMAIL_AUX != dadosAntigos.EMAIL_AUX ? Dados.Participante.EMAIL_AUX : null;
                    dadosInsert.COD_TELEFONE_FIXO = Dados.Participante.FONE_ENTID != dadosAntigos.FONE_ENTID ? Dados.Participante.FONE_ENTID : null;
                    dadosInsert.COD_TELEFONE_CELULAR = Dados.Participante.FONE_CELULAR != dadosAntigos.FONE_CELULAR ? Dados.Participante.FONE_CELULAR : null;
                    dadosInsert.COD_CARGO = null;
                    dadosInsert.DES_CARGO = null;
                    dadosInsert.COD_SEXO = null;
                    dadosInsert.DES_SEXO = null;
                    dadosInsert.COD_BANCO = Dados.Participante.NUM_BANCO != dadosAntigos.NUM_BANCO ? Dados.Participante.NUM_BANCO : null;
                    dadosInsert.DES_BANCO = null;
                    dadosInsert.COD_AGENCIA = Dados.Participante.NUM_AGENCIA != dadosAntigos.NUM_AGENCIA ? Dados.Participante.NUM_AGENCIA : null;
                    dadosInsert.COD_DV_AGENCIA = null;
                    dadosInsert.COD_CONTA_CORRENTE = Dados.Participante.NUM_CONTA != dadosAntigos.NUM_CONTA ? Dados.Participante.NUM_CONTA : null;
                    dadosInsert.COD_DV_CONTA_CORRENTE = null;
                    dadosInsert.COD_ESPECIE_INSS = Dados.Participante.CD_ESPECIE_INSS != dadosAntigos.CD_ESPECIE_INSS ? Dados.Participante.CD_ESPECIE_INSS : null;
                    dadosInsert.DES_ESPECIE_INSS = especieINSS;
                    dadosInsert.COD_BENEF_INSS = Dados.Participante.NUM_PROCESSO_PREV != dadosAntigos.NUM_PROCESSO_PREV ? Dados.Participante.NUM_PROCESSO_PREV : null;
                    dadosInsert.IND_PPE = Dados.Participante.POLIT_EXP != dadosAntigos.POLIT_EXP ? Dados.Participante.POLIT_EXP : null;
                    dadosInsert.IND_PPE_FAMILIAR = null;
                    dadosInsert.IND_FATCA = null;

                    new WebRecadDadosProxy().Insert(
                        dadosInsert.OID_RECAD_PUBLICO_ALVO,
    dadosInsert.DTA_SOLICITACAO,
    dadosInsert.DES_ORIGEM,
    dadosInsert.COD_PROTOCOLO,
    dadosInsert.DTA_RECUSA ?? DateTime.Now,
    dadosInsert.TXT_MOTIVO_RECUSA,
    dadosInsert.NOM_PESSOA,
    dadosInsert.DTA_NASCIMENTO ?? DateTime.Now,
    dadosInsert.COD_CPF,
    dadosInsert.COD_RG,
    dadosInsert.DES_ORGAO_EXPEDIDOR,
    dadosInsert.DTA_EXPEDICAO_RG ?? DateTime.Now,
    dadosInsert.DTA_ADMISSAO ?? DateTime.Now,
    dadosInsert.DES_NATURALIDADE,
    dadosInsert.COD_UF_NATURALIDADE,
    dadosInsert.DES_UF_NATURALIDADE,
    dadosInsert.COD_NACIONALIDADE,
    dadosInsert.DES_NACIONALIDADE,
    dadosInsert.NOM_MAE,
    dadosInsert.NOM_PAI,
    dadosInsert.COD_ESTADO_CIVIL,
    dadosInsert.DES_ESTADO_CIVIL,
    dadosInsert.NOM_CONJUGE,
    dadosInsert.COD_CPF_CONJUGE,
    dadosInsert.DTA_NASC_CONJUGE ?? DateTime.Now,
    dadosInsert.COD_CEP,
    dadosInsert.DES_END_LOGRADOURO,
    dadosInsert.DES_END_NUMERO,
    dadosInsert.DES_END_COMPLEMENTO,
    dadosInsert.DES_END_BAIRRO,
    dadosInsert.DES_END_CIDADE,
    dadosInsert.COD_END_UF,
    dadosInsert.DES_END_UF,
    dadosInsert.COD_PAIS,
    dadosInsert.DES_PAIS,
    dadosInsert.COD_EMAIL,
    dadosInsert.COD_TELEFONE_FIXO,
    dadosInsert.COD_TELEFONE_CELULAR,
    dadosInsert.COD_CARGO,
    dadosInsert.DES_CARGO,
    dadosInsert.COD_SEXO,
    dadosInsert.DES_SEXO,
    dadosInsert.COD_BANCO,
    dadosInsert.DES_BANCO,
    dadosInsert.COD_AGENCIA,
    dadosInsert.COD_DV_AGENCIA,
    dadosInsert.COD_CONTA_CORRENTE,
    dadosInsert.COD_DV_CONTA_CORRENTE,
    dadosInsert.COD_ESPECIE_INSS,
    dadosInsert.DES_ESPECIE_INSS,
    dadosInsert.COD_BENEF_INSS,
    dadosInsert.IND_PPE,
    dadosInsert.IND_PPE_FAMILIAR,
    dadosInsert.IND_FATCA
                    ); //Inserir(dadosInsert);
                    var a = new WebRecadDadosProxy().BuscarPorProtocolo(dadosInsert.COD_PROTOCOLO);
                    var oid_recad_dados = a != null ? a.OID_RECAD_DADOS : 0;


                    if (Dados.ListaDependentes.Count > 0)
                    {
                        Dados.ListaDependentes.ForEach((dep) =>
                        {
                            var depInsert = new WebRecadBeneficiarioEntidade();
                            depInsert.OID_RECAD_DADOS = oid_recad_dados;
                            depInsert.COD_PLANO = dep.CD_PLANO;
                            depInsert.NUM_SEQ_DEP = dep.NUM_SEQ_DEP;
                            depInsert.NOM_DEPENDENTE = dep.NOME_DEP?.ToUpper();
                            depInsert.COD_GRAU_PARENTESCO = dep.CD_GRAU_PARENTESCO;
                            depInsert.DES_GRAU_PARENTESCO = new GrauParentescoProxy().BuscarPorCodigo(dep.CD_GRAU_PARENTESCO).DS_GRAU_PARENTESCO;
                            depInsert.DTA_NASCIMENTO = dep.DT_NASC_DEP;
                            depInsert.COD_SEXO = dep.SEXO_DEP;
                            depInsert.DES_SEXO = new SexoProxy().BuscarPorCodigo(dep.SEXO_DEP).DS_SEXO;
                            depInsert.COD_CPF = dep.CPF.LimparMascara();
                            depInsert.COD_PERC_RATEIO = dep.PERC_PECULIO;
                            depInsert.IND_OPERACAO = dep.IND_OPERACAO;

                            //new WebRecadBeneficiarioProxy().Inserir(depInsert);
                            new WebRecadBeneficiarioProxy().Insert(
                                depInsert.OID_RECAD_DADOS,
                                depInsert.COD_PLANO,
                                depInsert.NUM_SEQ_DEP,
                                depInsert.NOM_DEPENDENTE,
                                depInsert.COD_GRAU_PARENTESCO,
                                depInsert.DES_GRAU_PARENTESCO,
                                depInsert.DTA_NASCIMENTO ?? DateTime.Now,
                                depInsert.COD_SEXO,
                                depInsert.DES_SEXO,
                                depInsert.COD_CPF,
                                depInsert.COD_PERC_RATEIO ?? 0,
                                depInsert.IND_OPERACAO
                            );
                        });
                    }

                    if (Dados.ListaDependentesIR.Count > 0)
                    {
                        Dados.ListaDependentesIR.ForEach((dep) =>
                        {
                            var depInsert = new WebRecadDepedenteIREntidade();
                            depInsert.OID_RECAD_DADOS = oid_recad_dados;
                            depInsert.NUM_SEQ_DEP = dep.NUM_SEQ_DEP;
                            depInsert.NOM_DEPENDENTE = dep.NOME_DEP?.ToUpper();
                            depInsert.COD_GRAU_PARENTESCO = dep.CD_GRAU_PARENTESCO;
                            depInsert.DES_GRAU_PARENTESCO = new GrauParentescoProxy().BuscarPorCodigo(dep.CD_GRAU_PARENTESCO).DS_GRAU_PARENTESCO;
                            depInsert.DTA_NASCIMENTO = dep.DT_NASC_DEP;
                            depInsert.DTA_INICIO_IRRF = dataAtual;
                            depInsert.DTA_TERMINO_IRRF = dep.DT_TERM_IRRF;
                            depInsert.COD_SEXO = dep.SEXO_DEP;
                            depInsert.DES_SEXO = new SexoProxy().BuscarPorCodigo(dep.SEXO_DEP).DS_SEXO;
                            depInsert.COD_CPF = dep.CPF.LimparMascara();
                            depInsert.IND_OPERACAO = dep.IND_OPERACAO;

                            //new WebRecadDepedenteIRProxy().Inserir(depInsert);
                            new WebRecadDepedenteIRProxy().Insert(
                                depInsert.OID_RECAD_DADOS,
                                depInsert.NUM_SEQ_DEP,
                                depInsert.NOM_DEPENDENTE,
                                depInsert.COD_GRAU_PARENTESCO,
                                depInsert.DES_GRAU_PARENTESCO,
                                depInsert.DTA_NASCIMENTO ?? DateTime.Now,
                                depInsert.DTA_INICIO_IRRF ?? DateTime.Now,
                                DateTime.Now,
                                depInsert.COD_SEXO,
                                depInsert.DES_SEXO,
                                depInsert.COD_CPF,
                                depInsert.IND_OPERACAO
                            );
                        });
                    }

                    var arquivos = new List<Stream>();
                    List<string> docNames = new List<string>();
                    if (Dados.ListaArquivo.Count > 0)
                    {
                        Dados.ListaArquivo.ForEach(arquivoId =>
                        {
                            var arquivoDados = new ArquivoUploadProxy().BuscarPorCodigo(arquivoId);
                            var arquivoInsert = new WebRecadDocumentoEntidade();
                            arquivoInsert.OID_RECAD_DADOS = oid_recad_dados;
                            arquivoInsert.TXT_TITULO = arquivoDados.NOM_ARQUIVO_LOCAL;
                            arquivoInsert.TXT_NOME_FISICO = arquivoDados.NOM_ARQUIVO_ORIGINAL;
                            new WebRecadDocumentoProxy().Insert(arquivoInsert.OID_RECAD_DADOS, arquivoInsert.TXT_TITULO, arquivoInsert.TXT_NOME_FISICO);
                            //new WebRecadDocumentoProxy().Inserir(arquivoInsert);

                            var caminhoArquivo = System.IO.Path.Combine(arquivoDados.NOM_DIRETORIO_LOCAL, arquivoDados.NOM_ARQUIVO_LOCAL);
                            var arquivo = new System.IO.FileInfo(caminhoArquivo);

                            arquivos.Add(arquivo.OpenRead());
                            docNames.Add(arquivoDados.NOM_ARQUIVO_LOCAL);
                        });
                    }
                    else
                    {
                        // se nao tiver arquivo pasa enviar, cancela o memory stream
                        arquivos = null;
                        docNames = null;
                    }

                    var campanha = new WebRecadCampanhaProxy().BuscarPorCodigo(recad.OID_RECAD_CAMPANHA);
                    var emailConfig = AppSettings.Get().Email;
                    var msgParticipante =
                        $"SABESPREV<br/><br/>" +

$"O seu recadastramento recebeu o número de protocolo <b>{dadosInsert.COD_PROTOCOLO}</b> e está em análise pela Sabesprev!<br/><br/>" +
$" Obrigado por realizar o seu recadastramento na Sabesprev! O recadastramento é uma exigência legal que garante a manutenção de seu benefício!";
                    // email para o participante
                    List<string> destinatario = new List<string>() {
                        Dados.Participante.EMAIL_AUX
                    };
                    Enviar(emailConfig, destinatario, $"Sabesprev - {campanha.NOM_CAMPANHA} - {Dados.Participante.NOME_ENTID}", msgParticipante);

                    var planos = "";
                    Dados.Participante.Planos.ForEach(p => planos = " / " + p.DS_PLANO);

                    var msgFundacao =
$"Portal SABESPREV<br/><br/>" +
$"Documento: <b>Recadastramento de Assistidos e Pensionistas - Web</b><br/>" +
$"Data de envio: <b>{dataAtual}</b><br/>" +
$"Nome do participante / solicitante: <b>{Dados.Participante.NOME_ENTID}<b><br/>" +
$"Matrícula: <b>{Dados.Participante.NUM_MATRICULA}${planos}</b><br/>" +
$"Protocolo: <b>{dadosInsert.COD_PROTOCOLO}</b><br/>" +
$"CPF: <b>{Dados.Participante.CPF_CGC}</b>";
                    destinatario = new List<string>() {
                        "viniciusvives@gmail.com"//"documentos@sabesprev.com.br"//
                    };
                    // email para a fundacao
                    Enviar(emailConfig, destinatario, $"{campanha.NOM_CAMPANHA} - Recadastramento de Assistidos e Pensionistas Web - {Dados.Participante.NOME_ENTID}", msgFundacao, arquivos, docNames);

                    transaction.Complete();

                    var msgFinal = $"O seu recadastramento recebeu o número de protocolo <b>{dadosInsert.COD_PROTOCOLO}</b> e está em análise pela Sabesprev!<br/><br/>" +
$"Obrigado por realizar o seu recadastramento na Sabesprev! O recadastramento é uma exigência legal que garante a manutenção de seu benefício!";
                    return Json(msgFinal);
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        text = ex.Message,
                        line = ex.ToString()
                    });
                }
            }
        }

        [HttpGet("[action]/{cpf}")]
        [AllowAnonymous]
        public IActionResult BuscarPorCpf(string cpf)
        {
            try
            {
                var dataAtual = DateTime.Now;
                var recad = new WebRecadPublicoAlvoProxy().BuscarPorCpfDataAtual(cpf.LimparMascara(), dataAtual).FirstOrDefault();
                var msg = "";
                if (recad == null)
                {
                    msg = "Não há recadastramento previsto para você. Para mais informações, favor entrar em contato com a Sabesprev através dos diversos canais de atendimento disponíveis.";
                }
                else
                {
                    if (recad.IND_SITUACAO_RECAD == "SOL")
                    {
                        msg = "Já existe um recadastramento solicitado por você. O mesmo encontra-se em análise pela Sabesprev e em breve você será informado. Caso o recadastramento informado anteriormente esteja incorreto, você pode solicitar um novo. Deseja solicitar um novo recadastramento?";
                    }
                    if (recad.IND_SITUACAO_RECAD == "EFE")
                    {
                        msg = $"O seu recadastramento já foi solicitado e efetivado pela Sabesprev em {recad.DTA_EFETIVACAO}. Agradecemos pela sua colaboração.";
                    }
                    if (recad.IND_SITUACAO_RECAD == "AGU" || recad.IND_SITUACAO_RECAD == "REC")
                    {
                        msg = "";
                    }
                }
                return Json(new
                {
                    msg = msg,
                    recad = recad
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{cpf}")]
        [AllowAnonymous]
        public IActionResult BuscarDadosPorCpf(string cpf)
        {
            try
            {
                var dataAtual = DateTime.Now;
                var recad = new WebRecadPublicoAlvoProxy().BuscarPorCpfDataAtual(cpf.LimparMascara(), dataAtual).FirstOrDefault();

                var info = new WebRecadPublicoAlvoProxy().BuscarDadosPorCdFundacaoSeqRecebedor(recad.CD_FUNDACAO, recad.SEQ_RECEBEDOR).FirstOrDefault();

                // remove Time do "obj" DateTime
                info.DT_NASCIMENTO = info.DT_NASCIMENTO.Substring(0, 10);
                info.DT_EMIS_IDENT = info.DT_EMIS_IDENT.Substring(0, 10);
                if (recad.CD_TIPO_RECEBEDOR == "G")
                {
                    info.NUM_MATRICULA = new FuncionarioProxy().BuscarNomePorCdFundacaoCdEmpresaNumMatricula(info.CD_FUNDACAO, info.CD_EMPRESA, info.NUM_MATRICULA).NOME_ENTID;
                }

                info.Planos = new WebRecadPublicoAlvoProxy().BuscarPlanoPorCdFundacaoSeqRecebedor(recad.CD_FUNDACAO, recad.SEQ_RECEBEDOR);

                var pb = new ProcessoBeneficioProxy().BuscarNumProcessoPrevPorCdFundacaoSeqRecebedor(recad.CD_FUNDACAO, recad.SEQ_RECEBEDOR).FirstOrDefault();
                info.NUM_PROCESSO_PREV = pb != null ? pb.NUM_PROCESSO_PREV : "";

                if ((info.CPF_CONJUGE == null && info.NOME_CONJUGE == null) || (info.CPF_CONJUGE == "" && info.NOME_CONJUGE == ""))
                {
                    var conjuge = new DependenteProxy().BuscarPorFundacaoInscricaoCdGrauParentescoPlanoPrevidencialFixo(info.CD_FUNDACAO, info.NUM_INSCRICAO, 2);
                    if (conjuge.Count > 0)
                    {
                        info.CPF_CONJUGE = conjuge.First().CPF;
                        info.NOME_CONJUGE = conjuge.First().NOME_DEP;
                    }
                }

                return Json(new
                {
                    info
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{CdFundacao}/{Inscricao}/{CdPlano}")]
        [AllowAnonymous]
        public IActionResult BuscarDepedentes(string CdFundacao, string Inscricao, string CdPlano)
        {
            try
            {
                return Json(new DependenteProxy().BuscarPorFundacaoInscricaoPlanoPlanoPrevidencialFixoOrderByGrauValidade(CdFundacao, Inscricao, CdPlano));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("[action]/{cpf}")]
        [AllowAnonymous]
        public IActionResult BuscarDepedentesIR(string cpf)
        {
            try
            {
                var dataAtual = DateTime.Now;
                var recad = new WebRecadPublicoAlvoProxy().BuscarPorCpfDataAtual(cpf.LimparMascara(), dataAtual).FirstOrDefault();
                var ListaDependentesIR = recad.CD_TIPO_RECEBEDOR == "A" ?
                    new DependenteProxy().BuscarPorFundacaoInscricaoIRAssistido(recad.CD_FUNDACAO, recad.NUM_INSCRICAO, dataAtual) :
                    new DependenteProxy().BuscarPorFundacaoSeqRecebedorIRPensionista(recad.CD_FUNDACAO, recad.SEQ_RECEBEDOR, dataAtual);

                return Json(ListaDependentesIR);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{email}")]
        [AllowAnonymous]
        public IActionResult ValidarEmail(string email)
        {
            try
            {
                if (!Validador.ValidarEmail(email))
                    return BadRequest("Email Inválido.");

                return Json("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{cpf}")]
        [AllowAnonymous]
        public IActionResult ValidarCpf(string cpf)
        {
            try
            {
                if (!Validador.ValidarCPF(cpf.LimparMascara()))
                    return BadRequest("CPF Inválido.");

                return Json("OK");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaPais()
        {
            try
            {
                return Json(new PaisProxy().Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaUf()
        {
            try
            {
                return Json(new UFProxy().Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaEstadoCivil()
        {
            try
            {
                return Json(new EstadoCivilProxy().Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaGrauParentesco()
        {
            try
            {
                var lista = new GrauParentescoProxy().BuscarOrderAlfabetica().ToList<GrauParentescoEntidade>();
                var filtro = new[] { "02", "03", "04", "06", "07", "09", "12", "41", "42" };
                return Json(lista.Where(x => filtro.Contains(x.CD_GRAU_PARENTESCO)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaGrauParentescoPlanoReforco()
        {
            try
            {
                var lista = new GrauParentescoProxy().BuscarOrderAlfabetica().ToList<GrauParentescoEntidade>();
                var filtro = new[] { "32", "28", "3", "2", "18", "40", "47", "24", "9", "23", "7", "42", "21", "15", "19", "6", "22", "4", "5", "41", "17", "0", "16", "30", "29", "13", "27", "31", "12", "36", "20", "26", "35" };
                return Json(lista.Where(x => filtro.Contains(x.CD_GRAU_PARENTESCO)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaGrauParentescoIRRF()
        {
            try
            {
                var lista = new GrauParentescoProxy().BuscarOrderAlfabetica().ToList<GrauParentescoEntidade>();
                var filtro = new[] { "02", "03", "04", "06", "07", "09", "10", "12", "40", "41", "42" };
                return Json(lista.Where(x => filtro.Contains(x.CD_GRAU_PARENTESCO)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaSexo()
        {
            try
            {
                return Json(new SexoProxy().BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult BuscarListaEspecieINSS()
        {
            try
            {
                return Json(new EspecieINSSProxy().Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public static void Enviar(ConfigEmail config, List<string> listaDestinatarios, string assunto, string corpo, List<Stream> anexos = null, List<string> tituloAnexo = null)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(config.EmailRemetente));

            foreach (var destinatario in listaDestinatarios)
                message.To.Add(new MailboxAddress(destinatario));

            message.Subject = assunto;

            var builder = new BodyBuilder
            {
                HtmlBody = corpo
            };

            if (anexos != null)
            {
                int c = 0;
                anexos.ForEach(anexo => {
                    builder.Attachments.Add(tituloAnexo[c], anexo);
                    c++;
                });
            }

            message.Body = builder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                // Necessário em alguns clientes
                if (config.DesprezarCertificado)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(config.EnderecoSMTP, config.Porta, MailKit.Security.SecureSocketOptions.Auto);

                if (config.RequerAutenticacao)
                    client.Authenticate(config.Usuario, config.Senha);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        private void EnviarTokenEmail(string token, string alvoEnvio)
        {
            try
            {

                var config = AppSettings.Get().Email;

                if (config == null)
                {
                    throw new Exception("Favor configurar o usuário e senha de E-mail da API para envio de TOKEN via E-mail.");
                }

                var mensagem = $"SABESPREV: Para validar a operação de recadastramento, insira o código a seguir e clique em 'Concluir Recadastramento'.<br/>" +
                    $"<br/>" +
                    $"<h3>{token}</h3>";
                var destinatario = new List<string>() { alvoEnvio };
                Enviar(config, destinatario, "Token para concluir o recadastramento Sabesprev", mensagem);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar o Token via E-mail. Favor contactar a Sabesprev. Erro: " + ex.Message);
            }
        }

        private void EnviarTokenCelular(string token, string alvoEnvio, string cpf)
        {
            try
            {
                var config = AppSettings.Get().SMS;

                var dados = new FuncionarioProxy().BuscarPorCpf(cpf).FirstOrDefault();

                if (dados == null)
                {
                    throw new Exception("Erro ao ccarregar os dados do participante.");
                }

                if (config == null || string.IsNullOrEmpty(config.Usuario) || string.IsNullOrEmpty(config.Senha))
                {
                    throw new Exception("Favor configurar o usuário e senha de SMS da API para envio de TOKEN via SMS.");
                }

                var mensagem = $"Para validar a operacao de recadastramento, insira o codigo a seguir e clique em 'Concluir Recadastramento': {token}";
                var retorno = new EnvioSMS()
                    .EnviarHumanAPI(alvoEnvio, config.Usuario, config.Senha, "SABESPREV", mensagem, dados.NUM_MATRICULA, dados.NUM_INSCRICAO,
                        new EventHandler<SMSEventArgs>(delegate (object sender, SMSEventArgs args)
                        {
                            try
                            {
                                var logSMSProxy = new LogSMSProxy();
                                logSMSProxy.Insert(args.Retorno, args.NumTelefone, args.Matricula, args.Inscricao);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception($"Ocorreu erro ao gravar log de sms: Message: {ex.Message}, e StackTrace: {ex.StackTrace}");
                            }
                        })
                    );
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao enviar o Token via SMS para o celular. Favor contactar a Sabesprev. Erro: " + ex.Message);
            }
        }
    }

    public class WebRecadDadosConclusaoEntidade
    {
        public WebRecadParticipanteDadosEntidade Participante { get; set; }
        public List<DependenteEntidade> ListaDependentes { get; set; }
        public List<DependenteEntidade> ListaDependentesIR { get; set; }
        public List<long> ListaArquivo { get; set; }
        public string CPF_Original { get; set; }
    }
    public class FileUploadViewModel
    {
        public IFormFile File { get; set; }
        public string source { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
    }
}