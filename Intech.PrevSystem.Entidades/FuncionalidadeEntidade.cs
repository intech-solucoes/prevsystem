using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_FUNCIONALIDADE")]
	public class FuncionalidadeEntidade
	{
		[Key]
		public decimal OID_FUNCIONALIDADE { get; set; }
		public decimal NUM_FUNCIONALIDADE { get; set; }
		public string DES_FUNCIONALIDADE { get; set; }
		public string IND_ATIVO { get; set; }
		public string IND_USA_PROTOCOLO { get; set; }
	}
}
