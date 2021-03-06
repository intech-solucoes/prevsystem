using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DOCUMENTO_PASTA")]
	public class DocumentoPastaEntidade
	{
		[Key]
		public decimal OID_DOCUMENTO_PASTA { get; set; }
		public string NOM_PASTA { get; set; }
		public decimal? OID_DOCUMENTO_PASTA_PAI { get; set; }
		public DateTime? DTA_INCLUSAO { get; set; }
		[Write(false)] public string NOM_GRUPO_USUARIO { get; set; }
	}
}