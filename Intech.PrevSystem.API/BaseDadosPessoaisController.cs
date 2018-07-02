#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseDadosPessoaisController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Buscar()
        {
            try
            {
                return Json(new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
