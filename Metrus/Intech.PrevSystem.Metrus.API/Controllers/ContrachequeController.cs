#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
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
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy().BuscarDatas(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano);

                fichaFinanceira = fichaFinanceira
                    .Take(quantidadeMesesContraCheque)
                    .ToList();
                
                // Subtrai um mês da data de referência
                // GAMBIARRA QUE NÃO É CULPA MINHA, É CULPA DO PULSCHEN QUE TAVA TEIMANDO
                foreach (var ficha in fichaFinanceira)
                {
                    ficha.DT_REFERENCIA = ficha.DT_REFERENCIA.AddMonths(-1);
                }

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

                // Soma um mês da data de referência
                // GAMBIARRA QUE NÃO É CULPA MINHA, É CULPA DO PULSCHEN QUE TAVA TEIMANDO
                dataReferencia = dataReferencia.AddMonths(1);

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy()
                    .Metrus_BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano, dataReferencia, "1");

                return Json(fichaFinanceira);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoReferenciaTipoFolha/{codEntid}/{cdPlano}/{referencia}/{cdTipoFolha}")]
        public ActionResult GetPorCodEntidPlanoReferenciaTipoFolha(string codEntid, string cdPlano, string referencia, string cdTipoFolha)
        {
            try
            {
                var dataReferencia = DateTime.ParseExact(referencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                // Soma um mês da data de referência
                // GAMBIARRA QUE NÃO É CULPA MINHA, É CULPA DO PULSCHEN QUE TAVA TEIMANDO
                dataReferencia = dataReferencia.AddMonths(1);

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var fichaFinanceira = new FichaFinanceiraAssistidoProxy().Metrus_BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, cdPlano, dataReferencia, cdTipoFolha);

                return Json(fichaFinanceira);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}