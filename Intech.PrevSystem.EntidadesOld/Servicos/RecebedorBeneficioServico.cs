#region Usings
using Intech.Lib.Mobile.Servico;
using System.Threading.Tasks; 
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class RecebedorBeneficioServico : BaseServico<RecebedorBeneficioEntidade>
    {
        public RecebedorBeneficioServico(string apiUrl) : base(apiUrl) { }

        public async Task<RecebedorBeneficioEntidade> BuscarPorCpf(string cpf) => 
            await ExecutarGet($"/recebedorBeneficio/pensionistaPorCpf/{cpf}");
    }
}
