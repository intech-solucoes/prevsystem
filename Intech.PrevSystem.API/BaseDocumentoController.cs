#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using Intech.Lib.Email;
using Intech.Lib.Web;
using System.IO;
using System.Collections.Generic;
using System.Linq;
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
                    pastas = new DocumentoPastaProxy().BuscarPorPastaPai(oidPasta),
                    documentos = new DocumentoProxy().BuscarPorPasta(oidPasta),
                    pastaAtual = new DocumentoPastaProxy().BuscarPorChave(oidPasta)
                };

                return Json(listaDocumentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porPlanoPasta/{cdPlano}/{oidPasta}")]
        [Authorize("Bearer")]
        public IActionResult Buscar(string cdPlano, decimal? oidPasta)
        {
            try
            {
                var documentos = new DocumentoProxy().BuscarPorPasta(oidPasta);

                var planosVinculados = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(CdFundacao, CdEmpresa, Matricula);
                var listaDocumentos = new List<DocumentoEntidade>();

                var documentosPlanos = new DocumentoPlanoProxy().Listar();

                foreach (var documento in documentos)
                {
                    if (documentosPlanos.Any(x => x.OID_DOCUMENTO == documento.OID_DOCUMENTO))
                    {
                        if (documentosPlanos.Any(x => planosVinculados.Any(x2 => x2.CD_PLANO == x.CD_PLANO)))
                            listaDocumentos.Add(documento);
                    }
                    else
                    {
                        listaDocumentos.Add(documento);
                    }
                }

                return Json(new
                {
                    pastas = new DocumentoPastaProxy().BuscarPorPastaPai(oidPasta),
                    documentos = listaDocumentos,
                    pastaAtual = new DocumentoPastaProxy().BuscarPorChave(oidPasta)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscarPorOidDocumento/{oidDocumento}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorOidDocumento(decimal oidDocumento)
        {
            try
            {
                var documento = new DocumentoProxy().BuscarPorChave(oidDocumento);
                return Json(new ArquivoUploadProxy().BuscarPorChave(documento.OID_ARQUIVO_UPLOAD));
            } catch (Exception ex)
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
                var oidDocumento = new DocumentoProxy().Inserir(documento);

                if (!string.IsNullOrEmpty(documento.CD_PLANO))
                {
                    new DocumentoPlanoProxy().Inserir(new DocumentoPlanoEntidade
                    {
                        OID_DOCUMENTO = oidDocumento,
                        CD_FUNDACAO = "01",
                        CD_PLANO = documento.CD_PLANO
                    });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{OID_DOCUMENTO}")]
        [Authorize("Bearer")]
        public IActionResult Deletar(decimal OID_DOCUMENTO)
        {
            try
            {
                var arquivoUploadProxy = new ArquivoUploadProxy();
                var documentoProxy = new DocumentoProxy();
                var documentoPlanoProxy = new DocumentoPlanoProxy();
                var documento = documentoProxy.BuscarPorChave(OID_DOCUMENTO);

                documentoPlanoProxy.DeletarPorOidDocumento(documento.OID_DOCUMENTO);

                documentoProxy.Deletar(documento);

                var arquivoUpload = arquivoUploadProxy.BuscarPorChave(documento.OID_ARQUIVO_UPLOAD);
                arquivoUploadProxy.Deletar(arquivoUpload);

                //var webRootPath = HostingEnvironment.WebRootPath;
                var arquivo = Path.Combine(BaseUploadController.DiretorioUpload, arquivoUpload.NOM_ARQUIVO_LOCAL);

                System.IO.File.Delete(arquivo);

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

        [HttpPost("deletarPasta/{OID_DOCUMENTO_PASTA}")]
        [Authorize("Bearer")]
        public IActionResult DeletarPasta(decimal OID_DOCUMENTO_PASTA)
        {
            try
            {
                DeletarPastaRecursivo(OID_DOCUMENTO_PASTA);

                var documentoProxy = new DocumentoProxy();
                var documentoPastaProxy = new DocumentoPastaProxy();

                var pasta = documentoPastaProxy.BuscarPorChave(OID_DOCUMENTO_PASTA);

                documentoPastaProxy.Deletar(pasta);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("download/{OID_DOCUMENTO}")]
        [Authorize("Bearer")]
        public IActionResult Download(decimal OID_DOCUMENTO)
        {
            try
            {
                var documento = new DocumentoProxy().BuscarPorChave(OID_DOCUMENTO);
                var arquivoUpload = new ArquivoUploadProxy().BuscarPorChave(documento.OID_ARQUIVO_UPLOAD);

                var caminhoArquivo = System.IO.Path.Combine(arquivoUpload.NOM_DIRETORIO_LOCAL, arquivoUpload.NOM_ARQUIVO_LOCAL);

                if (!System.IO.File.Exists(caminhoArquivo))
                    throw new Exception("Arquivo não encontrado!");

                var arquivo = new System.IO.FileInfo(caminhoArquivo);
                var file = System.IO.File.OpenRead(caminhoArquivo);
                var mimeType = MimeTypes.GetMimeType(arquivo.Name);

                return File(file, mimeType);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("enviarDocumento/{OID_DOCUMENTO}")]
        [Authorize("Bearer")]
        public IActionResult EnviarDocumento(decimal OID_DOCUMENTO)
        {
            try
            {
                var dados = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                var documento = new DocumentoProxy().BuscarPorChave(OID_DOCUMENTO);
                var arquivoUpload = new ArquivoUploadProxy().BuscarPorChave(documento.OID_ARQUIVO_UPLOAD);

                var caminhoArquivo = Path.Combine(arquivoUpload.NOM_DIRETORIO_LOCAL, arquivoUpload.NOM_ARQUIVO_LOCAL);

                //var arquivo = new System.IO.FileInfo(caminhoArquivo);
                string fileName = caminhoArquivo.ToString();
                string[] nomeArquivo = fileName.Split('\\');
                fileName = nomeArquivo[nomeArquivo.Length - 1];

                //var file = System.IO.File.ReadAllBytes(caminhoArquivo);

                var arquivoStream = System.IO.File.Open(caminhoArquivo, FileMode.Open);
                var ms = new MemoryStream();
                int arquivoBytes;
                var buffer = new byte[4096];
                do
                {
                    arquivoBytes = arquivoStream.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, arquivoBytes);
                } while (arquivoBytes > 0);

                ms.Position = 0;
                arquivoStream.Close();

                var emailConfig = AppSettings.Get().Email;
                EnvioEmail.Enviar(emailConfig, dados.EMAIL_AUX, null, null, "Preves", "", ms, fileName);

                return Json($"Documento enviado com sucesso para o e-mail {dados.EMAIL_AUX}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void DeletarPastaRecursivo(decimal OID_DOCUMENTO_PASTA)
        {
            var documentoProxy = new DocumentoProxy();
            var documentoPastaProxy = new DocumentoPastaProxy();
            var arquivoUploadProxy = new ArquivoUploadProxy();

            // Deleta documentos dentro da pasta
            var documentos = documentoProxy.BuscarPorPasta(OID_DOCUMENTO_PASTA);

            foreach (var documento in documentos)
            {
                documentoProxy.Deletar(documento);

                var arquivoUpload = arquivoUploadProxy.BuscarPorChave(documento.OID_ARQUIVO_UPLOAD);
                arquivoUploadProxy.Deletar(arquivoUpload);
                
                var arquivo = System.IO.Path.Combine(BaseUploadController.DiretorioUpload, arquivoUpload.NOM_ARQUIVO_LOCAL);

                System.IO.File.Delete(arquivo);
            }

            // Deleta pastas dentro da pasta
            var pastas = documentoPastaProxy.BuscarPorPastaPai(OID_DOCUMENTO_PASTA);

            foreach (var pastaItem in pastas)
            {
                DeletarPastaRecursivo(pastaItem.OID_DOCUMENTO_PASTA);
                documentoPastaProxy.Deletar(pastaItem);
            }
        }
    }
}
