#region Usings
using Intech.Lib.Mobile.Servico;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class PlanoVinculadoServico : BaseServico<PlanoVinculadoEntidade>
    {
        public PlanoVinculadoServico(string apiUrl) : base(apiUrl) { }

        public async Task<List<PlanoVinculadoEntidade>> BuscarPorFundacaoEmpresaMatricula(string fundacao, string empresa, string matricula) =>
            await ExecutarGetLista($"/planoVinculado/porFundacaoEmpresaMatricula/{fundacao}/{empresa}/{matricula}");

        public async Task<List<PlanoVinculadoEntidade>> BuscarPorFundacaoEmpresaCpf(string fundacao, string empresa, string cpf) =>
            await ExecutarGetLista($"/planoVinculado/porFundacaoEmpresaCpf/{fundacao}/{empresa}/{cpf}");

        public async Task<List<PlanoVinculadoEntidade>> BuscarPorFundacaoEmpresaCpfPensionista(string fundacao, string empresa, string cpf) =>
            await ExecutarGetLista($"/planoVinculado/porFundacaoEmpresaCpfPensionista/{fundacao}/{empresa}/{cpf}");
    }
}
