using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DESC_AUTORIZADO")]
	public class WebDescAutorizadoEntidade
	{
		[Key]
		public decimal OID_DESC_AUTORIZADO { get; set; }
		public string NOM_DESCONTO { get; set; }
		public string TXT_DESCONTO_PORTAL { get; set; }
		public decimal NUM_ORDEM { get; set; }
		public string IND_ATIVO { get; set; }
	}
}
