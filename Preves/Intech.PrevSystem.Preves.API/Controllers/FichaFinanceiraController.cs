﻿#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route(RotasApi.FichaFinanceira)]
    public class FichaFinanceiraController : BaseFichaFinanceiraController
    {
        [HttpGet("resumoAnosPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public override IActionResult GetResumoAnosPorPlano(string cdPlano)
        {
            try
            {
                return Json(new FichaFechamentoPrevesProxy().BuscarResumoAnosPorFundacaoEmpresaPlanoInscricao(CdFundacao, CdEmpresa, cdPlano, Inscricao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("resumoMesesPorPlanoAno/{cdPlano}/{anoRef}")]
        [Authorize("Bearer")]
        public override IActionResult GetResumoMesesPorPlanoAno(string cdPlano, string anoRef)
        {
            try
            {
                return Json(new FichaFechamentoPrevesProxy().BuscarResumoMesesPorFundacaoEmpresaPlanoInscricao(CdFundacao, CdEmpresa, cdPlano, Inscricao, anoRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("tiposPorPlanoAnoMes/{cdPlano}/{anoRef}/{mesRef}")]
        [Authorize("Bearer")]
        public override IActionResult GetTiposPorFundacaoPlanoAnoMes(string cdPlano, string anoRef, string mesRef)
        {
            try
            {
                return Json(new FichaFechamentoPrevesProxy().BuscarResumoDetalhesPorFundacaoEmpresaPlanoInscricao(CdFundacao, CdEmpresa, cdPlano, Inscricao, anoRef, mesRef));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("datasPorFundacaoInscricao/{cdFundacao}/{inscricao}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDatasInformePorFundacaoInscricao(string cdFundacao, string inscricao)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarDatasInformePorFundacaoInscricao(cdFundacao, inscricao));
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("informePorFundacaInscricaoAno/{cdFundacao}/{inscricao}/{ano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarInformePorFundacaoInscricaoAno(string cdFundacao, string inscricao, string ano)
        {
            try
            {
                return Json(new FichaFinanceiraProxy().BuscarInformePorFundacaoInscricaoAno(cdFundacao, inscricao, ano));
            } catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
