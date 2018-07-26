#region Usings
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
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

        [HttpGet("porCpf/{cpf}")]
        public ActionResult GetPorCpf(string cpf)
        {
            try
            {
                var func = new FuncionarioProxy().BuscarPorCpf(cpf);

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
}
