#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoRendController : Controller
    {
        [HttpGet("datasPorCodEntid/{codEntid}")]
        public IActionResult BuscarDatas(string codEntid)
        {
            try
            {
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                return Json(new HeaderInfoRendProxy().BuscarReferenciasPorCPF(dadosPessoais.CPF_CGC));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidAnoReferencia/{codEntid}/{referencia}")]
        public IActionResult BuscarPorReferencia(string codEntid, decimal referencia)
        {
            try
            {
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
                return Json(new HeaderInfoRendProxy().BuscarPorCpfReferencia(dadosPessoais.CPF_CGC, referencia));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}