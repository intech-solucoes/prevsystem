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
        [HttpGet("ultimaPorFundacaoPlano/{cdFundacao}/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetUltimaPorFundacaoPlano(string cdFundacao, string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarUltimaPorFundacaoPlanoInscricao(cdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("salarioContribuicaoPorFundacaoPlano/{cdFundacao}/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetSalarioContribuicaoPorFundacaoPlano(string cdFundacao, string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarSalarioContribuicaoPorFundacaoPlanoInscricao(cdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoAnosPorFundacaoPlano/{cdFundacao}/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetResumoAnosPorFundacaoPlano(string cdFundacao, string cdPlano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoAnosPorFundacaoPlanoInscricao(cdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoMesesPorFundacaoPlanoAno/{cdFundacao}/{cdPlano}/{anoRef}")]
        [Authorize("Bearer")]
        public IActionResult GetResumoMesesPorFundacaoPlanoAno(string cdFundacao, string cdPlano, string anoRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarResumoMesesPorFundacaoPlanoInscricaoAno(cdFundacao, cdPlano, Inscricao, anoRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tiposPorFundacaoPlanoAnoMes/{cdFundacao}/{cdPlano}/{anoRef}/{mesRef}")]
        [Authorize("Bearer")]
        public IActionResult GetTiposPorFundacaoPlanoAnoMes(string cdFundacao, string cdPlano, string anoRef, string mesRef)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarTiposPorFundacaoPlanoInscricaoAnoMes(cdFundacao, cdPlano, Inscricao, anoRef, mesRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("saldoPorFundacaoEmpresaPlanoFundo/{cdFundacao}/{cdEmpresa}/{cdPlano}/{cdFundo}")]
        [Authorize("Bearer")]
        public IActionResult GetSaldoPorFundacaoEmpresaPlanoFundo(string cdFundacao, string cdEmpresa, string cdPlano, string cdFundo)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(cdFundacao, cdEmpresa, cdPlano, Inscricao, cdFundo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
