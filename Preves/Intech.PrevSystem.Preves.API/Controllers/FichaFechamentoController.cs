#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.FichaFechamento)]
    public class FichaFechamentoController : BaseController
    {
        [HttpGet("porPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult Get(string cdPlano)
        {
            try
            {
                var fichaFechamentoProxy = new FichaFechamentoPrevesProxy();

                var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(CdFundacao, CdEmpresa, cdPlano);
                var indice = new IndiceValoresProxy().BuscarUltimoPorCodigo(empresaPlano.IND_RESERVA_POUP).First();

                var fichaFechamentoPartic = fichaFechamentoProxy.BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO, DMN_SN.SIM);
                var fichaFechamentoPatroc = fichaFechamentoProxy.BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO, DMN_SN.NAO);

                Saldo saldo;

                if(fichaFechamentoPatroc == null)
                {
                    saldo = new Saldo {
                        CotasPartic = fichaFechamentoPartic.QTE_COTA_ACUM.Value,
                        SaldoPartic = fichaFechamentoPartic.QTE_COTA_ACUM.Value * indice.VALOR_IND,
                        DataIndice = indice.DT_IND,
                        ValorIndice = indice.VALOR_IND
                    };
                }
                else
                {
                    var saldoPartic = fichaFechamentoPartic.QTE_COTA_ACUM.Value * indice.VALOR_IND;
                    var saldoPatroc = fichaFechamentoPatroc.QTE_COTA_ACUM.Value * indice.VALOR_IND;

                    saldo = new Saldo
                    {
                        CotasPartic = fichaFechamentoPartic.QTE_COTA_ACUM.Value,
                        CotasPatroc = fichaFechamentoPatroc.QTE_COTA_ACUM.Value,
                        SaldoPartic = saldoPartic,
                        SaldoPatroc = saldoPatroc,
                        DataIndice = indice.DT_IND,
                        ValorIndice = indice.VALOR_IND
                    };
                }

                return Json(saldo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class Saldo
    {
        public decimal CotasPartic { get; set; }
        public decimal CotasPatroc { get; set; }
        public DateTime DataIndice { get; set; }
        public decimal ValorIndice { get; set; }
        public decimal SaldoPartic { get; set; }
        public decimal SaldoPatroc { get; set; }

        public decimal Total
        {
            get => SaldoPartic + SaldoPatroc;
        }
    }
}