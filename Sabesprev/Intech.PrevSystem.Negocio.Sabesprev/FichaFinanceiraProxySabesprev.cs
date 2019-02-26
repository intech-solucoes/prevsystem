using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.PrevSystem.Negocio.Sabesprev
{
    public class FichaFinanceiraProxySabesprev : FichaFinanceiraProxy
    {
        public virtual SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricao(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, DateTime dataSaldo)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();

            if (contribuicoes.Count == 0)
                throw new Exception("Nenhuma contribuição encontrada");

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao, null, dataSaldo.ToString() );

            return saldo;
        }

        /// <summary>
        /// Busca o saldo de contribuições do participante
        /// </summary>
        /// <param name="cdFundacao"></param>
        /// <param name="cdPlano"></param>
        /// <returns></returns>
        public SaldoContribuicoesEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdFundo, DateTime dataSaldo)
        {
            var contribuicoes = BuscarPorFundacaoPlanoInscricao(cdFundacao, cdPlano, numInscricao).ToList();

            if (contribuicoes.Count == 0)
                throw new Exception("Nenhuma contribuição encontrada");

            var saldo = new SaldoContribuicoesEntidade();
            saldo.PreencherSaldo(contribuicoes, cdFundacao, cdEmpresa, cdPlano, numInscricao, cdFundo, dataSaldo.ToString());

            return saldo;
        }
    }
}
