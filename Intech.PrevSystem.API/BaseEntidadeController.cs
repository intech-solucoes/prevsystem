#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseEntidadeController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
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
