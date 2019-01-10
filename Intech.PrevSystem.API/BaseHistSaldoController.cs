#region Usings
using Intech.PrevSystem.Entidades;
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

                var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(CdFundacao, CdEmpresa, cdPlano);
                var indice = new IndiceProxy().BuscarUltimoPorCodigo(empresaPlano.IND_RESERVA_POUP);

                var dataCota = indice.VALORES.First().DT_IND;

                var valorIndice = indice.BuscarValorEm(dataCota);

                var totalCotas = histSaldo.First().SALDO_ATUAL;
                var total = totalCotas * valorIndice;

                return Json(new
                {
                    TotalCotas = totalCotas,
                    Valor = total,
                    Parcela = histSaldo.First().QTD
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}