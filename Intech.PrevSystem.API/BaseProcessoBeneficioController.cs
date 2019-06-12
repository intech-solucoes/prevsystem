#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseProcessoBeneficioController : BaseController
    {
        [HttpGet("porPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetPorPlano(string cdPlano)
        {
            try
            {
                if(cdPlano == "0002")
                    return Json(new ProcessoBeneficioProxy().BuscarPorFundacaoEmpresaInscricaoPlano(CdFundacao, CdEmpresa, Inscricao, "0002"));
                else
                    return Json(new ProcessoBeneficioProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, "0001"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
