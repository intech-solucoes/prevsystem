using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CC_FICHA_FECHAMENTO_PREVES")]
	public class FichaFechamentoPrevesEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string IND_ANALITICO_SINTETICO { get; set; }
		public string IND_TIPO { get; set; }
		public string IND_PARTIC { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public string ANO_COMP { get; set; }
		public string MES_COMP { get; set; }
		public int NUM_SEQ { get; set; }
		public decimal VL_GRUPO1 { get; set; }
		public decimal VL_GRUPO2 { get; set; }
		public decimal VL_GRUPO3 { get; set; }
		public decimal VL_GRUPO4 { get; set; }
		public decimal VL_GRUPO5 { get; set; }
		public decimal VL_GRUPO6 { get; set; }
		public decimal VL_LIQUIDO { get; set; }
		public decimal VL_COTA { get; set; }
		public decimal QTE_COTA { get; set; }
		public decimal? QTE_COTA_SOBREV { get; set; }
		public decimal QTE_COTA_ADIQ { get; set; }
		public decimal? QTE_COTA_ACUM { get; set; }
		public decimal? VL_ACUMULADO { get; set; }
		public DateTime? DT_FECHAMENTO { get; set; }
		public DateTime? DT_PAGAMENTO { get; set; }
		[Write(false)] public string DS_LOTACAO { get; set; }
	}
}
