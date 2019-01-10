#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization; 
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContrachequeController : Controller
    {
        [HttpGet("datasPorCodEntidPlano/{codEntid}/{cdPlano}")]
        public ActionResult GetDatasPorCodEntidPlano(string codEntid, string cdPlano)
        {
            try
            {
                var quantidadeMesesContraCheque = 18;
                var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy().BuscarDatas(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano, dtReferencia);
                
                return Json(fichaFinanceira);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoCompetencia/{codEntid}/{cdPlano}/{competencia}")]
        public ActionResult GetPorCodEntidPlanoCompetencia(string codEntid, string cdPlano, string competencia)
        {
            try
            {
                var dataCompetencia = DateTime.ParseExact(competencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy().BuscarRubricasPorFundacaoEmpresaMatriculaPlanoCompetencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano, dataCompetencia, "1");

                return Json(fichaFinanceira);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoReferencia/{codEntid}/{cdPlano}/{referencia}")]
        public ActionResult GetPorCodEntidPlanoReferencia(string codEntid, string cdPlano, string referencia)
        {
            try
            {
                var dataReferencia = DateTime.ParseExact(referencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy().BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano, dataReferencia, "1");

                return Json(fichaFinanceira);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}