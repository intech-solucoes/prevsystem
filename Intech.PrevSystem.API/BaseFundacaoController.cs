#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseFundacaoController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult BuscarTodos(string cdFundacao)
        {
            try
            {
                return Json(new FundacaoProxy().BuscarPorCodigo(cdFundacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
