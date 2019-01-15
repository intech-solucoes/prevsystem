using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuicoesController : Controller
    {
        [HttpGet("porCodEntid/{codEntid}")]
        public ActionResult GetPorCodEntid(string codEntid)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                var fichaFinanceiraProxy = new FichaFinanceiraProxy();

                var saldoBasicaParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, "0002", funcionario.NUM_INSCRICAO, "1");
                var saldoSuplementarParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, "0002", funcionario.NUM_INSCRICAO, "11");

                var saldoTotalParticipante = saldoBasicaParticipante.ValorParticipante + saldoSuplementarParticipante.ValorParticipante;
                
                var saldoBasicaPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, "0002", funcionario.NUM_INSCRICAO, "2");
                var saldoSuplementarPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, "0002", funcionario.NUM_INSCRICAO, "12");

                var saldoTotalPatrocinadora = saldoBasicaPatrocinadora.ValorPatrocinadora + saldoSuplementarPatrocinadora.ValorPatrocinadora;

                var saldoTotal = saldoTotalParticipante + saldoTotalPatrocinadora;
                
                // Contribuições individuais
                var proxyContribuicaoIndividual = new ContribuicaoIndividualProxy();
                var contribuicoesBasicasParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "20");
                var contribuicoesSuplementaresParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

                var contribuicoesBasicasPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "28");
                var contribuicoesSuplementaresPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

                //var contribuicoesEspeciaisParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "46");
                //var contribuicoesEspeciaisPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "34");

                var contribuicoesEspeciaisParticipante = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, "0002", "46", "2");
                var contribuicoesEspeciaisPatrocinadora = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, "0002", "34", "1");

                // Ultimas contribuicoes
                var contribuicoes = fichaFinanceiraProxy.BuscarUltimaPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, "0002", funcionario.NUM_INSCRICAO);
                
                return Json(new
                {
                    saldoBasicaParticipante,
                    saldoSuplementarParticipante,
                    saldoBasicaPatrocinadora,
                    saldoSuplementarPatrocinadora,
                    saldoTotal,
                    contribuicoesBasicasParticipante = new
                    {
                        Percentual = contribuicoesBasicasParticipante.FirstOrDefault()?.VL_PERC_PAR ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "20")?.CONTRIB_PARTICIPANTE ?? 0
                    },
                    contribuicoesSuplementaresParticipante = new
                    {
                        Percentual = contribuicoesSuplementaresParticipante.FirstOrDefault()?.VL_PERC_PAR ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "24")?.CONTRIB_PARTICIPANTE ?? 0
                    },
                    contribuicoesEspeciaisParticipante = new
                    {
                        Percentual = contribuicoesEspeciaisParticipante.OrderBy(x => x.ANO_REF).ThenBy(x => x.MES_REF).Last()?.PERC_FAIXA ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "46")?.CONTRIB_PARTICIPANTE ?? 0
                    },
                    contribuicoesBasicasPatrocinadora = new
                    {
                        Percentual = contribuicoesBasicasPatrocinadora.FirstOrDefault()?.VL_PERC_EMP ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "28")?.CONTRIB_EMPRESA ?? 0
                    },
                    contribuicoesSuplementaresPatrocinadora = new
                    {
                        Percentual = contribuicoesSuplementaresPatrocinadora.FirstOrDefault()?.VL_PERC_EMP ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "24")?.CONTRIB_EMPRESA ?? 0
                    },
                    contribuicoesEspeciaisPatrocinadora = new
                    {
                        Percentual = contribuicoesEspeciaisPatrocinadora.OrderBy(x => x.ANO_REF).ThenBy(x => x.MES_REF).Last()?.PERC_FAIXA ?? 0,
                        Valor = contribuicoes.SingleOrDefault(x => x.CD_TIPO_CONTRIBUICAO == "34")?.CONTRIB_EMPRESA ?? 0
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
        }
    }
}