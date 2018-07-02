#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecebedorBeneficioController : Controller
    {
        [HttpGet("pensionistaPorCpf/{cpf}")]
        public IActionResult GetPensionistaPorCpf(string cpf)
        {
            try
            {
                return Json(new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}