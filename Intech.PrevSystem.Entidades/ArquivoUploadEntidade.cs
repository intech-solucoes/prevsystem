using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TBG_ARQUIVO_UPLOAD")]
	public class ArquivoUploadEntidade
	{
		[Key]
		public decimal OID_ARQUIVO_UPLOAD { get; set; }
		public string NOM_ARQUIVO_ORIGINAL { get; set; }
		public string NOM_EXT_ARQUIVO { get; set; }
		public DateTime DTA_UPLOAD { get; set; }
		public string NOM_DIRETORIO_LOCAL { get; set; }
		public string NOM_ARQUIVO_LOCAL { get; set; }
		public decimal? OID_USUARIO { get; set; }
		public decimal? OID_SERVICO { get; set; }
		public decimal? OID_MODULO { get; set; }
		public decimal? OID_SISTEMA { get; set; }
		public decimal IND_STATUS { get; set; }
	}
}