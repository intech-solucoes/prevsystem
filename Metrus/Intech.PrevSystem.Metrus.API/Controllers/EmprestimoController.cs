#region Usings
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : Controller
    {
        #region Situacoes

        [HttpGet("situacoes")]
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

        [HttpGet("porCodEntid/{codEntid}")]
        public IActionResult BuscarPorCodEntid(string codEntid)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlano/{codEntid}/{cdPlano}")]
        public IActionResult BuscarPorCodEntidPlano(string codEntid, string cdPlano)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidSituacao/{codEntid}/{situacao}")]
        public IActionResult BuscarPorCodEntidSituacao(string codEntid, string situacao)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoSituacao/{codEntid}/{cdPlano}/{situacao}")]
        public IActionResult BuscarPorCodEntidPlanoSituacao(string codEntid, string cdPlano, string situacao)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Prestações

        [HttpGet("prestacoesPorCodEntidNumContratoAnoContrato/{codEntid}/{numContrato}/{anoContrato}")]
        public IActionResult BuscarPrestacoesPorCodEntidNumContratoAnoContrato(string codEntid, decimal numContrato, decimal anoContrato)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new PrestacaoProxy().BuscarPorFundacaoContrato(funcionario.CD_FUNDACAO, anoContrato, numContrato));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}