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
                //var quantidadeMesesContraCheque = 18;
                //var dtReferencia = DateTime.Today.PrimeiroDiaDoMes().AddMonths(-quantidadeMesesContraCheque);

                List<FichaFinanceiraAssistidoEntidade> datas;

                if (Pensionista)
                    datas = new FichaFinanceiraAssistidoProxy().BuscarResumoPorRecebedor(CdFundacao, Inscricao, SeqRecebedor).ToList();
                else
                    datas = new FichaFinanceiraAssistidoProxy().BuscarResumo(CdFundacao, Inscricao).ToList();

                datas.ForEach(x =>
                {
                    x.IsAbonoAnual = x.CD_TIPO_FOLHA == "3";
                });

                var grupo = datas
                    .GroupBy(x => x.DS_ESPECIE)
                    .Select(x => new
                    {
                        DS_ESPECIE = x.Key,
                        Lista = x.ToList()
                    })
                    .ToList();

                return Json(grupo);
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

        [HttpGet("ultimaFolhaPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarUltimaPorPlano(string cdPlano)
        {
            try
            {
                dynamic rubricas;

                if (Pensionista)
                    rubricas = new FichaFinanceiraAssistidoProxy().BuscarUltimaFolhaPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, cdPlano, SeqRecebedor);
                else
                    rubricas = new FichaFinanceiraAssistidoProxy().BuscarUltimaFolhaPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, cdPlano);

                return Json(rubricas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
