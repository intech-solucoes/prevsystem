using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_ADESAO_DOCUMENTO")]
    public class AdesaoDocumentoEntidade
    {
		[Key]
		public decimal OID_ADESAO_DOCUMENTO { get; set; }
		public decimal OID_ADESAO { get; set; }
		public string TXT_TITULO { get; set; }
		public string TXT_NOME_FISICO { get; set; }
        
    }
}
