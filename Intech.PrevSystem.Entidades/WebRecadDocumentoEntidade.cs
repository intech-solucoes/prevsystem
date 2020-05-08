using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_RECAD_DOCUMENTO")]
    public class WebRecadDocumentoEntidade
    {
		[Key]
		public decimal OID_RECAD_DOCUMENTO { get; set; }
		public decimal OID_RECAD_DADOS { get; set; }
		public string TXT_TITULO { get; set; }
		public string TXT_NOME_FISICO { get; set; }
        
    }
}
