#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class InfoRendController : Controller
    {
        [HttpGet("referenciasPorCpf/{cpf}")]
        public IActionResult BuscarReferenciasPorCPF(string cpf)
        {
            try
            {
                return Json(new HeaderInfoRendProxy().BuscarReferenciasPorCPF(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("porCpfReferencia/{cpf}/{referencia}")]
        public IActionResult BuscarReferenciasPorCPF(string cpf, decimal referencia)
        {
            try
            {
                return Json(new HeaderInfoRendProxy().BuscarPorCpfReferencia(cpf, referencia));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}