using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.API
{
    public class BaseEmpresaController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult BuscarTodos()
        {
            try
            {
                return Json(new EmpresaProxy().BuscarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
