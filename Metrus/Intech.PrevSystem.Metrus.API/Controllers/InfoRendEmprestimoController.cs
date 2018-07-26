#region Usings
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
        [HttpGet("anosPorCodEntid/{codEntid}")]
        public IActionResult GetAnosPorFundacaoInscricao(string codEntid)
        {
            try
            {
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

        [HttpGet("porCodEntidAnoCalendario/{codEntid}/{ano}")]
        public IActionResult GetPorFundacaoInscricaoAno(string codEntid, int ano)
        {
            var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

            var dtInformes = new RelIRRFProxy().BuscarPorFundacaoInscricaoReferencia(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, new DateTime(ano, 12, 31));

            return Json(dtInformes);
        }
    }
}