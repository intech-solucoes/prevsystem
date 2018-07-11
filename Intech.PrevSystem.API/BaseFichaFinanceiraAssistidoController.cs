#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseFichaFinanceiraAssistidoController : BaseController
    {
        [HttpGet("datasPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDatas(string cdPlano)
        {
            try
            {
                var quantidadeMesesContraCheque = 500;
                var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                var funcionario = new FuncionarioProxy().BuscarPorMatricula(Matricula);

                return Json(new FichaFinanceiraAssistidoProxy().BuscarDatas(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, Matricula, cdPlano, dtReferencia));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porPlanoReferenciaTipoFolha/{cdPlano}/{referencia}/{cdTipoFolha}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorDataReferencia(string cdPlano, string referencia, string cdTipoFolha)
        {
            try
            {
                var dataReferencia = DateTime.ParseExact(referencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var funcionario = new FuncionarioProxy().BuscarPorMatricula(Matricula);

                return Json(new FichaFinanceiraAssistidoProxy().BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, Matricula, cdPlano, dataReferencia, cdTipoFolha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
