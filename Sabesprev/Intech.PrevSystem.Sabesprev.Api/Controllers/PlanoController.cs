#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.Plano)]
    public class PlanoController : BasePlanoController
    {
        [HttpGet("porFundacaoEmpresaCpfPensionista/{fundacao}/{empresa}/{cpf}")]
        public IActionResult GetPorCpfPensionista(string fundacao, string empresa, string cpf)
        {
            try
            {
                if(Pensionista)
                    return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaCpfPensionista(fundacao, empresa, cpf));
                else
                    return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaCpf(fundacao, empresa, cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pagina/{cdPlano}")]
        public IActionResult GetPagina(string cdPlano)
        {
            var nomeArquivo = "";

            switch(cdPlano)
            {
                case "0001":
                    nomeArquivo = "BD";
                    break;
                case "0002":
                    nomeArquivo = "REFORCO";
                    break;
                case "0003":
                    nomeArquivo = "MAIS";
                    break;
            }

            return Json(System.IO.File.ReadAllText($"Planos/{nomeArquivo}.html"));
        }

        [HttpGet("rentabilidade")]
        public IActionResult BuscarRentabilidade()
        {
            try
            {
                var indiceProxy = new TbgIndiceProxy();

                var IndiceMETA = indiceProxy.BuscarPorCodIndice("META_GER");
                var referencia = IndiceMETA.Valores.First().DTA_INDICE;

                var IndiceBD = indiceProxy.BuscarPorCodIndiceData("COTA_BD", referencia);
                var IndiceSBM = indiceProxy.BuscarPorCodIndiceData("COTA_SBM", referencia);
                var IndiceREFORCO = indiceProxy.BuscarPorCodIndiceData("COTA_REFORCO", referencia);

                var IndiceAnoAnteriorBD = indiceProxy.BuscarPorCodIndiceData("COTA_BD", DateTime.Today.AddYears(-1).UltimoDiaDoAno());
                var IndiceAnoAnteriorSBM = indiceProxy.BuscarPorCodIndiceData("COTA_SBM", DateTime.Today.AddYears(-1).UltimoDiaDoAno());
                var IndiceAnoAnteriorREFORCO = indiceProxy.BuscarPorCodIndiceData("COTA_REFORCO", DateTime.Today.AddYears(-1).UltimoDiaDoAno());

                var IndiceAnoRetrasadoBD = indiceProxy.BuscarPorCodIndiceData("COTA_BD", DateTime.Today.AddYears(-2).UltimoDiaDoAno());
                var IndiceAnoRetrasadoSBM = indiceProxy.BuscarPorCodIndiceData("COTA_SBM", DateTime.Today.AddYears(-2).UltimoDiaDoAno());
                var IndiceAnoRetrasadoREFORCO = indiceProxy.BuscarPorCodIndiceData("COTA_REFORCO", DateTime.Today.AddYears(-2).UltimoDiaDoAno());

                // Indicadores
                var IndiceCDI = indiceProxy.BuscarPorCodIndiceData("CDI", referencia);
                var IndicePOUPANCA = indiceProxy.BuscarPorCodIndiceData("POUPANCA", referencia);

                var IndiceAnoAnteriorMETA = indiceProxy.BuscarPorCodIndiceData("META_GER", DateTime.Today.AddYears(-1).UltimoDiaDoAno());
                var IndiceAnoAnteriorCDI = indiceProxy.BuscarPorCodIndiceData("CDI", DateTime.Today.AddYears(-1).UltimoDiaDoAno());
                var IndiceAnoAnteriorPOUPANCA = indiceProxy.BuscarPorCodIndiceData("POUPANCA", DateTime.Today.AddYears(-1).UltimoDiaDoAno());

                var IndiceAnoRetrasadoMETA = indiceProxy.BuscarPorCodIndiceData("META_GER", DateTime.Today.AddYears(-2).UltimoDiaDoAno());
                var IndiceAnoRetrasadoCDI = indiceProxy.BuscarPorCodIndiceData("CDI", DateTime.Today.AddYears(-2).UltimoDiaDoAno());
                var IndiceAnoRetrasadoPOUPANCA = indiceProxy.BuscarPorCodIndiceData("POUPANCA", DateTime.Today.AddYears(-2).UltimoDiaDoAno());

                return Json(new
                {
                    IndiceBD,
                    IndiceSBM,
                    IndiceREFORCO,
                    IndiceAnoAnteriorBD,
                    IndiceAnoAnteriorSBM,
                    IndiceAnoAnteriorREFORCO,
                    IndiceAnoRetrasadoBD,
                    IndiceAnoRetrasadoSBM,
                    IndiceAnoRetrasadoREFORCO,

                    IndiceMETA,
                    IndiceCDI,
                    IndicePOUPANCA,
                    IndiceAnoAnteriorMETA,
                    IndiceAnoAnteriorCDI,
                    IndiceAnoAnteriorPOUPANCA,
                    IndiceAnoRetrasadoMETA,
                    IndiceAnoRetrasadoCDI,
                    IndiceAnoRetrasadoPOUPANCA,

                    Referencia = $"{referencia.ToString("MM/yyyy")}"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}