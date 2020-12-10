using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_FAIXAS_IRRF")]
	public class FaixasIRRFEntidade
	{
		public DateTime DT_REFERENCIA { get; set; }
		public decimal TIPO_IRRF { get; set; }
		public decimal FAIXA_IRRF { get; set; }
		public decimal? VALOR_FAIXA { get; set; }
		public decimal? PERCENTUAL_FAIXA { get; set; }
		public decimal? DEDUCAO_FAIXA { get; set; }
		public decimal? PERIODO_CONTRIB { get; set; }
		[Write(false)] public decimal? VALOR_ABATIMENTO_DEP { get; set; }
		[Write(false)] public decimal? ABATIMENTO_ACIMA_65ANOS { get; set; }
	}
}
