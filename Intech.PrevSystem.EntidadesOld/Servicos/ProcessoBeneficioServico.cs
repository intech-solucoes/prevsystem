#region Usings
using Intech.Lib.Mobile.Servico;
using System.Threading.Tasks;
#endregion

namespace Intech.PrevSystem.Entidades.Servicos
{
    public class ProcessoBeneficioServico : BaseServico<ProcessoBeneficioEntidade>
    {
        public ProcessoBeneficioServico(string apiUrl) : base(apiUrl) { }

        public async Task<ProcessoBeneficioEntidade> BuscarPorFundacaoEmpresaMatriculaPlano(string fundacao, string empresa, string matricula, string plano)
        {
            return await ExecutarGet($"/processoBeneficio/porFundacaoEmpresaMatriculaPlano/{fundacao}/{empresa}/{matricula}/{plano}");
        }
    }
}
