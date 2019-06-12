#region Usings
using Intech.Lib.Mobile.Servico;
using System.Threading.Tasks; 
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class RelacionamentoServico : BaseServico<RelacionamentoEntidade>
    {
        public RelacionamentoServico(string apiUrl) : base(apiUrl) { }

        public async Task<RelacionamentoEntidade> Enviar(RelacionamentoEntidade entidade)
        {
            return await ExecutarPost($"/relacionamento", entidade);
        }
    }
}
