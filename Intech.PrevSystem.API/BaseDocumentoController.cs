#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseDocumentoController : BaseController
    {
        [HttpGet("porPasta/{oidPasta}")]
        [Authorize("Bearer")]
        public IActionResult Buscar(decimal? oidPasta)
        {
            try
            {
                var listaDocumentos = new
                {
                    pastas = new DocumentoPastaProxy().BuscarPorPasta(oidPasta),
                    documentos = new DocumentoProxy().BuscarPorPasta(oidPasta)
                };

                return Json(listaDocumentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Criar([FromBody] DocumentoEntidade documento)
        {
            try
            {
                new DocumentoProxy().Inserir(documento);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("criarPasta")]
        [Authorize("Bearer")]
        public IActionResult Criar([FromBody] DocumentoPastaEntidade pasta)
        {
            try
            {
                new DocumentoPastaProxy().Inserir(pasta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
