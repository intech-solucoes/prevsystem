using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("AM_HIST_SALARIOS")]
	public class HistSalariosEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime DT_INICIO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public DateTime DT_INIC_VALIDADE { get; set; }
		public DateTime? DT_TERM_VALIDADE { get; set; }
		public string CD_REGRA_REAJUSTE { get; set; }
		public decimal? VL_SALARIO_BASE { get; set; }
		public decimal? VL_SALARIO_BASE2 { get; set; }
		public string CD_NIVEL_SALARIAL { get; set; }
	}
}