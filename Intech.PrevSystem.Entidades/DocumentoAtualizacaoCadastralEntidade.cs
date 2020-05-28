using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_DOC_ATU_CADASTRAL")]
	public class DocumentoAtualizacaoCadastralEntidade
	{
		[Key]
		public decimal OID_DOC_ATU_CADASTRAL { get; set; }
		public decimal OID_ARQUIVO_UPLOAD { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal SEQ_RECEBEDOR { get; set; }
		[Write(false)] public string NOME_ENTID { get; set; }
		[Write(false)] public string NOM_ARQUIVO_ORIGINAL { get; set; }
		[Write(false)] public string NOM_ARQUIVO_LOCAL { get; set; }
		[Write(false)] public DateTime? DTA_UPLOAD { get; set; }
	}
}
