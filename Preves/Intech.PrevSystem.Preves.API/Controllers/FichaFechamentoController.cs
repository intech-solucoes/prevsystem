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
                var fichaFechamento = new FichaFechamentoPrevesProxy().BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipo(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_TIPO_FICHA_FECHAMENTO_PREVES.ANALITICO);
                var empresaPlano = new EmpresaPlanosProxy().BuscarPorFundacaoEmpresaPlano(CdFundacao, CdEmpresa, cdPlano);
                var indice = new IndiceValoresProxy().BuscarUltimoPorCodigo(empresaPlano.IND_RESERVA_POUP).First();

                return Json(new
                {
                    Cotas = fichaFechamento.QTE_COTA_ACUM,
                    DataIndice = indice.DT_IND,
                    ValorIndice = indice.VALOR_IND,
                    Saldo = fichaFechamento.QTE_COTA_ACUM * indice.VALOR_IND
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}