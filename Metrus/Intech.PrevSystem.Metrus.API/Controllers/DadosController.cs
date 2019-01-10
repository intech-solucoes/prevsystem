#region Usings
using Intech.Lib.Web;
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : Controller
    {
        [HttpGet("porCodEntid/{codEntid}")]
        public ActionResult GetPorCodEntid(string codEntid)
        {
            try
            {
                var func = new DadosMetrusProxy().BuscarPorCodEntid(codEntid);

                if (func == null)
                    throw new Exception("Participante não encontrado.");

                return Json(func);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCpf/{cpf}/{token}")]
        public async Task<ActionResult> GetPorCpf(string cpf, string token)
        {
            try
            {
                try
                {
                    var config = AppSettings.Get();

                    var client = new HttpClient();
                    var response = await client.GetStringAsync($"{config.Servicos.AutenticacaoGSM}/api/seguranca/validar_token?token=" + token);

                    var jsonResponse = JsonConvert.DeserializeObject<GSMResult>(response);

                    if (!jsonResponse.TokenValido)
                    {
                        return Json(new
                        {
                            Status = jsonResponse.TokenValido
                        });
                    }
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        mensagem = "Ocorreu um erro ao tentar acessar o serviço de autenticação."
                    });
                }

                var func = new FuncionarioProxy().BuscarPrimeiroPorCpf(cpf);

                if (func == null)
                    throw new Exception("Participante não encontrado.");

                return Json(new DadosMetrusProxy().BuscarPorCodEntid(func.COD_ENTID.ToString()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class GSMResult
    {
        public bool TokenValido { get; set; }
    }
}
