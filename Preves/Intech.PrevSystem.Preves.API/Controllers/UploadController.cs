#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http.Headers; 
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile(FileUploadViewModel model)
        {
            try
            {
                var file = model.File;
                string folderName = "Upload";
                string webRootPath = _hostingEnvironment.WebRootPath;
                string newPath = Path.Combine(webRootPath, folderName);

                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                long oidArquivoUpload = 0;

                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var arquivo = new ArquivoUploadEntidade
                    {
                        DTA_UPLOAD = DateTime.Now,
                        IND_STATUS = 2,
                        NOM_ARQUIVO_LOCAL = fileName,
                        NOM_ARQUIVO_ORIGINAL = fileName,
                        NOM_DIRETORIO_LOCAL = "Upload"
                    };
                    
                    oidArquivoUpload = new ArquivoUploadProxy().Inserir(arquivo);
                }

                return Json(oidArquivoUpload);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }
    }

    public class FileUploadViewModel
    {
        public IFormFile File { get; set; }
        public string source { get; set; }
        public long Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Extension { get; set; }
    }
}
