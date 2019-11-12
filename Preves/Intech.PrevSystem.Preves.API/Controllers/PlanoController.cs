#region Usings
using ICSharpCode.SharpZipLib.Zip;
using Intech.Lib.Email;
using Intech.Lib.Web;
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.Plano)]
    public class PlanoController : BasePlanoController
    {
        [HttpGet("relatorioExtratoPorPlanoEmpresaReferencia/{cdPlano}/{cdEmpresa}/{dtInicio}/{dtFim}/{enviarPorEmail}")]
        [Authorize("Bearer")]
        public IActionResult GetRelatorioExtratoPorPlanoEmpresaReferencia(string cdPlano, string cdEmpresa, string dtInicio, string dtFim, bool enviarPorEmail)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorMatriculaEmpresa(Matricula, cdEmpresa);

                var dataInicio = DateTime.ParseExact(dtInicio, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var dataFim = DateTime.ParseExact(dtFim, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                var relatorio = new Relatorios.RelatorioExtratoContribuicao();
                relatorio.GerarRelatorio(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, Matricula, dataInicio, dataFim);

                using (MemoryStream ms = new MemoryStream())
                {
                    relatorio.ExportToPdf(ms);

                    // Clona stream pois o método ExportToPdf fecha a atual
                    var pdfStream = new MemoryStream();
                    pdfStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    pdfStream.Position = 0;

                    var filename = $"ExtratoContribuicoes_{Guid.NewGuid().ToString()}.pdf";

                    if (enviarPorEmail)
                    {
                        var dados = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                        var emailConfig = AppSettings.Get().Email;
                        EnvioEmail.Enviar(emailConfig, dados.EMAIL_AUX, "Extrato de Contribuições", "", pdfStream, filename);

                        return Json($"Extrato enviado com sucesso para o e-mail {dados.EMAIL_AUX}");
                    }
                    else
                    {
                        return File(pdfStream, "application/pdf", filename);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("certificado/{cdPlano}/{cdEmpresa}/{enviarPorEmail}")]
        [Authorize("Bearer")]
        public IActionResult GetCertificado(string cdPlano, string cdEmpresa, bool enviarPorEmail)
        {
            try
            {
                var relatorio = new Relatorios.CertificadoDeRegistroNoPlano();
                relatorio.GerarRelatorio(Matricula, cdPlano, cdEmpresa);

                using (MemoryStream ms = new MemoryStream())
                {
                    relatorio.ExportToPdf(ms);

                    // Clona stream pois o método ExportToPdf fecha a atual
                    var pdfStream = new MemoryStream();
                    pdfStream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    pdfStream.Position = 0;

                    var filename = $"Certificado de Participacao.pdf";

                    if (enviarPorEmail)
                    {
                        var dados = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                        var emailConfig = AppSettings.Get().Email;
                        EnvioEmail.Enviar(emailConfig, dados.EMAIL_AUX, "Certificado de Participação", "", pdfStream, filename);

                        return Json($"Certificado enviado com sucesso para o e-mail {dados.EMAIL_AUX}");
                    }
                    else
                    {
                        return File(pdfStream, "application/pdf", filename);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("possuiCertificadoSeguro")]
        [Authorize("Bearer")]
        public IActionResult GetPossuiCertificadoSeguro()
        {
            try
            {
                var dados = new DadosPessoaisProxy().BuscarDadosPorCodEntid(CodEntid);
                var certificado = Directory.EnumerateFiles("Certificados").FirstOrDefault(x => x.Contains(dados.dadosPessoais.CPF_CGC));
                
                return Json(certificado != null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("certificadoSeguro/{enviarPorEmail}")]
        [Authorize("Bearer")]
        public IActionResult GetCertificadoSeguro(bool enviarPorEmail)
        {
            try
            {
                var dados = new DadosPessoaisProxy().BuscarDadosPorCodEntid(CodEntid);

                var filename = $"Certificado de Seguro.zip";

                var certificados = Directory.EnumerateFiles("Certificados").Where(x => x.Contains(dados.dadosPessoais.CPF_CGC)).ToList();

                var nomeZip = Path.Combine("Certificados", Guid.NewGuid().ToString()) + ".zip";

                using (Stream stream = System.IO.File.Create(nomeZip))
                {
                    var zipStream = new ZipOutputStream(stream);
                    zipStream.SetLevel(5);

                    foreach (var cert in certificados)
                    {
                        string caminhoRelativoArquivo = Path.GetFileName(cert);

                        var entry = new ZipEntry(caminhoRelativoArquivo)
                        {
                            DateTime = DateTime.Now
                        };
                        zipStream.PutNextEntry(entry);

                        using (FileStream fs = System.IO.File.OpenRead(cert))
                        {
                            int sourceBytes;
                            var buffer = new byte[4096];
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                zipStream.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    zipStream.Finish();
                    zipStream.Close();
                    stream.Close();
                }

                var arquivoStream = System.IO.File.Open(nomeZip, FileMode.Open);
                // Clona stream pra matar o arquivo existente
                //var ms = new MemoryStream();
                //arquivoStream.CopyTo(ms);
                //arquivoStream.Close();
                //ms.Position = 0;
                var ms = new MemoryStream();
                int arquivoBytes;
                var buffer2 = new byte[4096];
                do
                {
                    arquivoBytes = arquivoStream.Read(buffer2, 0, buffer2.Length);
                    ms.Write(buffer2, 0, arquivoBytes);
                } while (arquivoBytes > 0);

                ms.Position = 0;
                arquivoStream.Close();
                System.IO.File.Delete(nomeZip);

                if (enviarPorEmail)
                {
                    var emailConfig = AppSettings.Get().Email;
                    EnvioEmail.Enviar(emailConfig, dados.dadosPessoais.EMAIL_AUX, "Certificado de Seguro", "", ms, filename);

                    return Json($"Certificado enviado com sucesso para o e-mail {dados.dadosPessoais.EMAIL_AUX}");
                }
                else
                {
                    return File(ms, "application/zip", filename);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
