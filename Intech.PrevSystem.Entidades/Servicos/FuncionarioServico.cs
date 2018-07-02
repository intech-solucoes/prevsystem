#region Usings
using Intech.Lib.Mobile.Servico;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class FuncionarioServico : BaseServico<FuncionarioEntidade>
    {
        public FuncionarioServico(string apiUrl) : base(apiUrl) { }

        public async Task<FuncionarioEntidade> BuscarPorCpf(string cpf) =>
            await ExecutarGet($"/funcionario/porCpf/{cpf}");

        public async Task<FuncionarioEntidade> BuscarPorMatricula(string matricula) =>
            await ExecutarGet($"/funcionario/porMatricula/{matricula}");
    }
}
