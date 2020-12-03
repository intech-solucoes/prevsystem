using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DOCUMENTO")]
	public class DocumentoEntidade
	{
		[Key]
		public decimal OID_DOCUMENTO { get; set; }
		public decimal OID_ARQUIVO_UPLOAD { get; set; }
		public decimal? OID_DOCUMENTO_PASTA { get; set; }
		public string TXT_TITULO { get; set; }
		public string IND_ATIVO { get; set; }
		public DateTime? DTA_INCLUSAO { get; set; }
		[Write(false)] public string CD_PLANO { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
	}
}
