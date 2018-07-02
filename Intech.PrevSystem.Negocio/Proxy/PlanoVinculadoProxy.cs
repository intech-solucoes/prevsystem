using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class PlanoVinculadoProxy : PlanoVinculadoDAO
    {
        public override IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
        {
            var planos = base.BuscarPorFundacaoEmpresaMatricula(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA).ToList();

            var proxyBeneficio = new ProcessoBeneficioProxy();

            planos.ForEach(plano =>
            {
                plano.ProcessoBeneficio = proxyBeneficio.BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, plano.CD_PLANO);
            });

            return planos;
        }
    }
}
