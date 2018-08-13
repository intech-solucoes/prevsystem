#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FichaFinanceiraProxy : FichaFinanceiraDAO
    {
        public override IEnumerable<FichaFinanceiraEntidade> BuscarResumoAnosPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
        {
            var fichaFinanceira = base.BuscarResumoAnosPorFundacaoPlanoInscricao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO).ToList();

            // Agrupa todas as contribuições por ano
            var grupoFicha = fichaFinanceira
                .GroupBy(x => x.ANO_REF)
                .Select(x => new {
                    ANO_REF = x.Key,
                    Items = x.ToList()
                })
                .ToList();

            // Busca a lista de fundos para filtrar as contribuições
            var listaFundos = new List<FundoContribEntidade>();
            if (CD_PLANO == "0002") // Se for plano Reforço
            {
                var fundoContrib = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "1");
                var fundoContrib2 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "2");
                var fundoContrib3 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "3");

                listaFundos = fundoContrib.Concat(fundoContrib2).Concat(fundoContrib3).ToList();
            }
            else
            {
                listaFundos = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "6").ToList();
            }
            
            // Apura todas as contribuições
            var resumo = new List<FichaFinanceiraEntidade>();
            grupoFicha.ForEach(grupo =>
            {
                var apuracao = new FichaFinanceiraEntidade
                {
                    ANO_REF = grupo.ANO_REF,
                    QTD_COTA_RP_PARTICIPANTE = 0M,
                    QTD_COTA_RP_EMPRESA = 0M,
                    CONTRIB_PARTICIPANTE = 0M,
                    CONTRIB_EMPRESA = 0M
                };
                
                grupo.Items.ForEach(contribuicao =>
                {
                    // Filtra as contribuições por fundo
                    if (listaFundos.Any(fundo => fundo.CD_TIPO_CONTRIBUICAO == contribuicao.CD_TIPO_CONTRIBUICAO))
                    {
                        // Cotas
                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.QTD_COTA_RP_PARTICIPANTE += (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;
                        else
                            apuracao.QTD_COTA_RP_PARTICIPANTE -= (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;

                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.QTD_COTA_RP_EMPRESA += (decimal)contribuicao.QTD_COTA_RP_EMPRESA;
                        else
                            apuracao.QTD_COTA_RP_EMPRESA -= (decimal)contribuicao.QTD_COTA_RP_EMPRESA;

                        // Valores
                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.CONTRIB_PARTICIPANTE += (decimal)contribuicao.CONTRIB_PARTICIPANTE;
                        else
                            apuracao.CONTRIB_PARTICIPANTE -= (decimal)contribuicao.CONTRIB_PARTICIPANTE;

                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.CONTRIB_EMPRESA += (decimal)contribuicao.CONTRIB_EMPRESA;
                        else
                            apuracao.CONTRIB_EMPRESA -= (decimal)contribuicao.CONTRIB_EMPRESA;
                    }
                });

                apuracao.TOTAL_CONTRIB = apuracao.CONTRIB_PARTICIPANTE + apuracao.CONTRIB_EMPRESA;
                apuracao.QTD_COTA = apuracao.QTD_COTA_RP_PARTICIPANTE + apuracao.QTD_COTA_RP_EMPRESA;

                resumo.Add(apuracao);
            });

            return resumo;
        }

        /// <summary>
        /// Busca o resumo das contribuições do ano, onde o mês é exibido por extenso
        /// </summary>
        /// <param name="CD_FUNDACAO"></param>
        /// <param name="CD_PLANO"></param>
        /// <param name="NUM_INSCRICAO"></param>
        /// <param name="ANO_REF"></param>
        /// <returns></returns>
        public override IEnumerable<FichaFinanceiraEntidade> BuscarResumoMesesPorFundacaoPlanoInscricaoAno(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF)
        {
            var fichaFinanceira = base.BuscarResumoMesesPorFundacaoPlanoInscricaoAno(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF).ToList();

            // Agrupa todas as contribuições por ano
            var grupoFicha = fichaFinanceira
                .GroupBy(x => x.MES_REF)
                .Select(x => new {
                    MES_REF = x.Key,
                    Items = x.ToList()
                })
                .ToList();

            // Busca a lista de fundos para filtrar as contribuições
            var listaFundos = new List<FundoContribEntidade>();
            if (CD_PLANO == "0002") // Se for plano Reforço
            {
                var fundoContrib = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "1");
                var fundoContrib2 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "2");
                var fundoContrib3 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "3");

                listaFundos = fundoContrib.Concat(fundoContrib2).Concat(fundoContrib3).ToList();
            }
            else
            {
                listaFundos = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "6").ToList();
            }

            // Apura todas as contribuições
            var resumo = new List<FichaFinanceiraEntidade>();
            grupoFicha.ForEach(grupo =>
            {
                var apuracao = new FichaFinanceiraEntidade
                {
                    MES_REF = grupo.MES_REF,
                    QTD_COTA_RP_PARTICIPANTE = 0M,
                    QTD_COTA_RP_EMPRESA = 0M,
                    CONTRIB_PARTICIPANTE = 0M,
                    CONTRIB_EMPRESA = 0M,
                    DES_MES_REF = DateTimeExtensoes.MesPorExtenso(grupo.MES_REF)
                };

                grupo.Items.ForEach(contribuicao =>
                {
                    // Filtra as contribuições por fundo
                    if (listaFundos.Any(fundo => fundo.CD_TIPO_CONTRIBUICAO == contribuicao.CD_TIPO_CONTRIBUICAO))
                    {
                        // Cotas
                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.QTD_COTA_RP_PARTICIPANTE += (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;
                        else
                            apuracao.QTD_COTA_RP_PARTICIPANTE -= (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;

                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.QTD_COTA_RP_EMPRESA += (decimal)contribuicao.QTD_COTA_RP_EMPRESA;
                        else
                            apuracao.QTD_COTA_RP_EMPRESA -= (decimal)contribuicao.QTD_COTA_RP_EMPRESA;

                        // Valores
                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.CONTRIB_PARTICIPANTE += (decimal)contribuicao.CONTRIB_PARTICIPANTE;
                        else
                            apuracao.CONTRIB_PARTICIPANTE -= (decimal)contribuicao.CONTRIB_PARTICIPANTE;

                        if (contribuicao.CD_OPERACAO == "C")
                            apuracao.CONTRIB_EMPRESA += (decimal)contribuicao.CONTRIB_EMPRESA;
                        else
                            apuracao.CONTRIB_EMPRESA -= (decimal)contribuicao.CONTRIB_EMPRESA;
                    }
                });

                apuracao.TOTAL_CONTRIB = apuracao.CONTRIB_PARTICIPANTE + apuracao.CONTRIB_EMPRESA;
                apuracao.QTD_COTA = apuracao.QTD_COTA_RP_PARTICIPANTE + apuracao.QTD_COTA_RP_EMPRESA;

                resumo.Add(apuracao);
            });

            return resumo;
        }

        public override IEnumerable<FichaFinanceiraEntidade> BuscarTiposPorFundacaoPlanoInscricaoAnoMes(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF, string MES_REF)
        {
            var fichaFinanceira = base.BuscarTiposPorFundacaoPlanoInscricaoAnoMes(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF, MES_REF);

            // Agrupa todas as contribuições por ano
            var grupoFicha = fichaFinanceira
                .GroupBy(x => new {
                    x.DS_TIPO_CONTRIBUICAO,
                    x.CD_TIPO_CONTRIBUICAO
                })
                .Select(x => new {
                    x.Key.CD_TIPO_CONTRIBUICAO,
                    x.Key.DS_TIPO_CONTRIBUICAO,
                    Items = x.ToList()
                })
                .ToList();

            // Apura todas as contribuições
            var resumo = new List<FichaFinanceiraEntidade>();
            grupoFicha.ForEach(grupo =>
            {
                grupo.Items.ForEach(contribuicao =>
                {
                    contribuicao.TOTAL_CONTRIB = contribuicao.CONTRIB_PARTICIPANTE + contribuicao.CONTRIB_EMPRESA;
                    contribuicao.QTD_COTA = contribuicao.QTD_COTA_RP_PARTICIPANTE + contribuicao.QTD_COTA_RP_EMPRESA;
                    resumo.Add(contribuicao);
                });
            });

            return resumo;
        }

        /// <summary>
        /// Busca as contribuições do ultimo mês
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="numInscricao"></param>
        /// <returns></returns>
        public List<FichaFinanceiraEntidade> BuscarUltimaPorFundacaoPlanoInscricao(string cdFundacao, string cdPlano, string numInscricao)
        {
            // Agrupa e seleciona apenas o primeiro registro do agrupamento, que é referente ao ultimo mês
            var lista = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao)
                .GroupBy(x => new { x.ANO_REF, x.MES_REF })
                .Select(x => new { Referencia = x.Key, Itens = x })
                .First();

            return lista.Itens.ToList();
        }

        /// <summary>
        /// Busca o saldo de contribuições do participante
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <returns></returns>
        public SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao, cdFundo);

            return saldo;
        }

        /// <summary>
        /// Busca o salário e o percentual de contribuição do participante por plano
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <param name="numInscricao"></param>
        /// <returns></returns>
        public dynamic BuscarSalarioContribuicaoPorFundacaoPlanoInscricao(string cdFundacao, string cdPlano, string numInscricao, string cdTipoContribuicaoIndividual = "01")
        {
            var contribuicoes = BuscarUltimaPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao);
            var contribsIndividuais = new ContribuicaoIndividualProxy().BuscarPorFundacaoInscricao(cdFundacao, numInscricao);

            var ultimaContrib = contribsIndividuais.OrderBy(x => x.SEQ_PERC_CONTRIBUICAO).LastOrDefault(x => x.CD_TIPO_CONTRIBUICAO == cdTipoContribuicaoIndividual);

            return new
            {
                SalarioContribuicao = contribuicoes.Sum(x => x.SRC),
                Percentual = ultimaContrib.VL_PERC_PAR
            };
        }
    }
}
