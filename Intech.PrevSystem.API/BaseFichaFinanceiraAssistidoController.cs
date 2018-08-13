#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseFichaFinanceiraAssistidoController : BaseController
    {
        [HttpGet("datasPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDatas(string cdPlano)
        {
            try
            {
                var quantidadeMesesContraCheque = 18;
                var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                List<FichaFinanceiraAssistidoEntidade> datas;

                if (Pensionista)
                    datas = new FichaFinanceiraAssistidoProxy().BuscarDatasPorRecebedor(CdFundacao, CdEmpresa, Matricula, SeqRecebedor, cdPlano, dtReferencia).ToList();
                else
                    datas = new FichaFinanceiraAssistidoProxy().BuscarDatas(CdFundacao, CdEmpresa, Matricula, cdPlano, dtReferencia).ToList();

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

        [HttpGet("porPlanoReferenciaTipoFolha/{cdPlano}/{referencia}/{cdTipoFolha}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorDataReferencia(string cdPlano, string referencia, string cdTipoFolha)
        {
            try
            {
                var dataReferencia = DateTime.ParseExact(referencia, "dd.MM.yyyy", new CultureInfo("pt-BR"));

                dynamic rubricas;

                if (Pensionista)
                    rubricas = new FichaFinanceiraAssistidoProxy().BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(CdFundacao, CdEmpresa, Matricula, cdPlano, dataReferencia, cdTipoFolha, SeqRecebedor);
                else
                    rubricas = new FichaFinanceiraAssistidoProxy().BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(CdFundacao, CdEmpresa, Matricula, cdPlano, dataReferencia, cdTipoFolha);

                return Json(rubricas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
