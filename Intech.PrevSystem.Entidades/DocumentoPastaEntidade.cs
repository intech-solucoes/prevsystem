using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_DOCUMENTO_PASTA")]
    public class DocumentoPastaEntidade
    {
		[Key]
		public decimal OID_DOCUMENTO_PASTA { get; set; }
		public decimal? OID_DOCUMENTO_PASTA_PAI { get; set; }
		public string NOM_PASTA { get; set; }
		public decimal? OID_GRUPO_USUARIO { get; set; }
        
    }
}
