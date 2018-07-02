#region Usings
using Intech.Lib.Mobile.Servico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class FichaFinanceiraAssistidoServico : BaseServico<FichaFinanceiraAssistidoEntidade>
    {
        public FichaFinanceiraAssistidoServico(string apiUrl) : base(apiUrl) { }

        public async Task<List<FichaFinanceiraAssistidoEntidade>> BuscarDatas(string fundacao, string empresa, string matricula, string plano) =>
            await ExecutarGetLista($"/fichaFinanceiraAssistido/datas/{fundacao}/{empresa}/{matricula}/{plano}");

        public async Task<List<FichaFinanceiraAssistidoEntidade>> BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(string fundacao, string empresa, string matricula, string plano, DateTime dtReferencia, string cdTipoFolha) =>
            await ExecutarGetLista($"/fichaFinanceiraAssistido/porFundacaoEmpresaMatriculaPlanoReferencia/{fundacao}/{empresa}/{matricula}/{plano}/{dtReferencia.ToString("dd.MM.yyyy")}/{cdTipoFolha}");

        public async Task<List<FichaFinanceiraAssistidoEntidade>> BuscarDatasPorRecebedor(string fundacao, string empresa, string matricula, string plano, int recebedor) =>
            await ExecutarGetLista($"/fichaFinanceiraAssistido/datasPorRecebedor/{fundacao}/{empresa}/{matricula}/{plano}/{recebedor}");

        public async Task<List<FichaFinanceiraAssistidoEntidade>> BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(string fundacao, string empresa, string matricula, string plano, DateTime dtReferencia, int recebedor, string cdTipoFolha) =>
            await ExecutarGetLista($"/fichaFinanceiraAssistido/porFundacaoEmpresaMatriculaPlanoReferenciaRecebedor/{fundacao}/{empresa}/{matricula}/{plano}/{dtReferencia.ToString("dd.MM.yyyy")}/{recebedor}/{cdTipoFolha}");
    }
}
