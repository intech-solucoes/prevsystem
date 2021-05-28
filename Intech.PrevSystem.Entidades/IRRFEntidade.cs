using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TB_IRRF")]
	public class IRRFEntidade
	{
		public DateTime DT_REFERENCIA { get; set; }
		public decimal TIPO_IRRF { get; set; }
		public decimal? NUM_MAXIMO_DEP { get; set; }
		public decimal? VALOR_ABATIMENTO_DEP { get; set; }
		public decimal? VALOR_RETENCAO_MINIMA { get; set; }
		public decimal? ABATIMENTO_ACIMA_65ANOS { get; set; }
		public decimal? PERC_RET_RESID_EXTERIOR { get; set; }
		public decimal? VALOR_ABATIMENTO_EXTRA { get; set; }
	}
}