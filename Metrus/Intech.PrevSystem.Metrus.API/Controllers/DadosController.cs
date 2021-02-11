#region Usings
using Dapper;
using Intech.Lib.Dapper;
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
                var dados = new FuncionarioProxy().BuscarPorCpf(cpf).FirstOrDefault();

                if(dados == null)
                {
                    var recebedor = new RecebedorBeneficioProxy().BuscarPensionistaPorCpf(cpf).FirstOrDefault();

                    if (recebedor == null)
                        throw new Exception("Participante/Pensionista não encontrado!");

                    var dadosPensionista = new DadosPessoaisProxy().BuscarPorCodEntid(recebedor.COD_ENTID.ToString());

                    return Ok(new
                    {
                        dadosPensionista.CPF_CGC,
                        recebedor.NUM_MATRICULA,
                        recebedor.NUM_INSCRICAO,
                        recebedor.COD_ENTID,
                        recebedor.CD_EMPRESA
                    });
                }

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

        [HttpPost("[action]")]
        public ActionResult BuscaAmpliada(Pesquisa pesquisa)
        {
            try
            {
                var conexao = BaseDAO.CriarConexao();

                string empresa = null;
                string matricula = null;

                if (!string.IsNullOrEmpty(pesquisa.EmpresaMatricula))
                {
                    empresa = pesquisa.EmpresaMatricula.Substring(0, 4);
                    matricula = pesquisa.EmpresaMatricula.Substring(4, 9);
                }

                var resultadoPesquisa = conexao.Query<ResultadoPesquisa>(
                    "SELECT      ENT.COD_ENTID AS COD_ENTID,     FUNC.NUM_INSCRICAO AS INSCRICAO,     ENT.NOME_ENTID AS NOME,     DADOS.EMAIL_AUX AS EMAIL,     DADOS.DT_NASCIMENTO,     DADOS.FONE_CELULAR,     ENT.FONE_ENTID AS FONE_FIXO,     EMPRESA.CD_EMPRESA,     ENT_EMPRESA.NOME_ENTID AS NOME_EMPRESA,     ENT.CPF_CGC AS CPF FROM EE_ENTIDADE ENT INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.COD_ENTID = ENT.COD_ENTID INNER JOIN CS_DADOS_PESSOAIS DADOS ON DADOS.COD_ENTID = ENT.COD_ENTID INNER JOIN TB_EMPRESA EMPRESA ON EMPRESA.CD_EMPRESA = FUNC.CD_EMPRESA INNER JOIN EE_ENTIDADE ENT_EMPRESA ON ENT_EMPRESA.COD_ENTID = EMPRESA.COD_ENTID WHERE (ENT.NOME_ENTID LIKE '%' || :NOME || '%' OR :NOME IS NULL)   AND (DADOS.EMAIL_AUX = :EMAIL OR :EMAIL IS NULL)   AND (DADOS.DT_NASCIMENTO = :DT_NASCIMENTO OR :DT_NASCIMENTO IS NULL)   AND (DADOS.FONE_CELULAR = :CELULAR OR :CELULAR IS NULL)   AND (ENT.FONE_ENTID = :FIXO OR :FIXO IS NULL)   AND (FUNC.CD_EMPRESA = :EMPRESA OR :EMPRESA IS NULL)   AND (FUNC.NUM_MATRICULA = :MATRICULA OR :MATRICULA IS NULL) ORDER BY COD_ENTID",
                    new { 
                        NOME = pesquisa.Nome,
                        EMAIL = pesquisa.Email,
                        DT_NASCIMENTO = pesquisa.DataNascimento,
                        CELULAR = pesquisa.FoneCelular,
                        FIXO = pesquisa.FoneFixo,
                        EMPRESA = empresa,
                        MATRICULA = matricula
                    });

                return Json(resultadoPesquisa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class Pesquisa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string FoneCelular { get; set; }
        public string FoneFixo { get; set; }
        public string EmpresaMatricula { get; set; }
    }

    public class ResultadoPesquisa
    {
        public string COD_ENTID { get; set; }
        public string INSCRICAO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public DateTime DT_NASCIMENTO { get; set; }
        public string FONE_CELULAR { get; set; }
        public string FONE_FIXO { get; set; }
        public string CD_EMPRESA { get; set; }
        public string NOME_EMPRESA { get; set; }
        public string CPF { get; set; }
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
