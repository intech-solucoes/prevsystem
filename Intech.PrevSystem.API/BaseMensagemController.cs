#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseMensagemController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult GetListaMensagens()
        {
            try
            {
                return Json(new MensagemProxy().BuscarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porFundacaoEmpresaPlano/{cdFundacao}/{cdEmpresa}/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult GetPorCodEntid(string cdFundacao, string cdEmpresa, string cdPlano)
        {
            try
            {
                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(cdFundacao, cdEmpresa, Matricula, cdPlano);

                return Json(new MensagemProxy().BuscarPorFundacaoEmpresaPlanoSitPlanoCodEntid(cdFundacao, cdEmpresa, cdPlano, plano.CD_SIT_PLANO, CodEntid));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Criar([FromBody] MensagemEntidade mensagem)
        {
            try
            {
                mensagem.DTA_MENSAGEM = DateTime.Now;
                mensagem.COD_ENTID = new FuncionarioProxy().BuscarPorMatricula(mensagem.NUM_MATRICULA).COD_ENTID;

                new MensagemProxy().Insert(mensagem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
