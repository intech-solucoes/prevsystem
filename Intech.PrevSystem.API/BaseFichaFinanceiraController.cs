#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public abstract class BaseFichaFinanceiraController : BaseController
    {
        [HttpGet("ultimaPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetUltimaPorPlano(string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarUltimaPorFundacaoPlanoInscricao(CdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salarioContribuicaoPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetSalarioContribuicaoPorFundacaoPlano(string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarSalarioContribuicaoPorFundacaoPlanoInscricao(CdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoAnosPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public virtual IActionResult GetResumoAnosPorPlano(string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoAnosPorFundacaoPlanoInscricao(CdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoMesesPorPlanoAno/{cdPlano}/{anoRef}")]
        [Authorize("Bearer")]
        public virtual IActionResult GetResumoMesesPorPlanoAno(string cdPlano, string anoRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoMesesPorFundacaoPlanoInscricaoAno(CdFundacao, cdPlano, Inscricao, anoRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tiposPorPlanoAnoMes/{cdPlano}/{anoRef}/{mesRef}")]
        [Authorize("Bearer")]
        public virtual IActionResult GetTiposPorFundacaoPlanoAnoMes(string cdPlano, string anoRef, string mesRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarTiposPorFundacaoPlanoInscricaoAnoMes(CdFundacao, cdPlano, Inscricao, anoRef, mesRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saldoPorPlanoFundo/{cdPlano}/{cdFundo}")]
        [Authorize("Bearer")]
        public IActionResult BuscarSaldoPorFundacaoEmpresaPlanoFundo(string cdPlano, string cdFundo)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(CdFundacao, CdEmpresa, cdPlano, Inscricao, cdFundo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
