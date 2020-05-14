using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_PRESTACOES_PARCIAIS")]
	public class PrestacaoParcialEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public decimal ANO_CONTRATO { get; set; }
		public int NUM_CONTRATO { get; set; }
		public decimal PARCELA { get; set; }
		public decimal SEQUENCIAL { get; set; }
		public DateTime? DT_VENC { get; set; }
		public DateTime? DT_PAGTO { get; set; }
		public decimal? VL_PRINCIPAL { get; set; }
		public decimal? VL_JUROS { get; set; }
		public decimal? VL_PRESTACAO { get; set; }
		public decimal? VL_MULTA { get; set; }
		public decimal? VL_MORA { get; set; }
		public decimal? VL_CORR_PREST { get; set; }
		public decimal? VL_PREST_REAL { get; set; }
		public decimal? VL_ARECEBER { get; set; }
		public decimal? VL_PRINC_PREST_REAL { get; set; }
		public decimal? VL_JUROS_PREST_REAL { get; set; }
		public decimal? VL_TX_SEGURO { get; set; }
		public decimal? CD_ORIGEM_REC { get; set; }
		public decimal? VL_CORR_PRINC { get; set; }
		public decimal? VL_CORR_PRINC_REAL { get; set; }
		public decimal? VL_CORR_JUROS { get; set; }
		public decimal? VL_CORR_JUROS_REAL { get; set; }
		public decimal? VL_DESCONTO { get; set; }
		public decimal? VL_CORR_PREST_ATRASO { get; set; }
		public decimal? VL_TX_ADM { get; set; }
	}
}
