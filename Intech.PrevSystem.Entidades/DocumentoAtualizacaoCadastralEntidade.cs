using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DOC_ATU_CADASTRAL")]
	public class DocumentoAtualizacaoCadastralEntidade
	{
		[Write(false)] public string NOME_ENTID { get; set; }
		[Write(false)] public string NOM_ARQUIVO_ORIGINAL { get; set; }
		[Write(false)] public string NOM_ARQUIVO_LOCAL { get; set; }
		[Write(false)] public DateTime? DTA_UPLOAD { get; set; }
	}
}
