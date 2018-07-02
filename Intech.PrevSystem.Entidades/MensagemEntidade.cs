using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_MENSAGEM")]
    public class MensagemEntidade
    {
		[Key]
		public decimal OID_MENSAGEM { get; set; }
		public string TXT_TITULO { get; set; }
		public string TXT_CORPO { get; set; }
		public DateTime DTA_MENSAGEM { get; set; }
		public DateTime? DTA_EXPIRACAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_SIT_PLANO { get; set; }
		public decimal? COD_ENTID { get; set; }
		public string IND_MOBILE { get; set; }
		public string IND_PORTAL { get; set; }
		public string IND_EMAIL { get; set; }
		public string IND_SMS { get; set; }
		public string NOM_FUNDACAO { get; set; }
		public string NOM_EMPRESA { get; set; }
		public string DS_PLANO { get; set; }
		public string DS_SIT_PLANO { get; set; }
		public string NUM_MATRICULA { get; set; }
        
    }
}
