#region Usings
using Intech.Lib.Log.Core;
using Intech.PrevSystem.Metrus.Negocio.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoRendEmprestimoController : Controller
    {
        [HttpGet("anosPorCodEntid/{oidAcesso}/{codEntid}")]
        public IActionResult GetAnosPorFundacaoInscricao(int oidAcesso, string codEntid)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.INFO_REND_EMPRESTIMO_ANOS);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var dtInformes = new RelIRRFProxy().BuscarAnosPorFundacaoInscricao(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO);

                var listaAnos = new List<int>();

                foreach (var item in dtInformes)
                    listaAnos.Add(item.Year);

                return Json(listaAnos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidAnoCalendario/{oidAcesso}/{codEntid}/{ano}")]
        public IActionResult GetPorFundacaoInscricaoAno(int oidAcesso, string codEntid, int ano)
        {
            var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.INFO_REND_EMPRESTIMO_POR_ANO);
            new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

            var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

            var dtInformes = new RelIRRFProxy().BuscarPorFundacaoInscricaoReferencia(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, new DateTime(ano, 12, 31));

            return Json(dtInformes);
        }
    }
}