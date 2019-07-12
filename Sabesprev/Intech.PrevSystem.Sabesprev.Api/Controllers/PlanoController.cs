#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.Plano)]
    public class PlanoController : BasePlanoController
    {
        [HttpGet("porFundacaoEmpresaCpfPensionista/{fundacao}/{empresa}/{cpf}")]
        public IActionResult GetPorCpfPensionista(string fundacao, string empresa, string cpf)
        {
            try
            {
                if(Pensionista)
                    return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaCpfPensionista(fundacao, empresa, cpf));
                else
                    return Json(new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaCpf(fundacao, empresa, cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
