#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class DadosPessoaisController : Controller
    {
        [HttpGet("porCodEntid/{codEntid}")]
        public IActionResult GetPorCodEntid(string codEntid)
        {
            try
            {
                using (var dao = new DadosPessoaisProxy())
                {
                    return Json(dao.BuscarPorCodEntid(codEntid));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
