using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_FATOR_RISCO")]
	public class FatorRiscoEntidade
	{
		[Key]
		public decimal OID_FATOR_RISCO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public decimal NUM_FAIXA_INI { get; set; }
		public decimal NUM_FAIXA_FIM { get; set; }
		public decimal VAL_FATOR_INVALIDEZ { get; set; }
		public decimal VAL_FATOR_MORTE { get; set; }
	}
}
