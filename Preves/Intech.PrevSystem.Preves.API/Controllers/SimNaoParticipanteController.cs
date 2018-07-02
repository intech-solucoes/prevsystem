#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Preves.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route("api/[controller]")]
    public class SimNaoParticipanteController : BaseController
    {
        [HttpPost("calcular")]
        [AllowAnonymous]
        public IActionResult Enviar([FromBody] dynamic dados)
        {
            try
            {
                return Json(new SimNaoParticipante(dados).BuscarValoresContribuicoes());
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
