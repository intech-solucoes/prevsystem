using Intech.Lib.Log.Core;
using Intech.Lib.Log.Entidades;
using Intech.Lib.Web;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult CriarAcesso([FromBody] LogAcessoEntidade logAcesso)
        {
            try
            {
                var config = AppSettings.Get();
                var logger = new Logger(config.ConnectionString, config.ConnectionProvider);
                var oidAcesso = logger.CriarAcesso(logAcesso);

                return Ok(new { OID_ACESSO = oidAcesso });
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{oidAcesso}/{numFuncionalidade}")]
        public IActionResult CriarLog(decimal oidAcesso, decimal numFuncionalidade)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(numFuncionalidade);
                var config = AppSettings.Get();
                var logger = new Logger(config.ConnectionString, config.ConnectionProvider);
                logger.CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
