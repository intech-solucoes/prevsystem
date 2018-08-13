#region Usings
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades; 
#endregion

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
                plano.Modalidades = new ModalidadeProxy().BuscarAtivasComNaturezas(CD_FUNDACAO, plano.CD_PLANO, plano.CD_CATEGORIA, plano.NUM_INSCRICAO);
            });

            return planos;
        }

        public override PlanoVinculadoEntidade BuscarPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
        {
            var plano = base.BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);
            
            plano.ProcessoBeneficio = new ProcessoBeneficioProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, plano.CD_PLANO);

            //var salarioBase = new SalarioBaseProxy().BuscarUltimoPorFundacaoEmpresaMatricula(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA);

            //var salarioContribuicao = new FichaFinanceiraProxy().BuscarSalarioContribuicaoPorFundacaoPlanoInscricao(CD_FUNDACAO, CD_PLANO, plano.NUM_INSCRICAO);
            //plano.SalarioContribuicao = salarioBase.VL_SALARIO.Value;
            //plano.PercentualContribuicao = salarioContribuicao.Percentual;

            return plano;
        }
    }
}
