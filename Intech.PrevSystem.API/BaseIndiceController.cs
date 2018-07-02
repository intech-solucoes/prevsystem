#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseIndiceController : BaseController
    {
        [HttpGet("porCodigo/{codigoIndice}")]
        public IActionResult GetPorCodigo(string codigoIndice)
        {
            try
            {
                return Json(new IndiceProxy().BuscarPorCodigo(codigoIndice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ultimoPorCodigo/{codigoIndice}")]
        public IActionResult GetUltimoPorCodigo(string codigoIndice)
        {
            try
            {
                return Json(new IndiceProxy().BuscarUltimoPorCodigo(codigoIndice));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
