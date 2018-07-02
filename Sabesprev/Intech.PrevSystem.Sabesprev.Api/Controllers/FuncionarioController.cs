#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class FuncionarioController : Controller
    {
        [HttpGet("porCpf/{cpf}")]
        public IActionResult GetPorCpf(string cpf)
        {
            try
            {
                return Json(new FuncionarioProxy().BuscarPorCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porMatricula/{matricula}")]
        public IActionResult GetPorMatricula(string matricula)
        {
            try
            {
                return Json(new FuncionarioProxy().BuscarPorMatricula(matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
