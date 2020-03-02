#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseInfoRendController : BaseController
    {
        [HttpGet("referencias")]
        [Authorize("Bearer")]
        public IActionResult BuscarReferencias()
        {
            try
            {
                return Json(new HeaderInfoRendProxy().BuscarReferenciasPorEmpresaMatricula(CdEmpresa, Matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porReferencia/{referencia}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorReferencia(decimal referencia)
        {
            try
            {
                return Json(new HeaderInfoRendProxy().BuscarPorEmpresaMatriculaReferencia(CdEmpresa, Matricula, referencia));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}