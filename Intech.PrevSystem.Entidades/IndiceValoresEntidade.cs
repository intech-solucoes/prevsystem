using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_IND_VALORES")]
	public class IndiceValoresEntidade
	{
		public string COD_IND { get; set; }
		public DateTime DT_IND { get; set; }
		public decimal VALOR_IND { get; set; }
		public decimal VARIACAO_IND { get; set; }
		public string IND_PREVISTO { get; set; }
	}
}
