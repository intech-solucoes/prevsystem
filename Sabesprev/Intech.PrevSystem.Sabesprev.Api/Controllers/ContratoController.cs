using Intech.PrevSystem.Negocio.Sabesprev.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class ContratoController : Controller
    {
        [HttpGet("porFundacaoEmpresaPlanoInscricaoSituacao/{cdFundacao}/{cdEmpresa}/{cdPlano}/{numInscricao}/{cdSituacao}")]
        public IActionResult Index(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdSituacao)
        {
            try
            {
                return Json(new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(cdFundacao, cdEmpresa, cdPlano, numInscricao, cdSituacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao/{cdFundacao}/{cdEmpresa}/{cdPlano}/{numInscricao}/{grupoFamilia}/{cdSituacao}")]
        public IActionResult Index(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string grupoFamilia, string cdSituacao)
        {
            try
            {
                return Json(new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(cdFundacao, cdEmpresa, cdPlano, numInscricao, grupoFamilia, cdSituacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}