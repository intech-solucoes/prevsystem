#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.DadosPessoais)]
    public class DadosPessoaisController : BaseDadosPessoaisController
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
