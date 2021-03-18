using System.Collections.Generic;
using System.Data;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class PrestacaoProxy : PrestacaoDAO
    {
        public PrestacaoProxy(IDbTransaction tx = null) : base(tx) { }

        public dynamic BuscarResumoPorFundacaoContrato(string CD_FUNDACAO, decimal ANO_CONTRATO, decimal NUM_CONTRATO)
        {
            var prestacoes = base.BuscarPorFundacaoContrato(CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO)
                .Where(x => x.TIPO != "S")
                .ToList();
            var prestacoesPagas = prestacoes.Where(x => x.DT_PAGTO != null).ToList();
            var qntPagas = prestacoesPagas.Count;

            var inadimplentes = prestacoes.Where(x => x.CD_ORIGEM_REC == 50).ToList();
            var valorInadimplentes = inadimplentes.Sum(x => x.VL_PRESTACAO);

            var valorPagas = prestacoesPagas.Sum(x => x.VL_RECEBIDO);
            var totalPrestacoes = prestacoes.Sum(x => x.VL_PRESTACAO);

            return new
            {
                PrestacoesPagas = qntPagas,
                ValorPrestacoesPagas = valorPagas,
                PrestacoesInadimplentes = inadimplentes.Count,
                ValorPrestacoesInadimplentes = valorInadimplentes,
                PrestacoesAPagar = prestacoes.Count - prestacoesPagas.Count,
                ValorPrestacoesAPagar = totalPrestacoes - valorPagas,
                Prestacoes = prestacoes
            };
        }
    }
}
