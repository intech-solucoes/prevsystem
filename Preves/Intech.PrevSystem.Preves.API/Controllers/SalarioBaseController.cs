#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.SalarioBase)]
    public class SalarioBaseController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get(string cdPlano)
        {
            try
            {
                return Json(new SalarioBaseProxy().BuscarUltimoPorFundacaoEmpresaMatricula(CdFundacao, CdEmpresa, Matricula));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}