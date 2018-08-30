#region Usings
using Intech.Lib.Util.Seguranca;
using Intech.Lib.Web.JWT;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                if (CodEntid != null)
                    return Ok();

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations, 
            [FromBody] dynamic login)
        {
            try
            {
                var senha = login.Senha.Value;

                var usuario = new UsuarioProxy().BuscarPorCpf(login.Cpf.Value);

                if (usuario == null)
                    usuario = new SegUsuarioProxy().Migrar(login.Cpf.Value, senha);

                if(usuario == null || usuario.PWD_USUARIO.ToUpper() != Criptografia.Encriptar(senha).ToUpper())
                    throw new Exception("Matrícula ou senha incorretos!");

                if (usuario != null)
                {
                    var funcionario = new FuncionarioProxy().BuscarPrimeiroPorCpf((string)login.Cpf.Value);

                    var claims = new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("CodEntid", funcionario.COD_ENTID.ToString()),
                        new KeyValuePair<string, string>("CdFundacao", funcionario.CD_FUNDACAO),
                        new KeyValuePair<string, string>("CdEmpresa", funcionario.CD_EMPRESA),
                        new KeyValuePair<string, string>("Cpf", usuario.NOM_LOGIN),
                        new KeyValuePair<string, string>("Matricula", funcionario.NUM_MATRICULA),
                        new KeyValuePair<string, string>("Inscricao", funcionario.NUM_INSCRICAO),
                        new KeyValuePair<string, string>("Admin", usuario.IND_ADMINISTRADOR)
                    };

                    return Json(new
                    {
                        AccessToken = AuthenticationToken.Generate(signingConfigurations, tokenConfigurations, usuario.NOM_LOGIN, claims).AccessToken,
                        Admin = usuario.IND_ADMINISTRADOR
                    });
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criarAcesso")]
        [AllowAnonymous]
        public IActionResult CriarAcesso([FromBody] dynamic data)
        {
            try
            {
                string cpf = data.Cpf.Value;
                DateTime dataNascimento = data.DataNascimento.Value;

                return Json(new UsuarioProxy().CriarAcesso(cpf, dataNascimento));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("alterarSenha")]
        [Authorize("Bearer")]
        public IActionResult AlterarSenha([FromBody] dynamic data)
        {
            try
            {
                string senhaAntiga = data.senhaAntiga.Value;
                string senhaNova = data.senhaNova.Value;

                return Json(new UsuarioProxy().AlterarSenha(Cpf, senhaAntiga, senhaNova));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
