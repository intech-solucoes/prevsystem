#region Usings
using Intech.Lib.Mobile.Servico;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class DadosPessoaisServico : BaseServico<DadosPessoaisEntidade>
    {
        public DadosPessoaisServico(string apiUrl) : base(apiUrl) { }

        public async Task<DadosPessoaisEntidade> BuscarPorCodEntid(decimal codEntid)
        {
            return await ExecutarGet($"/dadosPessoais/porCodEntid/{codEntid.ToString()}");
        }
    }
}
