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
        public override List<FichaFinanceiraEntidade> BuscarResumoAnosPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
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
            else if(CD_PLANO == "0003")
            {
                var fundoContrib4 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "4");
                var fundoContrib6 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "6");

                listaFundos = fundoContrib4.Concat(fundoContrib6).ToList();
            }
            
            // Apura todas as contribuições
            var resumo = new List<FichaFinanceiraEntidade>();
            foreach (var grupo in grupoFicha)
            {
                var apuracao = new FichaFinanceiraEntidade
                {
                    ANO_REF = grupo.ANO_REF,
                    QTD_COTA_RP_PARTICIPANTE = 0M,
                    QTD_COTA_RP_EMPRESA = 0M,
                    CONTRIB_PARTICIPANTE = 0M,
                    CONTRIB_EMPRESA = 0M
                };

                foreach(var contribuicao in grupo.Items)
                {
                    // Filtra as contribuições por fundo
                    if (listaFundos.Any(fundo => fundo.CD_TIPO_CONTRIBUICAO == contribuicao.CD_TIPO_CONTRIBUICAO) || CD_PLANO == "0001")
                    {
                        // Cotas
                        if (contribuicao.QTD_COTA_RP_PARTICIPANTE.HasValue)
                        {
                            if (contribuicao.CD_OPERACAO == "C")
                                apuracao.QTD_COTA_RP_PARTICIPANTE += (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;
                            else
                                apuracao.QTD_COTA_RP_PARTICIPANTE -= (decimal)contribuicao.QTD_COTA_RP_PARTICIPANTE;
                        }

                        if (contribuicao.QTD_COTA_RP_EMPRESA.HasValue)
                        {
                            if (contribuicao.CD_OPERACAO == "C")
                                apuracao.QTD_COTA_RP_EMPRESA += (decimal)contribuicao.QTD_COTA_RP_EMPRESA;
                            else
                                apuracao.QTD_COTA_RP_EMPRESA -= (decimal)contribuicao.QTD_COTA_RP_EMPRESA;
                        }

                        // Valores
                        if (contribuicao.CONTRIB_PARTICIPANTE.HasValue)
                        {
                            if (contribuicao.CD_OPERACAO == "C")
                                apuracao.CONTRIB_PARTICIPANTE += (decimal)contribuicao.CONTRIB_PARTICIPANTE;
                            else
                                apuracao.CONTRIB_PARTICIPANTE -= (decimal)contribuicao.CONTRIB_PARTICIPANTE;
                        }

                        if (contribuicao.CONTRIB_EMPRESA.HasValue)
                        {
                            if (contribuicao.CD_OPERACAO == "C")
                                apuracao.CONTRIB_EMPRESA += (decimal)contribuicao.CONTRIB_EMPRESA;
                            else
                                apuracao.CONTRIB_EMPRESA -= (decimal)contribuicao.CONTRIB_EMPRESA;
                        }
                    }
                }

                apuracao.TOTAL_CONTRIB = apuracao.CONTRIB_PARTICIPANTE + apuracao.CONTRIB_EMPRESA;
                apuracao.QTD_COTA = apuracao.QTD_COTA_RP_PARTICIPANTE + apuracao.QTD_COTA_RP_EMPRESA;

                resumo.Add(apuracao);
            }

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
        public override List<FichaFinanceiraEntidade> BuscarResumoMesesPorFundacaoPlanoInscricaoAno(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF)
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
            else if(CD_PLANO == "0003")
            {
                var fundoContrib4 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "4");
                var fundoContrib6 = new FundoContribProxy().BuscarPorFundacaoPlanoFundo(CD_FUNDACAO, CD_PLANO, "6");

                listaFundos = fundoContrib4.Concat(fundoContrib6).ToList();
            }

            // Apura todas as contribuições
            var resumo = new List<FichaFinanceiraEntidade>();
            foreach (var grupo in grupoFicha)
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

                foreach (var contribuicao in grupo.Items)
                {
                    // Filtra as contribuições por fundo
                    if (listaFundos.Any(fundo => fundo.CD_TIPO_CONTRIBUICAO == contribuicao.CD_TIPO_CONTRIBUICAO) || CD_PLANO == "0001")
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
                }

                apuracao.TOTAL_CONTRIB = apuracao.CONTRIB_PARTICIPANTE + apuracao.CONTRIB_EMPRESA;
                apuracao.QTD_COTA = apuracao.QTD_COTA_RP_PARTICIPANTE + apuracao.QTD_COTA_RP_EMPRESA;

                resumo.Add(apuracao);
            }

            return resumo;
        }

        public override List<FichaFinanceiraEntidade> BuscarTiposPorFundacaoPlanoInscricaoAnoMes(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF, string MES_REF)
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
        /// Busca o saldo de contribuições do participante
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <returns></returns>
        public virtual SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricao(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();

            if (contribuicoes.Count == 0)
                throw new Exception("Nenhuma contribuição encontrada");

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao);

            return saldo;
        }

        /// <summary>
        /// Busca o saldo de contribuições do participante
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <returns></returns>
        public virtual SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();

            if (contribuicoes.Count == 0)
                throw new Exception("Nenhuma contribuição encontrada");

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao, cdFundo, null);

            return saldo;
        }

        /// <summary>
        /// Busca o saldo de contribuições do participante
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <returns></returns>
        public virtual SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundoPeriodo(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo, DateTime dtInicio, DateTime dtFim)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();
            contribuicoes = contribuicoes
                .Where(x => new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) >= dtInicio
                         && new DateTime(Convert.ToInt32(x.ANO_REF), Convert.ToInt32(x.MES_REF), 1) <= dtFim)
                .ToList();

            if (contribuicoes.Count == 0)
                throw new Exception("Nenhuma contribuição encontrada");

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao, cdFundo, null);

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

        public override List<FichaFinanceiraEntidade> BuscarInformePorFundacaoInscricaoAno(string CD_FUNDACAO, string NUM_INSCRICAO, string ANO)
        {
            var informe = base.BuscarInformePorFundacaoInscricaoAno(CD_FUNDACAO, NUM_INSCRICAO, ANO);
            var listaRetorno = new List<FichaFinanceiraEntidade>();

            for(int i = 1; i <= 12; i++)
            {
                var item = informe.SingleOrDefault(x => x.MES_REF.TrimStart('0') == i.ToString());

                if (item != null) {
                    item.DES_MES_REF = DateTimeExtensoes.MesPorExtenso(item.MES_REF.TrimStart('0'));
                    listaRetorno.Add(item);
                }
                else {
                    listaRetorno.Add(new FichaFinanceiraEntidade
                    {
                        MES_REF = i.ToString(),
                        DES_MES_REF = DateTimeExtensoes.MesPorExtenso(i.ToString()),
                        CONTRIB_PARTICIPANTE = 0
                    });
                }
            }

            listaRetorno.Add(new FichaFinanceiraEntidade
            {
                MES_REF = "13",
                DES_MES_REF = "Total",
                CONTRIB_PARTICIPANTE = listaRetorno.Sum(x => x.CONTRIB_PARTICIPANTE)
            });

            return listaRetorno;
        }
    }
}
