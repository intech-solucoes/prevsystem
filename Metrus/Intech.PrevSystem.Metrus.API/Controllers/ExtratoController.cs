using Microsoft.AspNetCore.Mvc;
using System;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : Controller
    {
        public IActionResult Get()
        {
            try
            {
                return Json("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}