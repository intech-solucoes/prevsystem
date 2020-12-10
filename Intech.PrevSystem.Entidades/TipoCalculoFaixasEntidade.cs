using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_TIPO_CALCULO_FAIXAS")]
	public class TipoCalculoFaixasEntidade
	{
		public decimal CD_CALCULO { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public decimal FAIXA { get; set; }
		public decimal VL_BASE { get; set; }
		public decimal VL_PERCENTUAL { get; set; }
		public decimal? VL_PISO { get; set; }
		public decimal? VL_TETO { get; set; }
		public decimal? VL_AVOS { get; set; }
		public decimal? PERC_TETO_SAL { get; set; }
		public DateTime? DIB { get; set; }
		public decimal? DEDUCAO { get; set; }
	}
}
