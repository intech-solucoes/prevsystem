#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/[controller]")]
    public class FichaFinanceiraAssistidoController : Controller
    {
        [HttpGet("datas/{cdFundacao}/{cdEmpresa}/{cdMatricula}/{cdPlano}")]
        public IActionResult GetDatas(string cdFundacao, string cdEmpresa, string cdMatricula, string cdPlano)
        {
            try
            {
                var quantidadeMesesContraCheque = 18;
                var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                var datas = new FichaFinanceiraAssistidoProxy().BuscarDatas(cdFundacao, cdEmpresa, cdMatricula, cdPlano, dtReferencia).ToList();

                datas.ForEach(x =>
                {
                    x.IsAbonoAnual = x.CD_TIPO_FOLHA == "3";
                });
                
                return Json(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("datasPorRecebedor/{cdFundacao}/{cdEmpresa}/{cdMatricula}/{cdPlano}/{recebedor}")]
        public IActionResult GetDatasPorRecebedor(string cdFundacao, string cdEmpresa, string cdMatricula, string cdPlano, int recebedor)
        {
            try
            {
                var quantidadeMesesContraCheque = 18;
                var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                var datas = new FichaFinanceiraAssistidoProxy().BuscarDatasPorRecebedor(cdFundacao, cdEmpresa, cdMatricula, recebedor, cdPlano, dtReferencia).ToList();

                datas.ForEach(x =>
                {
                    x.IsAbonoAnual = x.CD_TIPO_FOLHA == "3";
                });

                return Json(datas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaMatriculaPlanoReferencia/{cdFundacao}/{cdEmpresa}/{cdMatricula}/{cdPlano}/{dtReferencia}/{cdTipoFolha}")]
        public IActionResult GetPorFundacaoEmpresaMatriculaPlanoReferencia(string cdFundacao, string cdEmpresa, string cdMatricula, string cdPlano, string dtReferencia, string cdTipoFolha)
        {
            try
            {
                var referencia = DateTime.ParseExact(dtReferencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                
                return Json(new FichaFinanceiraAssistidoProxy().BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(cdFundacao, cdEmpresa, cdMatricula, cdPlano, referencia, cdTipoFolha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaMatriculaPlanoReferenciaRecebedor/{cdFundacao}/{cdEmpresa}/{cdMatricula}/{cdPlano}/{dtReferencia}/{recebedor}/{cdTipoFolha}")]
        public IActionResult GetPorFundacaoEmpresaMatriculaPlanoReferencia(string cdFundacao, string cdEmpresa, string cdMatricula, string cdPlano, string dtReferencia, int recebedor, string cdTipoFolha)
        {
            try
            {
                var referencia = DateTime.ParseExact(dtReferencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                
                return Json(new FichaFinanceiraAssistidoProxy().BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(cdFundacao, cdEmpresa, cdMatricula, recebedor, cdPlano, referencia, cdTipoFolha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
