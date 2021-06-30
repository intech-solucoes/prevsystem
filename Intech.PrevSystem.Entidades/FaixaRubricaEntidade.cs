using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("GB_FAIXA_RUBRICA")]
	public class FaixaRubricaEntidade
	{
		public decimal CD_CALCULO { get; set; }
		public DateTime DT_VIGENCIA { get; set; }
		public string COD_IND_CONC { get; set; }
		public decimal? FAIXA { get; set; }
		public decimal? VL_BASE { get; set; }
		public decimal? VL_PERCENTUAL { get; set; }
		public decimal? VL_PISO { get; set; }
		public decimal? VL_TETO { get; set; }
	}
}