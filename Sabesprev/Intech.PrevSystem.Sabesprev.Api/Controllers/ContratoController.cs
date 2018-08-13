#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Sabesprev.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.Contrato)]
    public class ContratoController : BaseContratoController
    {
        [HttpGet("sabesprevAtivosPorPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarAtivos(string cdPlano)
        {
            try
            {
                var contratos = new List<ContratoEntidade>();

                if (Pensionista)
                    contratos = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(CdFundacao, CdEmpresa, cdPlano, Inscricao, GrupoFamilia, DMN_SITUACAO_CONTRATO.ATIVO);
                else
                    contratos = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(CdFundacao, CdEmpresa, cdPlano, Inscricao, DMN_SITUACAO_CONTRATO.ATIVO);

                return Json(contratos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sabesprevPorAnoNum/{ano}/{num}")]
        [Authorize("Bearer")]
        public IActionResult BuscarDetalhe(string ano, string num)
        {
            try
            {
                return Json(new ContratoProxySabesprev().BuscarPorFundacaoAnoNumContrato(CdFundacao, ano, num));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}