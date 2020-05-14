using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_REL_IRRF")]
	public class RelIRRFEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public int SEQUENCIA { get; set; }
		public DateTime DT_REF { get; set; }
		public string COD_USU { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CONTRATOS { get; set; }
		public decimal NUM_SEQ_GR_FAMIL { get; set; }
		public decimal? VL_SALDO_ANO_ANT { get; set; }
		public decimal? VL_SALDO_ANO_REF { get; set; }
		public string CD_LOTACAO { get; set; }
		public string DS_LOCALIDADE { get; set; }
		public int? ANO_CONTRATO { get; set; }
		public int? NUM_CONTRATO { get; set; }
		public string DS_LOTACAO { get; set; }
		public string DS_NATUR { get; set; }
		public DateTime? DT_CONCESSAO { get; set; }
		public decimal? PRAZO { get; set; }
		public decimal? VL_SOLICITADO { get; set; }
		public decimal? VL_PRESTACAO { get; set; }
		public decimal? CD_NATUREZA { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string CONTRATOS_PAGOS { get; set; }
	}
}
