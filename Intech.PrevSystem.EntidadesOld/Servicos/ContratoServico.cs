#region Usings
using Intech.Lib.Mobile.Servico;
using System.Collections.Generic;
using System.Threading.Tasks; 
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class ContratoServico : BaseServico<ContratoEntidade>
    {
        public ContratoServico(string apiUrl) : base(apiUrl) { }

        public async Task<List<ContratoEntidade>> BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, string cdSituacao) =>
            await ExecutarGetLista($"/contrato/porFundacaoEmpresaPlanoInscricaoSituacao/{cdFundacao}/{cdEmpresa}/{cdPlano}/{numInscricao}/{cdSituacao}");

        public async Task<List<ContratoEntidade>> BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(string cdFundacao, string cdEmpresa, string cdPlano, string numInscricao, int grupoFamilia, string cdSituacao) =>
            await ExecutarGetLista($"/contrato/porFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao/{cdFundacao}/{cdEmpresa}/{cdPlano}/{numInscricao}/{grupoFamilia}/{cdSituacao}");
    }
}
