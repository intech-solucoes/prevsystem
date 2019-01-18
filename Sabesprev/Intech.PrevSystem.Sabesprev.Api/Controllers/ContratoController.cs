#region Usings
using Intech.Lib.Servicos;
using Intech.Lib.Util.Email;
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Web;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Intech.PrevSystem.Negocio.Sabesprev;
using Intech.PrevSystem.Negocio.Sabesprev.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.Contrato)]
    public class ContratoController : BaseContratoController
    {
        [HttpGet("sabesprevAtivosPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarAtivos(string cdPlano)
        {
            try
            {
                var contratos = new List<ContratoEntidade>();
                contratos = BuscarContratos(cdPlano);

                return Json(contratos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sabesprevDatasQuitacao")]
        [Authorize("Bearer")]
        public IActionResult BuscarDatasQuitacao()
        {
            try
            {
                var feriados = new FeriadoProxy().BuscarDatas().ToList();
                var dataCredito = DateTime.Today;
                var datas = new List<string>();

                for (int i = 0; i < 6; i++)
                {
                    datas.Add(dataCredito.AddDiaUtil(i, feriados).ToString("dd/MM/yyyy"));
                }

                return Json(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sabesprevPorAnoNum/{ano}/{num}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDetalhe(string ano, string num)
        {
            try
            {
                var dtQuitacao = DateTime.Today;
                return Json(new ContratoProxySabesprev().BuscarPorAnoNumContrato(CdFundacao, CdEmpresa, ano, num, dtQuitacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sabesprevPorAnoNumDataQuitacao/{ano}/{num}/{dataQuitacao}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDetalheDataQuitacao(string ano, string num, string dataQuitacao)
        {
            try
            {
                DateTime dtQuitacao = DateTime.ParseExact(dataQuitacao, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                return Json(new ContratoProxySabesprev().BuscarPorAnoNumContrato(CdFundacao, CdEmpresa, ano, num, dtQuitacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("parametrosPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarParametros(string cdPlano)
        {
            try
            {
                var planoVinculadoProxy = new PlanoVinculadoProxy();
                var modalidadeProxy = new ModalidadeProxy();
                var fichaFinanceiraProxy = new FichaFinanceiraProxy();
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);

                // Plano
                var plano = planoVinculadoProxy.BuscarPorFundacaoEmpresaMatriculaPermiteEmprestimo(CdFundacao, CdEmpresa, Matricula)
                    .Where(x => x.CD_PLANO == cdPlano).FirstOrDefault();
                
                decimal origem;
                switch (plano.CD_CATEGORIA)
                {
                    case DMN_CATEGORIA.ATIVO:
                    case DMN_CATEGORIA.AUTOPATROCINIO:
                    case DMN_CATEGORIA.EM_LICENCA: //Ativos, Autopatrocinados ou Em licença
                    case DMN_CATEGORIA.DIFERIDO: //Assistidos ou Diferidos
                        origem = 1;
                        break;
                    case DMN_CATEGORIA.ASSISTIDO:
                        origem = 4;
                        break;
                    case DMN_CATEGORIA.DESLIGADO: //Desligados
                    default:
                        throw new Exception("Concessão de empréstimo não permitida para usuários na situação Desligado");
                }

                plano.UltimoSalario = planoVinculadoProxy.BuscarUltimoSalario(CdEmpresa, Matricula, origem, plano);

                // Modalidades
                var modalidades = modalidadeProxy.BuscarAtivas().ToList();

                var ativo = plano.CD_CATEGORIA == DMN_CATEGORIA.ATIVO ? "S" : null;
                var assistido = plano.CD_CATEGORIA == DMN_CATEGORIA.ASSISTIDO ? "S" : null;
                var autopatrocinio = plano.CD_CATEGORIA == DMN_CATEGORIA.AUTOPATROCINIO ? "S" : null;
                var diferido = plano.CD_CATEGORIA == DMN_CATEGORIA.DIFERIDO ? "S" : null;

                var tempoContribuicaoParticipante = 0;

                var fichaFinanceira = fichaFinanceiraProxy.BuscarPorFundacaoPlanoInscricao(CdFundacao, plano.CD_PLANO, plano.NUM_INSCRICAO);

                // Verifica se foi migrado do plano 1
                var migrado = new PlanoVinculadoProxy().MigradoPlano1(plano.NUM_INSCRICAO) > 0;
                if (migrado)
                {
                    tempoContribuicaoParticipante = fichaFinanceiraProxy.BuscarPlanoUmDoisPorFundacaoInscricao(CdFundacao, plano.NUM_INSCRICAO).Count();
                }
                else
                {
                    if (plano.CD_PLANO == "0001")
                        tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CD_TIPO_CONTRIBUICAO == "01").Count();
                    else
                        tempoContribuicaoParticipante = fichaFinanceira.Where(x => x.CALC_MARGEM_CONSIG == "S").Count();
                }

                var tempoContribuicao = modalidadeProxy.ObtemTempoContribuicao(tempoContribuicaoParticipante);

                foreach (var modalidade in modalidades)
                {
                    modalidade.Naturezas = new NaturezaProxy().BuscarPorModalidadePlanoCategoria(modalidade.CD_MODAL, plano.CD_PLANO, ativo, assistido, autopatrocinio, diferido).ToList();

                    if (modalidade.Naturezas.Count == 0)
                        throw new Exception("Participante não possui contribuição suficiente para simular emprestimo");
                }

                var feriados = new FeriadoProxy().BuscarDatas().ToList();

                return Json(new
                {
                    dataSolicitacao = DateTime.Today.ToString("dd/MM/yyyy"),
                    dataCredito = DateTime.Today.AddDiaUtil(2, feriados).ToString("dd/MM/yyyy"),
                    plano,
                    modalidades
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("buscarConcessao/{cdPlano}/{cdModal}/{cdNatur}/{dataCredito}")]
        [Authorize("Bearer")]
        public IActionResult BuscarConcessao(string cdPlano, decimal cdModal, decimal cdNatur, string dataCredito)
        {
            try
            {
                DateTime dtCredito = DateTime.ParseExact(dataCredito, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);

                var concessao = ConcessaoSabesprev.ObtemConcessao(funcionario, cdPlano, cdNatur, cdModal, dtCredito, DateTime.Now, Pensionista, SeqRecebedor);

                return Json(new { concessao });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("parametrosParcelas")]
        [Authorize("Bearer")]
        public IActionResult ParametrosParcelas([FromBody] ParametrosSimulacao dados)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);

                var feriados = new FeriadoProxy().BuscarDatas().ToList();
                var dataCredito = DateTime.Today.AddDiaUtil(2, feriados);

                var contratosDisponiveis = new ContratoDisponivel().BuscarContratosDisponiveis(funcionario, dados.Concessao, dados.CD_PLANO, dados.CD_MODAL, dados.CD_NATUR, dataCredito, dados.ValorSolicitado);

                if (contratosDisponiveis.Count > 0)
                    return Json(contratosDisponiveis);
                else
                    return Json(new
                    {
                        mensagem = "Não existem parcelas disponíveis para simulação/contratação"
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("gerarToken/{enviarEmail}/{enviarSMS}")]
        [Authorize("Bearer")]
        public IActionResult GerarToken(bool enviarEmail, bool enviarSMS)
        {
            try
            {
                var token = Math.Truncate(new Random(DateTime.Now.Millisecond).NextDouble() * 1000000).ToString();

                var funcionario = new FuncionarioProxy().BuscarDadosPorCodEntid(CodEntid);

                if (!enviarEmail && !enviarSMS)
                    throw new Exception("ATENÇÃO! Não foi informado Celular ou Email para envio do Token.");

                if (enviarEmail && string.IsNullOrEmpty(funcionario.DadosPessoais.EMAIL_AUX))
                    throw new Exception("ATENÇÃO! Email não cadastrado.");

                if(enviarSMS && string.IsNullOrEmpty(funcionario.DadosPessoais.FONE_CELULAR))
                    throw new Exception("ATENÇÃO! Telefone celular não cadastrado.");
                
                string erros;

                var config = AppSettings.Get();

                if (enviarEmail)
                {
                    try
                    {
                        if (config.Email == null)
                            throw new Exception("Favor configurar o usuário e senha para envio de TOKEN via E-mail");

                        var mensagem = $"SABESPREV: Para validar a operação de empréstimo, insira o código a seguir e clique em Contratar.<br/>" +
                            $"<br/>" +
                            $"<h3>{token}</h3>";
                        EnvioEmail.Enviar(config.Email, funcionario.DadosPessoais.EMAIL_AUX, "Token para contratar empréstimo Sabesprev", mensagem);
                    }
                    catch (Exception ex)
                    {
                        erros = "Erro ao enviar o Token via E-mail. Favor contactar a Sabesprev. Erro: " + ex.Message;
                    }
                }

                if (enviarSMS)
                {
                    try
                    {
                        if (config.SMS == null || string.IsNullOrEmpty(config.SMS.Usuario) || string.IsNullOrEmpty(config.SMS.Senha))
                            throw new Exception("Favor configurar o usuário e senha para envio de TOKEN via SMS");

                        var mensagem = $"Para validar a operacao de emprestimo, insira o codigo a seguir e clique em 'Contratar Emprestimo': {token}";
                        var retorno = new EnvioSMS()
                            .EnviarHumanAPI(funcionario.DadosPessoais.FONE_CELULAR, config.SMS.Usuario, config.SMS.Senha, "SABESPREV", mensagem, Matricula, Inscricao, true);

                    }
                    catch (Exception ex)
                    {
                        erros = "Erro ao enviar o Token via SMS para o celular. Favor contactar a Sabesprev. Erro: " + ex.Message;
                    }
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
                    mensagem = ex.Message
                });
            }
        }

        [HttpPost("contratar")]
        [Authorize("Bearer")]
        public IActionResult Contratar([FromBody] ParametrosContrato dados)
        {
            try
            {
                if (dados.Token != dados.TokenDigitado)
                    throw new Exception("O Token informado está inválido. Contrato não efetuado.");

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);

                return Json(new
                {
                    AnoNumContrato = new ContratoProxySabesprev().Contratar(funcionario, dados.Contrato, dados.Concessao, dados.SaldoDevedor)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
        }

        #region Métodos Privados

        private List<ContratoEntidade> BuscarContratos(string cdPlano)
        {
            List<ContratoEntidade> contratos;
            if (Pensionista)
                contratos = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(CdFundacao, CdEmpresa, cdPlano, Inscricao, GrupoFamilia, DMN_SITUACAO_CONTRATO.ATIVO);
            else
                contratos = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_SITUACAO_CONTRATO.ATIVO);
            return contratos;
        }

        #endregion
    }

    public class ParametrosSimulacao
    {
        public string CD_PLANO { get; set; }
        public decimal CD_MODAL { get; set; }
        public decimal CD_NATUR { get; set; }
        public decimal ValorSolicitado { get; set; }
        public Concessao Concessao { get; set; }
    }

    public class ParametrosContrato
    {
        public string Token { get; set; }
        public string TokenDigitado { get; set; }
        public string CD_PLANO { get; set; }
        public ContratoDisponivel Contrato { get; set; }
        public Concessao Concessao { get; set; }
        public SaldoDevedorEntidade SaldoDevedor { get; set; }
    }
}