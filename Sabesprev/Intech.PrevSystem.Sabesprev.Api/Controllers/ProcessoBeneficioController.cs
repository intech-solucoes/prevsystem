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
    public class ProcessoBeneficioController : Controller
    {
        [HttpGet("porFundacaoEmpresaMatriculaPlano/{cdFundacao}/{cdEmpresa}/{cdMatricula}/{cdPlano}")]
        public IActionResult Get(string cdFundacao, string cdEmpresa, string cdMatricula, string cdPlano)
        {
            try
            {
                using (var dao = new ProcessoBeneficioProxy())
                {
                    return Json(dao.BuscarPorFundacaoEmpresaMatriculaPlano(cdFundacao, cdEmpresa, cdMatricula, cdPlano));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
