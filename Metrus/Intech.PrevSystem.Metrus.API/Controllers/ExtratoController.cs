using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;

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

        [HttpGet("porCodEntidPlanoPeriodo/{codEntid}/{cdPlano}/{dtInicio}/{dtFim}")]
        public virtual IActionResult GetTiposPorFundacaoPlanoPeriodo(string codEntid, string cdPlano, string dtInicio, string dtFim)
        {
            try
            {
                var dataInicio = DateTime.ParseExact(dtInicio, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var dataFim = DateTime.ParseExact(dtFim, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                var lista = new FichaFinanceiraProxy().BuscarPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, cdPlano, funcionario.NUM_INSCRICAO)
                    .Where(x => new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) > dataInicio &&
                                new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) < dataFim)
                    .ToList();

                return Json(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}