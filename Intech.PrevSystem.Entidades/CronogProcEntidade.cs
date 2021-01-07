using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_CRONOG_PROC")]
	public class CronogProcEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_TIPO_FOLHA { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public DateTime? DT_PROCESSAMENTO { get; set; }
		public DateTime? DT_LIM_REC_DOC { get; set; }
		public DateTime? DT_CRED_BANC { get; set; }
		public DateTime? DT_LIM_ALTERACAO { get; set; }
		public string USUARIO { get; set; }
		public DateTime? DT_PROC_USUARIO { get; set; }
		public string SITUACAO { get; set; }
		public DateTime? DT_INIC_SELEC { get; set; }
		public DateTime? DT_TERM_SELEC { get; set; }
		public DateTime? DT_VALORIZ_COTA { get; set; }
		public DateTime? DT_COMPETENCIA { get; set; }
		public DateTime? DT_REPROCESSAMENTO { get; set; }
		public DateTime? DT_FECHAMENTO { get; set; }
		public DateTime? DT_RETROATIVIDADE { get; set; }
		public string ABONO_ANUAL { get; set; }
		public decimal? PERC_ABONO_ANUAL { get; set; }
		public DateTime? DT_INTEGR_CONTAB { get; set; }
		public DateTime? DT_INTEGR_FINANC { get; set; }
		public DateTime? DT_INTEGR_COTAS { get; set; }
		public DateTime? DT_REL_PROCESSO { get; set; }
		public decimal? VL_PERC_ADIANT { get; set; }
		public string ID_PREVIA { get; set; }
	}
}
