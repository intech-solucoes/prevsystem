#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class PlanoVinculadoController : Controller
    {
        [HttpGet("porFundacaoEmpresaMatricula/{fundacao}/{empresa}/{matricula}")]
        public IActionResult Get(string fundacao, string empresa, string matricula)
        {
            try
            {
                using (var dao = new PlanoVinculadoProxy())
                {
                    return Json(dao.BuscarPorFundacaoEmpresaMatricula(fundacao, empresa, matricula));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaCpf/{fundacao}/{empresa}/{cpf}")]
        public IActionResult GetPorCpf(string fundacao, string empresa, string cpf)
        {
            try
            {
                using (var dao = new PlanoVinculadoProxy())
                {
                    return Json(dao.BuscarPorFundacaoEmpresaCpf(fundacao, empresa, cpf));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaCpfPensionista/{fundacao}/{empresa}/{cpf}")]
        public IActionResult GetPorCpfPensionista(string fundacao, string empresa, string cpf)
        {
            try
            {
                using (var dao = new PlanoVinculadoProxy())
                {
                    return Json(dao.BuscarPorFundacaoEmpresaCpfPensionista(fundacao, empresa, cpf));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
