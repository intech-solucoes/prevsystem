#region Usings
using Intech.Lib.Log.Core;
using Intech.PrevSystem.Metrus.Negocio.Constantes;
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
        [HttpGet("datasPorCodEntid/{oidAcesso}/{codEntid}")]
        public IActionResult BuscarDatas(int oidAcesso, string codEntid)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.INFO_REND_DATAS);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);

                return Json(new HeaderInfoRendProxy().BuscarReferenciasPorCPF(dadosPessoais.CPF_CGC));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidAnoReferencia/{oidAcesso}/{codEntid}/{referencia}")]
        public IActionResult BuscarPorReferencia(int oidAcesso, string codEntid, decimal referencia)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.INFO_REND_POR_ANO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

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