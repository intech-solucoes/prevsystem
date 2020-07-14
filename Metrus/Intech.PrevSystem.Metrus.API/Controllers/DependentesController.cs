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
        [HttpGet("porInscricao/{numInscricao}")]
        public ActionResult BuscarPorCodEntid(string numInscricao)
        {
            try
            {
                var deps = new DependenteProxy().BuscarPorFundacaoInscricao("01", numInscricao).ToList();

                return Ok(deps);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porInscricaoCpf/{numInscricao}/{cpf}")]
        public ActionResult BuscarPorCodEntid(string numInscricao, string cpf)
        {
            try
            {
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