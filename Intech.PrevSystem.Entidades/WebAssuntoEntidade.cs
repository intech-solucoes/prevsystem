using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_ASSUNTO")]
    public class WebAssuntoEntidade
    {
		[Key]
		public decimal OID_ASSUNTO { get; set; }
		public decimal OID_AREA_FUNDACAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string TXT_ASSUNTO { get; set; }
		public string IND_ATIVO { get; set; }
        
    }
}
