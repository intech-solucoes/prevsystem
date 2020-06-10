using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RELACIONAMENTO")]
	public class WebRelacionamentoEntidade
	{
		[Key]
		public decimal OID_RELACIONAMENTO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string COD_CPF { get; set; }
		public DateTime DTA_ENVIO { get; set; }
		public string TXT_EMAIL_DESTINATARIO { get; set; }
		public string TXT_EMAIL_REMETENTE { get; set; }
		public decimal OID_ASSUNTO { get; set; }
		public string TXT_MENSAGEM { get; set; }
		public string TXT_IPV4 { get; set; }
		public string TXT_IPV6 { get; set; }
		public string TXT_DISPOSITIVO { get; set; }
	}
}
