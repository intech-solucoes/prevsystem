using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : Controller
    {
        [HttpGet("resumoAnosPorCodEntidPlano/{codEntid}/{cdPlano}")]
        public virtual IActionResult GetResumoAnosPorPlano(string codEntid, string cdPlano)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                return Json(new FichaFinanceiraProxy().BuscarResumoAnosPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoMesesPorCodEntidPlanoAno/{codEntid}/{cdPlano}/{anoRef}")]
        public virtual IActionResult GetResumoMesesPorPlanoAno(string codEntid, string cdPlano, string anoRef)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");
                return Json(new FichaFinanceiraProxy().BuscarResumoMesesPorFundacaoPlanoInscricaoAno(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO, anoRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoAnoMes/{codEntid}/{cdPlano}/{anoRef}/{mesRef}")]
        public virtual IActionResult GetTiposPorFundacaoPlanoAnoMes(string codEntid, string cdPlano, string anoRef, string mesRef)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                return Json(new FichaFinanceiraProxy().BuscarTiposPorFundacaoPlanoInscricaoAnoMes(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO, anoRef, mesRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}