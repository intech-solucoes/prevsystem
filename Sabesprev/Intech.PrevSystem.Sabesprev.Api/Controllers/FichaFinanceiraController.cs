#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class FichaFinanceiraController : Controller
    {
        [HttpGet("ultimaPorFundacaoPlanoInscricao/{cdFundacao}/{cdPlano}/{numInscricao}")]
        public IActionResult GetUltimaPorFundacaoPlanoInscricao(string cdFundacao, string cdPlano, string numInscricao)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarUltimaPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoAnosPorFundacaoPlanoInscricao/{cdFundacao}/{cdPlano}/{numInscricao}")]
        public IActionResult GetResumoAnosPorFundacaoPlanoInscricao(string cdFundacao, string cdPlano, string numInscricao)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoAnosPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoMesesPorFundacaoPlanoInscricaoAno/{cdFundacao}/{cdPlano}/{numInscricao}/{anoRef}")]
        public IActionResult GetResumoMesesPorFundacaoPlanoInscricaoAno(string cdFundacao, string cdPlano, string numInscricao, string anoRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoMesesPorFundacaoPlanoInscricaoAno(cdFundacao, cdPlano, numInscricao, anoRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tiposPorFundacaoPlanoInscricaoAnoMes/{cdFundacao}/{cdPlano}/{numInscricao}/{anoRef}/{mesRef}")]
        public IActionResult GetTiposPorFundacaoPlanoInscricaoAnoMes(string cdFundacao, string cdPlano, string numInscricao, string anoRef, string mesRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarTiposPorFundacaoPlanoInscricaoAnoMes(cdFundacao, cdPlano, numInscricao, anoRef, mesRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saldoPorFundacaoEmpresaPlanoInscricaoFundo/{cdFundacao}/{cdEmpresa}/{cdPlano}/{numInscricao}/{cdFundo}")]
        public IActionResult GetSaldoPorFundacaoEmpresaPlanoInscricaoFundo(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(cdFundacao, cdEmpresa, cdPlano, numInscricao, cdFundo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
