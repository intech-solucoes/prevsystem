#region Usings
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using Intech.Lib.Email;
using Intech.Lib.Web;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Intech.PrevSystem.Negocio.Sabesprev.Relatorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.FichaFinanceira)]
    public class FichaFinanceiraController : BaseFichaFinanceiraController
    {
        private IHostingEnvironment HostingEnvironment;

        public FichaFinanceiraController(IHostingEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
        }

        [HttpGet("sabesprevSaldoPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarSabesprevSaldoPorFundacaoEmpresaPlanoFundo(string cdPlano)
        {
            try
            {
                if (cdPlano == "0002") // Se for plano Reforço
                {
                    var saldo1 = new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(CdFundacao, CdEmpresa, cdPlano, Inscricao, "1");
                    var saldo2 = new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(CdFundacao, CdEmpresa, cdPlano, Inscricao, "2");
                    var saldo3 = new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(CdFundacao, CdEmpresa, cdPlano, Inscricao, "3");

                    return Json(new SaldoContribuicoesEntidade
                    {
                        QuantidadeCotasParticipante = saldo1.QuantidadeCotasParticipante + saldo2.QuantidadeCotasParticipante + saldo3.QuantidadeCotasParticipante,
                        QuantidadeCotasPatrocinadora = saldo1.QuantidadeCotasPatrocinadora + saldo2.QuantidadeCotasPatrocinadora + saldo3.QuantidadeCotasPatrocinadora,
                        ValorParticipante = saldo1.ValorParticipante + saldo2.ValorParticipante + saldo3.ValorParticipante,
                        ValorPatrocinadora = saldo1.ValorPatrocinadora + saldo2.ValorPatrocinadora + saldo3.ValorPatrocinadora,
                        DataReferencia = saldo1.DataReferencia,
                        DataCota = saldo1.DataCota,
                        ValorCota = saldo1.ValorCota
                    });
                }
                else
                {
                    var saldo = new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(CdFundacao, CdEmpresa, cdPlano, Inscricao, "6");
                    return Json(saldo);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        [Authorize("Bearer")]
        public IActionResult BuscarDatasInforme()
        {
            try
            {
                var datas = new FichaFinanceiraProxy().BuscarDatasInformePorFundacaoInscricao(CdFundacao, Inscricao);
                return Ok(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{ano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarInformePorAno(string ano)
        {
            try
            {
                var informes = new FichaFinanceiraProxy().BuscarInformePlanosPorFundacaoInscricaoAno(CdFundacao, Inscricao, ano);
                var listaInformes = new List<object>();

                foreach(var informe in informes)
                {
                    var inf = new
                    {
                        Plano = new PlanoProxy().BuscarPorCodigo(informe.CD_PLANO),
                        Valor = informe.CONTRIB_PARTICIPANTE
                    };

                    listaInformes.Add(inf);
                }

                return Ok(listaInformes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{ano}/{email}")]
        [Authorize("Bearer")]
        public IActionResult EnviarDeclaracaoIR(string ano, string email)
        {
            try
            {
                var nomeArquivoRepx = "DeclaracaoIR";
                var relatorio = XtraReport.FromFile($"Relatorios/{nomeArquivoRepx}.repx");
                
                var informes = new FichaFinanceiraProxy().BuscarInformePlanosPorFundacaoInscricaoAno(CdFundacao, Inscricao, ano);
                var listaInformes = new List<DeclaracaoIR>();

                foreach (var informe in informes)
                {
                    var plano = new PlanoProxy().BuscarPorCodigo(informe.CD_PLANO);

                    var inf = new DeclaracaoIR
                    {
                        Plano = plano.DS_PLANO,
                        CNPB = plano.COD_CNPB,
                        Valor = informe.CONTRIB_PARTICIPANTE.Value.ToString("N2"),
                        ValorPorExtenso = informe.CONTRIB_PARTICIPANTE.Value.PorExtenso()
                    };

                    listaInformes.Add(inf);
                }

                var funcionario = new FuncionarioProxy().BuscarDadosPorCodEntid(CodEntid);

                ((ObjectDataSource)relatorio.DataSource).Constructor.Parameters.First(x => x.Name == "ano").Value = ano;
                ((ObjectDataSource)relatorio.DataSource).Constructor.Parameters.First(x => x.Name == "funcionario").Value = funcionario;
                ((ObjectDataSource)relatorio.DataSource).Constructor.Parameters.First(x => x.Name == "dados").Value = listaInformes;

                relatorio.FillDataSource();

                var folderName = "Temp";
                var tempFolder = Path.Combine(HostingEnvironment.ContentRootPath, folderName);
                var nomeArquivo = $"{nomeArquivoRepx}_{Guid.NewGuid().ToString()}.pdf";
                var arquivo = Path.Combine(tempFolder, nomeArquivo);

                if (!Directory.Exists(tempFolder))
                    Directory.CreateDirectory(tempFolder);

                var tfc = new TempFileCollection(tempFolder, false);
                tfc.AddFile(arquivo, false);

                relatorio.ExportToPdf(arquivo);

                var pdf = System.IO.File.OpenRead(arquivo);

                var filename = $"Declaração de contribuições para fins de IR.pdf";

                var dados = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                var emailConfig = AppSettings.Get().Email;
                var corpo = $"Prezado(a) Sr(a), {dados.NOME_ENTID} <br/>" +
                    "<br/>" +
                    "Esta é a sua declaração de contribuições para fins de IR.<br/>" +
                    "<br/>" +
                    "Fundação Sabesp de Seguridade Social - Sabesprev";
                EnvioEmail.Enviar(emailConfig, email, "Sabesprev - Declaração de contribuições para fins de IR", corpo, pdf, filename);
                
                return Json($"Declaração enviada com sucesso para o e-mail {email}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}