#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.Funcionario)]
    public class FuncionarioController : BaseFuncionarioController
    {
        [HttpGet("buscarPorCpf")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorCpf()
        {
            try
            {
                return Json(new FuncionarioProxy().BuscarPorCpf(Cpf));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
