#region Usings
using Intech.Lib.Email;
using Intech.Lib.Web;
using Intech.Lib.Web.Entidades;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.Relacionamento)]
    public class RelacionamentoController : BaseController
    {
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]EmailEntidade relacionamentoEntidade)
        {
            try
            {
                var usuario = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                var emailConfig = AppSettings.Get().Email;
                var corpoEmail =
                    $"Nome: {usuario.NOME_ENTID}<br/>" +
                    $"E-mail: {relacionamentoEntidade.Email}<br/>" +
                    $"Mensagem: {relacionamentoEntidade.Mensagem}";
                EnvioEmail.Enviar(emailConfig, emailConfig.EmailRelacionamento, $"PREVES APP - {relacionamentoEntidade.Assunto}", corpoEmail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao enviar e-mail");
            }
        }
    }
}