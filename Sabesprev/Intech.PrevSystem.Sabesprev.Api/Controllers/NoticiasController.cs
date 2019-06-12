using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(new NoticiaSabesprevProxy().Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                return Json(new NoticiaSabesprevProxy().BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class Noticia
    {
        public int ID { get; set; }
        public DateTime DT_PUBLICACAO { get; set; }
        public string INSTITUCIONAL_NOME { get; set; }
        public string INSTITUCIONAL_TEXTO { get; set; }
        public string LINK_PORTAL { get; set; }
    }
}