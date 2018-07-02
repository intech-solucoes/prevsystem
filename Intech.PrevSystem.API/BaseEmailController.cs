#region Usings
using Intech.Lib.Util.Email;
using Intech.Lib.Web;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseEmailController : BaseController
    {
        [HttpPost("enviar")]
        public IActionResult Enviar([FromBody] dynamic data)
        {
            try
            {
                // Envia e-mail com nova senha de acesso
                var emailConfig = AppSettings.Get().Email;
                EnvioEmail.Enviar(emailConfig, data.Destinatario.Value, data.Assunto.Value, data.Corpo.Value);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
