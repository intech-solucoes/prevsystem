using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intech.Lib.Log.Core;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Metrus.Negocio.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuicoesController : Controller
    {
        [HttpGet("porCodEntid/{oidAcesso}/{codEntid}")]
        public ActionResult GetPorCodEntid(int oidAcesso, string codEntid)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.CONTRIBUICOES);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                if (funcionario == null)
                    throw new Exception("Participante não encontrado.");

                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA).First();

                var fichaFinanceiraProxy = new FichaFinanceiraProxy();
                
                if (plano.CD_PLANO == "0001")
                {
                    var saldoBasicaParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "9");
                    var saldoTaxaAdm = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "6");

                    var saldoTotal = saldoBasicaParticipante.ValorParticipante + saldoTaxaAdm.ValorParticipante;

                    return Json(new
                    {
                        saldoBasicaParticipante,
                        saldoTaxaAdm,
                        saldoTotal
                    });
                }
                else
                {
                    var saldoEmCotas = 0M;
                    var indicePerfil = 0M;
                    var saldoTotalParticipante = 0M;
                    var saldoTotalPatrocinadora = 0M;
                    SaldoContribuicoesEntidade saldoBasicaParticipante = new SaldoContribuicoesEntidade();
                    SaldoContribuicoesEntidade saldoSuplementarParticipante = new SaldoContribuicoesEntidade();
                    
                    SaldoContribuicoesEntidade saldoBasicaPatrocinadora = new SaldoContribuicoesEntidade();
                    SaldoContribuicoesEntidade saldoSuplementarPatrocinadora = new SaldoContribuicoesEntidade();

                    if (plano.CD_CATEGORIA != "4")
                    {
                        saldoBasicaParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "1");
                        saldoSuplementarParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "11");

                        saldoTotalParticipante = saldoBasicaParticipante.ValorParticipante + saldoSuplementarParticipante.ValorParticipante;

                        saldoBasicaPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "2");
                        saldoSuplementarPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "12");

                        saldoTotalPatrocinadora = saldoBasicaPatrocinadora.ValorPatrocinadora + saldoSuplementarPatrocinadora.ValorPatrocinadora;
                    }
                    else
                    {
                        var processo = new ProcessoBeneficioProxy().BuscarAtivoPorFundacaoEmpresaMatriculaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, plano.CD_PLANO);
                        var histRendas = new HistRendasProxy().BuscarPorFundacaoEmpresaPlanoAnoNumEspecie(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, processo.ANO_PROCESSO, processo.NUM_PROCESSO, processo.CD_ESPECIE);

                        if (histRendas.CD_OPCAO_RECEB == "04" || histRendas.CD_OPCAO_RECEB == "05")
                        {
                            var histSaldo = new HistSaldoProxy().BuscarPorFundacaoEmpresaPlanoEspecieNumAnoProcesso(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, processo.CD_ESPECIE, processo.NUM_PROCESSO, processo.ANO_PROCESSO);
                            
                            var perfil = new PerfilInvestIndiceProxy().BuscarPorFundacaoEmpresaPlanoPerfilInvest(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, plano.CD_PERFIL_INVEST.ToString());
                            var indice = new IndiceProxy().BuscarUltimoPorCodigo(perfil.CD_CT_RP).VALORES.First();

                            saldoEmCotas = processo.SALDO_ATUAL.Value.Arredonda(7);
                            indicePerfil = indice.VALOR_IND.Arredonda(7);

                            saldoTotalParticipante = (saldoEmCotas * indicePerfil).Arredonda(2);
                        }
                        else if (histRendas.CD_OPCAO_RECEB != "01")
                        {
                            saldoBasicaParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "1");
                            saldoSuplementarParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "11");

                            saldoTotalParticipante = saldoBasicaParticipante.ValorParticipante + saldoSuplementarParticipante.ValorParticipante;

                            saldoBasicaPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "2");
                            saldoSuplementarPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "12");

                            saldoTotalPatrocinadora = saldoBasicaPatrocinadora.ValorPatrocinadora + saldoSuplementarPatrocinadora.ValorPatrocinadora;
                        }
                    }

                    var saldoTotal = saldoTotalParticipante + saldoTotalPatrocinadora;

                    // Contribuições individuais
                    var proxyContribuicaoIndividual = new ContribuicaoIndividualProxy();
                    var contribuicoesBasicasParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "20");
                    var contribuicoesSuplementaresParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

                    var contribuicoesBasicasPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "28");
                    var contribuicoesSuplementaresPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

                    var contribuicoesEspeciaisParticipante = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, plano.CD_PLANO, "46", "2");
                    var contribuicoesEspeciaisPatrocinadora = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, plano.CD_PLANO, "34", "1");

                    // Ultimas contribuicoes
                    var contribuicoes = fichaFinanceiraProxy.BuscarUltimaPorFundacaoPlanoInscricao(funcionario.CD_FUNDACAO, plano.CD_PLANO, funcionario.NUM_INSCRICAO);

                    return Json(new
                    {
                        saldoBasicaParticipante,
                        saldoSuplementarParticipante,
                        saldoBasicaPatrocinadora,
                        saldoSuplementarPatrocinadora,
                        saldoEmCotas,
                        indicePerfil,
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