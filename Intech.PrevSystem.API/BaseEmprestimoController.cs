#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseEmprestimoController : BaseController
    {
        #region Situacoes

        [HttpGet("situacoes")]
        [Authorize("Bearer")]
        public IActionResult BuscarSituacoes()
        {
            try
            {
                return Json(new SitContratoProxy().Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Contratos

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCodEntid()
        {
            try
            {
                return Json(new ContratoProxy().BuscarPorFundacaoInscricao(CdFundacao, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCodEntidPlano(string cdPlano)
        {
            try
            {
                return Json(new ContratoProxy().BuscarPorFundacaoPlanoInscricao(CdFundacao, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porSituacao/{situacao}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCodEntidSituacao(string situacao)
        {
            try
            {
                return Json(new ContratoProxy().BuscarPorFundacaoInscricaoSituacao(CdFundacao, Inscricao, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porPlanoSituacao/{cdPlano}/{situacao}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCodEntidPlanoSituacao(string cdPlano, string situacao)
        {
            try
            {
                return Json(new ContratoProxy().BuscarPorFundacaoPlanoInscricaoSituacao(CdFundacao, cdPlano, Inscricao, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Prestações

        [HttpGet("prestacoesPorNumContratoAnoContrato/{numContrato}/{anoContrato}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPrestacoesPorCodEntidNumContratoAnoContrato(decimal numContrato, decimal anoContrato)
        {
            try
            {
                return Json(new PrestacaoProxy().BuscarResumoPorFundacaoContrato(CdFundacao, anoContrato, numContrato));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}