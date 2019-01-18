using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TBG_LOG_SMS")]
    public class LogSMSEntidade
    {
		[Key]
		public decimal OID_LOG_SMS { get; set; }
		public string RESPOSTA_ENVIO { get; set; }
		public string NUM_TELEFONE { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public DateTime DTA_ENVIO { get; set; }
        
    }
}
