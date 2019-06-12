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
        [HttpGet("todos")]
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

        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                return Json(new PlanoVinculadoProxy().BuscarPorFundacaoMatricula(CdFundacao, Matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodigo/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetPorCodigo(string cdPlano)
        {
            try
            {
                return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, cdPlano));
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
