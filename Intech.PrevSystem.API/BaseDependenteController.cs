#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseDependenteController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);
                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, Matricula).First();

                return Json(new DependenteProxy().BuscarPorFundacaoInscricaoPlano(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, plano.CD_PLANO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
