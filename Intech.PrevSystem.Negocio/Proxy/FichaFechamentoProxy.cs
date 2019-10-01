using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FichaFechamentoProxy : FichaFechamentoDAO
    {
        public FichaFechamentoEntidade BuscarSaldoPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
        {
            var saldos = base.BuscarPorFundacaoEmpresaPlanoInscricao(CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO).ToList();

            if (saldos.Count == 0)
                return new FichaFechamentoEntidade();

            return new FichaFechamentoEntidade
            {
                VL_GRUPO1 = saldos.Sum(x => x.VL_GRUPO1) + (saldos.Sum(x => x.VL_GRUPO3) / 2),
                VL_GRUPO2 = saldos.Sum(x => x.VL_GRUPO2) + (saldos.Sum(x => x.VL_GRUPO3) / 2),
                VL_ACUMULADO = saldos.First().VL_ACUMULADO,
                VL_COTA = saldos.First().VL_COTA,
                DT_FECHAMENTO = saldos.First().DT_FECHAMENTO
            };
        }
    }
}