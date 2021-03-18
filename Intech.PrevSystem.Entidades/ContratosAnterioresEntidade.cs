using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_CONTRATOS_ANTERIORES")]
	public class ContratosAnterioresEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public decimal ANO_CONTRATO { get; set; }
		public int NUM_CONTRATO { get; set; }
		public decimal SEQUENCIA { get; set; }
		public decimal? ANO_CONTRATO_ANT { get; set; }
		public int? NUM_CONTRATO_ANT { get; set; }
		public decimal? VL_PRINC_QUITACAO { get; set; }
		public decimal? VL_JUROS_QUITACAO { get; set; }
		public decimal? VL_PREST_ATRASO { get; set; }
		public decimal? VL_JUROS_PREST_ATRASO { get; set; }
		public decimal? VL_JUROS_MORA_PREST { get; set; }
		public decimal? VL_MULTA_PREST { get; set; }
		public decimal? VL_REFORMADO { get; set; }
		public decimal? VL_JUROS_PREST_MES { get; set; }
		public decimal? VL_PREST_MES { get; set; }
		public decimal? VL_PRINC_PREST_ATRASO { get; set; }
		public decimal? VL_CORR_PREST_ATRASO { get; set; }
		public decimal? VL_CORRECAO_SALDO_QUITACAO { get; set; }
		public decimal? VL_DESCONTO_QUITACAO { get; set; }
		public decimal? VL_PRINC_PREST_MES { get; set; }
		public decimal? VL_SEGURO_QUIT { get; set; }
		public decimal? VL_SEGURO_PRORATA { get; set; }
		public decimal? VL_TX_SEGURO_QUITACAO { get; set; }
		public decimal? VL_CORR_PRINC_PREST_MES { get; set; }
		public decimal? VL_CORR_JUROS_PREST_MES { get; set; }
		public decimal? VL_TX_ADM_MES_QUIT { get; set; }
		public decimal? VL_IOF_COMPL_QUIT { get; set; }
		public decimal? VL_ADM_PRORATA { get; set; }
	}
}