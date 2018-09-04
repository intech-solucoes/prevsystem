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

        [HttpDelete]
        [Authorize("Bearer")]
        public IActionResult Deletar([FromBody] DocumentoEntidade documento)
        {
            try
            {
                new DocumentoProxy().Deletar(documento);
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

        [HttpDelete("deletarPasta")]
        [Authorize("Bearer")]
        public IActionResult DeletarPasta([FromBody] DocumentoPastaEntidade pasta)
        {
            try
            {
                var documentoProxy = new DocumentoProxy();
                var documentoPastaProxy = new DocumentoPastaProxy();

                // Deleta documentos dentro da pasta
                var documentos = documentoProxy.BuscarPorPasta(pasta.OID_DOCUMENTO_PASTA);

                foreach(var documento in documentos)
                    documentoProxy.Deletar(documento);

                // Deleta pastas dentro da pasta
                var pastas = documentoPastaProxy.BuscarPorPasta(pasta.OID_DOCUMENTO_PASTA);

                foreach (var pastaItem in pastas)
                    documentoPastaProxy.Deletar(pastaItem);

                documentoPastaProxy.Deletar(pasta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
