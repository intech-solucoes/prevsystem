#region Usings
using Intech.Lib.Web.JWT;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.Usuario)]
    public class UsuarioController : BaseController
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(
            [FromServices] SigningConfigurations signingConfigurations,
            [FromServices] TokenConfigurations tokenConfigurations,
            [FromBody] dynamic user)
        {
            try
            {
                string cpf = user.Cpf.Value;

                var funcionarioProxy = new FuncionarioProxy();

                var pensionista = false;
                string codEntid;
                string seqRecebedor;
                string grupoFamilia;
                var funcionario = funcionarioProxy.BuscarPrimeiroPorCpf(cpf);

                if (funcionario != null)
                {
                    codEntid = funcionario.COD_ENTID.ToString();
                    seqRecebedor = "0";
                    grupoFamilia = "0";
                }
                else
                {
                    var recebedorBeneficio = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf);

                    if (recebedorBeneficio == null)
                        return BadRequest("CPF ou senha incorretos!");

                    codEntid = recebedorBeneficio.COD_ENTID.ToString();
                    funcionario = funcionarioProxy.BuscarPorMatricula(recebedorBeneficio.NUM_MATRICULA);
                    pensionista = true;
                    seqRecebedor = recebedorBeneficio.SEQ_RECEBEDOR.ToString();
                    grupoFamilia = recebedorBeneficio.NUM_SEQ_GR_FAMIL.ToString();
                }

                if (codEntid != null)
                {
                    var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                    var claims = new List<KeyValuePair<string, string>> {
                        new KeyValuePair<string, string>("Cpf", dadosPessoais.CPF_CGC),
                        new KeyValuePair<string, string>("CodEntid", codEntid),
                        new KeyValuePair<string, string>("Matricula", funcionario.NUM_MATRICULA),
                        new KeyValuePair<string, string>("Inscricao", funcionario.NUM_INSCRICAO),
                        new KeyValuePair<string, string>("CdFundacao", funcionario.CD_FUNDACAO),
                        new KeyValuePair<string, string>("CdEmpresa", funcionario.CD_EMPRESA),
                        new KeyValuePair<string, string>("Pensionista", pensionista.ToString()),
                        new KeyValuePair<string, string>("SeqRecebedor", seqRecebedor),
                        new KeyValuePair<string, string>("GrupoFamilia", grupoFamilia)
                    };

                    var token = AuthenticationToken.Generate(signingConfigurations, tokenConfigurations, dadosPessoais.CPF_CGC, claims);

                    return Json(new
                    {
                        token.AccessToken,
                        token.Authenticated,
                        token.Created,
                        token.Expiration,
                        token.Message,
                        pensionista
                    });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
