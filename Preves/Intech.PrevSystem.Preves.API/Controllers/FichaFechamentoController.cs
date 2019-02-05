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

                if (cdPlano == "0002")
                {
                    var fichaFechamento = fichaFechamentoProxy.BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO, DMN_SN.SIM);

                    return Json(new
                    {
                        Cotas = fichaFechamento.QTE_COTA_ACUM,
                        DataIndice = indice.DT_IND,
                        ValorIndice = indice.VALOR_IND,
                        Saldo = fichaFechamento.QTE_COTA_ACUM * indice.VALOR_IND
                    });
                }
                else
                {
                    var fichaFechamentoPartic = fichaFechamentoProxy.BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO, DMN_SN.SIM);
                    var fichaFechamentoPatroc = fichaFechamentoProxy.BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO, DMN_SN.NAO);

                    var saldoPartic = fichaFechamentoPartic.QTE_COTA_ACUM * indice.VALOR_IND;
                    var saldoPatroc = fichaFechamentoPatroc.QTE_COTA_ACUM * indice.VALOR_IND;

                    return Json(new
                    {
                        CotasPartic = fichaFechamentoPartic.QTE_COTA_ACUM,
                        CotasPatroc = fichaFechamentoPatroc.QTE_COTA_ACUM,
                        DataIndice = indice.DT_IND,
                        ValorIndice = indice.VALOR_IND,
                        SaldoPartic = saldoPartic,
                        SaldoPatroc = saldoPatroc,
                        Total = saldoPartic + saldoPatroc
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}