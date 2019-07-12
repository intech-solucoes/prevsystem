using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ProcessoBeneficioProxy : ProcessoBeneficioDAO
    {
        public override ProcessoBeneficioEntidade BuscarPorFundacaoEmpresaInscricaoPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string CD_PLANO)
        {
            var processo = base.BuscarPorFundacaoEmpresaInscricaoPlano(CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO, CD_PLANO);

            //var mesesRecebimento = (int)processo.SALDO_ATUAL / (int)(processo.SALDO_ATUAL * processo.VL_PARCELA_MENSAL / 100);
            var mesesRecebimento = 100M / processo.VL_PARCELA_MENSAL.Value;

            mesesRecebimento = mesesRecebimento / 13;
            var fracaoMeses = mesesRecebimento % Math.Floor(mesesRecebimento);
            fracaoMeses = fracaoMeses * 12;

            var totalAnos = Convert.ToInt32(Math.Floor(mesesRecebimento));
            var totalMeses = Convert.ToInt32(Math.Floor(fracaoMeses));

            processo.DT_APOSENTADORIA = processo.DT_INICIO_FUND.Value.AddYears(totalAnos).AddMonths(totalMeses);

            return processo;
        }
    }
}