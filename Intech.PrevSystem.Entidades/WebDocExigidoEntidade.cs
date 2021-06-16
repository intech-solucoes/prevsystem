using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DOC_EXIGIDO")]
	public class WebDocExigidoEntidade
	{
		[Key]
		public decimal OID_DOC_EXIGIDO { get; set; }
		public decimal OID_FUNCIONALIDADE { get; set; }
		public string CD_PLANO { get; set; }
		public string TXT_DOCUMENTO { get; set; }
		public string TXT_INFO_DOCUMENTO { get; set; }
		public string IND_OBRIGATORIO { get; set; }
		public string IND_ATIVO { get; set; }
	}
}
