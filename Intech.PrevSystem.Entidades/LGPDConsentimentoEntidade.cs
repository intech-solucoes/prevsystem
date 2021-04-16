using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_LGPD_CONSENTIMENTO")]
	public class LGPDConsentimentoEntidade
	{
		[Key]
		public decimal OID_LGPD_CONSENTIMENTO { get; set; }
		public string COD_IDENTIFICADOR { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string COD_CPF { get; set; }
		public DateTime DTA_CONSENTIMENTO { get; set; }
		public string TXT_IPV4 { get; set; }
		public string TXT_IPV6 { get; set; }
		public string TXT_DISPOSITIVO { get; set; }
		public string TXT_ORIGEM { get; set; }
		public int? DIAS_EXPIRACAO { get; set; }
	}
}
