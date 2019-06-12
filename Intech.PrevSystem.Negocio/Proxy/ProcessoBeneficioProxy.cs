using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ProcessoBeneficioProxy : ProcessoBeneficioDAO
    {
        public override ProcessoBeneficioEntidade BuscarPorFundacaoEmpresaInscricaoPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string CD_PLANO)
        {
            var processo = base.BuscarPorFundacaoEmpresaInscricaoPlano(CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO, CD_PLANO);

            var anosRecebimento = (int)processo.SALDO_INICIAL / (int)(processo.SALDO_INICIAL * processo.VL_PARCELA_MENSAL / 100);
            processo.DT_APOSENTADORIA = processo.DT_INICIO_FUND.Value.AddYears(anosRecebimento);

            return processo;
        }
    }
}