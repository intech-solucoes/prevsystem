using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_PARAMETRO")]
	public class WebParametroEntidade
	{
		[Key]
		public decimal OID_PARAMETRO { get; set; }
		public string NUM_VERSAO { get; set; }
		public string TXT_EMAIL_EFETIVACAO { get; set; }
		public string TXT_ASSUNTO_EMAIL_EFETIVACAO { get; set; }
		public string TXT_EMAIL_RECUSA { get; set; }
		public string TXT_ASSUNTO_EMAIL_RECUSA { get; set; }
		public string TXT_PASTA_UPLOAD { get; set; }
		public string IND_PREVSYSTEM_WEB { get; set; }
	}
}
