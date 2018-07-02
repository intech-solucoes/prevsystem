#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class EntidadeController : Controller
    {
        [HttpGet("porCodEntid/{codEntid}")]
        public IActionResult GetPorCodEntid(string codEntid)
        {
            try
            {
                return Json(new EntidadeProxy().BuscarPorCodEntid(codEntid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
