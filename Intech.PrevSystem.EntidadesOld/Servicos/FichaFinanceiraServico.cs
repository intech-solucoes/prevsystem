#region Usings
using Intech.Lib.Mobile.Servico;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class FichaFinanceiraServico : BaseServico<FichaFinanceiraEntidade>
    {
        public FichaFinanceiraServico(string apiUrl) : base(apiUrl) { }

        public async Task<List<FichaFinanceiraEntidade>> BuscarPorFundacaoPlanoInscricao(string fundacao, string plano, string inscricao) =>
            await ExecutarGetLista($"/fichaFinanceira/ultimaPorFundacaoPlanoInscricao/{fundacao}/{plano}/{inscricao}");

        public async Task<List<FichaFinanceiraEntidade>> BuscarResumoAnosPorFundacaoPlanoInscricao(string fundacao, string plano, string inscricao) =>
            await ExecutarGetLista($"/fichaFinanceira/resumoAnosPorFundacaoPlanoInscricao/{fundacao}/{plano}/{inscricao}");

        public async Task<List<FichaFinanceiraEntidade>> BuscarResumoMesesPorFundacaoPlanoInscricaoAno(string fundacao, string plano, string inscricao, string anoRef) =>
            await ExecutarGetLista($"/fichaFinanceira/resumoMesesPorFundacaoPlanoInscricaoAno/{fundacao}/{plano}/{inscricao}/{anoRef}");

        public async Task<List<FichaFinanceiraEntidade>> BuscarTiposPorFundacaoPlanoInscricaoAnoMes(string fundacao, string plano, string inscricao, string anoRef, string mesRef) =>
            await ExecutarGetLista($"/fichaFinanceira/tiposPorFundacaoPlanoInscricaoAnoMes/{fundacao}/{plano}/{inscricao}/{anoRef}/{mesRef}");

        public async Task<SaldoContribuicoesEntidade> BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(string fundacao, string empresa, string plano, string inscricao, string fundo) =>
            await ExecutarGet<SaldoContribuicoesEntidade>($"/fichaFinanceira/saldoPorFundacaoEmpresaPlanoInscricaoFundo/{fundacao}/{empresa}/{plano}/{inscricao}/{fundo}");

    }
}
