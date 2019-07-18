#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseFuncionarioController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Buscar()
        {
            try
            {
                //if(Pensionista)
                //    return Json(new FuncionarioProxy().BuscarDadosPorCodEntidPensionista(CodEntid, CodEntidFuncionario));
                //else
                    return Json(new FuncionarioProxy().BuscarDadosPorCodEntid(CodEntid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
