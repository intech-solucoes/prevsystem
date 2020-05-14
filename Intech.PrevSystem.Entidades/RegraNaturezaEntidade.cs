using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_REGRA_NATUREZA")]
	public class RegraNaturezaEntidade
	{
		public decimal CD_NATUR { get; set; }
		public string DS_NATUR { get; set; }
		public string REGRA { get; set; }
		public decimal? IDADE_MAXIMA { get; set; }
		public decimal? PRAZO_MAXIMO { get; set; }
		public string PERCENTUAL_QTD { get; set; }
		public decimal? QTD_REFORMAS { get; set; }
		public DateTime? DT_INI_VIGENCIA { get; set; }
	}
}
