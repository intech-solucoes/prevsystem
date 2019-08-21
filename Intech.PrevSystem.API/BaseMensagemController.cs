#region Usings
using Intech.Lib.Email;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("porPlano/{cdPlano}")]
        [Authorize("Bearer")]
        public IActionResult BuscarPorPlano(string cdPlano)
        {
            try
            {
                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, cdPlano);

                return Json(new MensagemProxy().BuscarPorFundacaoEmpresaPlanoSitPlanoCodEntid(CdFundacao, CdEmpresa, cdPlano, plano.CD_SIT_PLANO, CodEntid));
            } catch(Exception ex)
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
                var funcionarioProxy = new FuncionarioProxy();
                
                mensagem.CD_EMPRESA = mensagem.CD_EMPRESA == string.Empty ? null : mensagem.CD_EMPRESA;
                mensagem.CD_PLANO = mensagem.CD_PLANO == string.Empty ? null : mensagem.CD_PLANO;
                mensagem.CD_SIT_PLANO = mensagem.CD_SIT_PLANO == string.Empty ? null : mensagem.CD_SIT_PLANO;
                mensagem.NUM_MATRICULA = mensagem.NUM_MATRICULA.Replace("_", "").PadLeft(9, '0');

                if (!mensagem.DTA_EXPIRACAO.HasValue)
                    mensagem.DTA_EXPIRACAO = null;
                else
                    mensagem.DTA_EXPIRACAO = mensagem.DTA_EXPIRACAO;

                if (string.IsNullOrEmpty(mensagem.NUM_MATRICULA))
                    mensagem.COD_ENTID = null;
                else
                    mensagem.COD_ENTID = funcionarioProxy.BuscarPorMatricula(mensagem.NUM_MATRICULA).COD_ENTID;

                mensagem.DTA_MENSAGEM = DateTime.Now;

                // Se opção de enviar e-mail for habilitada
                if (mensagem.IND_EMAIL == DMN_SIM_NAO.SIM)
                {
                    var listaDestinatarios = funcionarioProxy.BuscarPorPesquisa(mensagem.CD_FUNDACAO, mensagem.CD_EMPRESA, mensagem.CD_PLANO, mensagem.CD_SIT_PLANO, mensagem.NUM_MATRICULA, string.Empty);

                    foreach (var destinatario in listaDestinatarios)
                    {
                        var dadosDestinatario = funcionarioProxy.BuscarDadosPorCodEntid(destinatario.COD_ENTID.ToString());
                        EnviarEmail(dadosDestinatario, mensagem);
                    }
                }

                new MensagemProxy().Insert(mensagem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public void EnviarEmail(FuncionarioDados destinatario, MensagemEntidade mensagem)
        {
            if (string.IsNullOrEmpty(destinatario.DadosPessoais.EMAIL_AUX))
                throw new Exception("Não existe email cadastrado para seu usuário contacte o administrador do sistema.");

            try
            {
                var emailConfig = AppSettings.Get().Email;
                EnvioEmail.EnviarMailKit(emailConfig, destinatario.DadosPessoais.EMAIL_AUX, mensagem.TXT_TITULO, mensagem.TXT_CORPO);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao enviar o token por email. Contacte o administrador do sistema." + e.Message);
            }
        }
    }
}
