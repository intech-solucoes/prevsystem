using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("AM_MOV_COBRANCA_RUB")]
	public class MovCobrancaRubEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public DateTime DT_INICIO { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public DateTime? DT_COMPETENCIA { get; set; }
		public string CD_RUBRICA_COBRANCA { get; set; }
		public decimal? VL_RUBRICA { get; set; }
		public string ANO_COMP { get; set; }
		public string MES_COMP { get; set; }
	}
}
