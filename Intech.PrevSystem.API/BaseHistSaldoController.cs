#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseHistSaldoController : BaseController
    {
        [HttpGet("porPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorPlano(string cdPlano)
        {
            try
            {
                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, cdPlano);
                var histSaldo = new HistSaldoProxy().BuscarPorFundacaoEmpresaPlanoEspecieNumAnoProcesso(CdFundacao, CdEmpresa, cdPlano, 
                                plano.ProcessoBeneficio.CD_ESPECIE, plano.ProcessoBeneficio.NUM_PROCESSO, plano.ProcessoBeneficio.ANO_PROCESSO);

                return Json(histSaldo.First());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}