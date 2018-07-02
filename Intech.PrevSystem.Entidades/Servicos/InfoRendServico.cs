#region Usings
using Intech.Lib.Mobile.Servico;
using System.Collections.Generic;
using System.Threading.Tasks; 
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class InfoRendServico : BaseServico<HeaderInfoRendEntidade>
    {
        public InfoRendServico(string apiUrl) : base(apiUrl) { }

        public async Task<List<decimal>> BuscarReferenciasPorCPF(string cpf) =>
            await ExecutarGetLista<decimal>($"/infoRend/referenciasPorCpf/{cpf}");

        public async Task<HeaderInfoRendEntidade> BuscarPorCpfReferencia(string cpf, decimal referencia) =>
            await ExecutarGet($"/infoRend/porCpfReferencia/{cpf}/{referencia}");
    }
}
