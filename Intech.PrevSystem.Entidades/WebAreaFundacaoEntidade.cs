using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_AREA_FUNDACAO")]
    public class WebAreaFundacaoEntidade
    {
		[Key]
		public decimal OID_AREA_FUNDACAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string DES_AREA_FUNDACAO { get; set; }
		public string TXT_EMAIL { get; set; }
		public string IND_ATIVO { get; set; }
		[Write(false)] public string TXT_ASSUNTO { get; set; }
        
    }
}
