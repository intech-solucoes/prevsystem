using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_PROTOCOLO")]
    public class ProtocoloEntidade
    {
		[Key]
		public decimal OID_PROTOCOLO { get; set; }
		public decimal OID_FUNCIONALIDADE { get; set; }
		public string COD_IDENTIFICADOR { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_MATRICULA { get; set; }
		public decimal? SEQ_RECEBEDOR { get; set; }
		public DateTime DTA_SOLICITACAO { get; set; }
		public DateTime? DTA_EFETIVACAO { get; set; }
		public string TXT_MOTIVO_RECUSA { get; set; }
		public string TXT_TRANSACAO { get; set; }
		public string TXT_TRANSACAO2 { get; set; }
		public string TXT_USUARIO_SOLICITACAO { get; set; }
		public string TXT_USUARIO_EFETIVACAO { get; set; }
		public string TXT_IPV4 { get; set; }
		public string TXT_IPV6 { get; set; }
		public string TXT_DISPOSITIVO { get; set; }
		public string TXT_ORIGEM { get; set; }
		public string TXT_IPV4_EXTERNO { get; set; }
        
    }
}
