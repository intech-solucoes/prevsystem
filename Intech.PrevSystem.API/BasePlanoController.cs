#region Usings
using Intech.Lib.Web.JWT;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BasePlanoController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetLista()
        {
            try
            {
                return Json(new PlanoProxy().BuscarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresa/{cdFundacao}/{cdEmpresa}")]
        [Authorize("Bearer")]
        public IActionResult GetPorFundacaoEmpresa(string cdFundacao, string cdEmpresa)
        {
            try
            {
                return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(cdFundacao, cdEmpresa, Matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaPlano/{cdFundacao}/{cdEmpresa}/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetPorFundacaoEmpresaPlano(string cdFundacao, string cdEmpresa, string cdPlano)
        {
            try
            {
                return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(cdFundacao, cdEmpresa, Matricula, cdPlano));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porEmpresa/{cdEmpresa}")]
        [Authorize("Bearer")]
        public IActionResult GetPlano(string cdEmpresa)
        {
            try
            {
                return Json(new PlanoProxy().BuscarPorEmpresa(cdEmpresa));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
