using Intech.Lib.Log.Core;
using Intech.PrevSystem.Metrus.Negocio.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentesController : ControllerBase
    {
        [HttpGet("porInscricao/{oidAcesso}/{numInscricao}")]
        public ActionResult BuscarPorinscricao(int oidAcesso, string numInscricao)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.DEPENDENTES_POR_INSCRICAO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                var deps = new DependenteProxy().BuscarPorFundacaoInscricao("01", numInscricao)
                    .Where(x => 
                        x.PLANO_PREVIDENCIAL == "S" ||
                        x.PLANO_ASSISTENCIAL == "S")
                    .ToList();

                return Ok(deps);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porInscricaoCpf/{oidAcesso}/{numInscricao}/{cpf}")]
        public ActionResult BuscarPorInscricaoCpf(int oidAcesso, string numInscricao, string cpf)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.DEPENDENTES_POR_INSCRICAO_CPF);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                cpf = cpf.LimparMascara();

                var func = new DependenteProxy()
                    .BuscarPorFundacaoInscricao("01", numInscricao)
                    .Where(x => x.CPF == cpf)
                    .FirstOrDefault();

                return Ok(func);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}