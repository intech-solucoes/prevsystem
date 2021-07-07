using Intech.Lib.Log.Core;
using Intech.Lib.Log.Entidades;
using Intech.Lib.Web;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpPost("[action]")]
        [Authorize("Bearer")]
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
        [Authorize("Bearer")]
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

        [HttpGet("[action]/{cpf}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCPF(string cpf)
        {
            try
            {
                var config = AppSettings.Get();
                var logger = new Logger(config.ConnectionString, config.ConnectionProvider);
                var logs = logger.BuscarPorCpf(cpf);

                return Ok(logs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{numFuncionalidade}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorNumFuncionalidade(int numFuncionalidade)
        {
            try
            {
                var config = AppSettings.Get();
                var logger = new Logger(config.ConnectionString, config.ConnectionProvider);
                var logs = logger.BuscarPorNumFuncionalidade(numFuncionalidade);

                return Ok(logs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class AutenticacaoLogEntidade
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
