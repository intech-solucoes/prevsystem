#region Usings
using Intech.PrevSystem.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.Plano)]
    public class PlanoController : BasePlanoController
    {
        [HttpGet("relatorioExtratoPorFundacaoEmpresaPlanoReferencia/{cdFundacao}/{cdEmpresa}/{cdPlano}/{dtInicio}/{dtFim}")]
        [Authorize("Bearer")]
        public IActionResult GetRelatorioExtratoPorFundacaoEmpresaPlanoReferencia(string cdFundacao, string cdEmpresa, string cdPlano, string dtInicio, string dtFim)
        {
            try
            {
                var dataInicio = DateTime.ParseExact(dtInicio, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var dataFim = DateTime.ParseExact(dtFim, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                var relatorio = new Relatorios.RelatorioExtratoContribuicao();
                relatorio.GerarRelatorio(cdFundacao, cdEmpresa, cdPlano, Matricula, dataInicio, dataFim);

                using (MemoryStream ms = new MemoryStream())
                {
                    relatorio.ExportToPdf(ms);

                    // Clona stream pois o método ExportToPdf fecha a atual
                    var pdfStream = new MemoryStream();
                    pdfStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    pdfStream.Position = 0;

                    var filename = $"ExtratoContribuicoes_{Guid.NewGuid().ToString()}.pdf";

                    return File(pdfStream, "application/pdf", filename);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("certificado/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetCertificado(string cdPlano)
        {
            try
            {
                var relatorio = new Relatorios.CertificadoDeRegistroNoPlano();
                relatorio.GerarRelatorio(Matricula, cdPlano);

                using (MemoryStream ms = new MemoryStream())
                {
                    relatorio.ExportToPdf(ms);

                    // Clona stream pois o método ExportToPdf fecha a atual
                    var pdfStream = new MemoryStream();
                    pdfStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    pdfStream.Position = 0;

                    var filename = $"Certificado de Participacao.pdf";

                    return File(pdfStream, "application/pdf", filename);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
