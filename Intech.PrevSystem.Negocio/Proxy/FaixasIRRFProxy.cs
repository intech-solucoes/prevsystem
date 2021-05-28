using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FaixasIRRFProxy : FaixasIRRFDAO
	{
		public FaixasIRRFProxy (IDbTransaction tx = null) : base(tx) { }

        public override List<FaixasIRRFEntidade> BuscarPorDataReferenciaTipo(DateTime DT_REFERENCIA, decimal TIPO_IRRF)
        {
            var faixas = base.BuscarPorDataReferenciaTipo(DT_REFERENCIA, TIPO_IRRF);

            decimal auxPeriodo = 0;

            var listaFaixas = new List<FaixasIRRFEntidade>();

            foreach (var item in faixas)
            {
                decimal periodo = item.PERIODO_CONTRIB ?? 0;

                listaFaixas.Add(new FaixasIRRFEntidade
                {
                    DT_REFERENCIA = item.DT_REFERENCIA,
                    DEDUCAO_FAIXA = item.DEDUCAO_FAIXA ?? 0,
                    FAIXA_IRRF = item.FAIXA_IRRF,
                    PERCENTUAL_FAIXA = item.PERCENTUAL_FAIXA ?? 0,
                    FimPeriodoContribuicao = periodo,
                    InicioPeriodoContribuicao = auxPeriodo,
                    TIPO_IRRF = item.TIPO_IRRF,
                    VALOR_FAIXA = item.VALOR_FAIXA ?? 0
                });

                auxPeriodo = periodo;
            }

            return listaFaixas;
        }
    }
}