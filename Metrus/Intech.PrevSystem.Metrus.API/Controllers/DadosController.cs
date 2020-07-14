﻿#region Usings
using Intech.Lib.Web;
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosController : Controller
    {
        [HttpGet("buscarCodEntidPorCpf/{cpf}")]
        public ActionResult BuscarPorCpf(string cpf)
        {
            try
            {
                var dados = new FuncionarioProxy().BuscarPorCpf(cpf).First();

                return Ok(new
                {
                    dados.CPF_CGC,
                    dados.NUM_MATRICULA,
                    dados.NUM_INSCRICAO,
                    dados.COD_ENTID,
                    dados.CD_EMPRESA
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("buscarCodEntidPorEmpresaMatricula/{empresa}/{matricula}")]
        public ActionResult BuscarPorCpf(string empresa, string matricula)
        {
            try
            {
                var dados = new FuncionarioProxy().BuscarPorMatriculaEmpresa(matricula, empresa);

                return Ok(new
                {
                    dados.CPF_CGC,
                    dados.NUM_MATRICULA,
                    dados.NUM_INSCRICAO,
                    dados.COD_ENTID,
                    dados.CD_EMPRESA
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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

        [HttpPost("porCpf/{cpf}")]
        public async Task<ActionResult> GetPorCpf(string cpf, [FromBody] dynamic dados)
        {
            try
            {
                try
                {
                    var config = AppSettings.Get();

                    var client = new HttpClient();

                    var parametros = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("username", "webservices_intech"),
                        new KeyValuePair<string, string>("password", "intech123@"),
                        new KeyValuePair<string, string>("grant_type", "password")
                    };

                    var req = new HttpRequestMessage(HttpMethod.Post, $"{config.Servicos.AutenticacaoGSM}/app_services/auth.oauth2.svc/token") { Content = new FormUrlEncodedContent(parametros) };
                    var res = await client.SendAsync(req);
                    var tokenAuth = JsonConvert.DeserializeObject<BennerToken>(await res.Content.ReadAsStringAsync());

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenAuth.access_token);

                    var parametrosToken = new
                    {
                        Token = (string)dados.token
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(parametrosToken), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{config.Servicos.AutenticacaoGSM}/api/logintoken/validartoken", content);
                    var jsonResponse = JsonConvert.DeserializeObject<GSMResult>(await response.Content.ReadAsStringAsync());

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
                        mensagem = $"Ocorreu um erro ao tentar acessar o serviço de autenticação."
                    });
                }

                var func = new FuncionarioProxy().BuscarPrimeiroPorCpf(cpf).FirstOrDefault();

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

    public class BennerToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string username { get; set; }
    }
}
