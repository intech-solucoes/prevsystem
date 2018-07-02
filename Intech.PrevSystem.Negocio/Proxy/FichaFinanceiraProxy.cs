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
            var lista = base.BuscarResumoMesesPorFundacaoPlanoInscricaoAno(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF)
                .ToList();

            lista.ForEach(x => x.DES_MES_REF = DateTimeExtensoes.MesPorExtenso(x.MES_REF));

            return lista;
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
