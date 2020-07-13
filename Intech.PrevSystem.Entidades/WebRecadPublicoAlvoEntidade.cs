using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RECAD_PUBLICO_ALVO")]
	public class WebRecadPublicoAlvoEntidade
	{
		[Key]
		public decimal OID_RECAD_PUBLICO_ALVO { get; set; }
		public decimal OID_RECAD_CAMPANHA { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal SEQ_RECEBEDOR { get; set; }
		public string IND_SITUACAO_RECAD { get; set; }
		public DateTime? DTA_EFETIVACAO { get; set; }
		public string NOM_USUARIO_ACAO { get; set; }
		[Write(false)] public DateTime DTA_TERMINO { get; set; }
		[Write(false)] public string CD_TIPO_RECEBEDOR { get; set; }
		[Write(false)] public string CD_ESPECIE_INSS { get; set; }
		[Write(false)] public string TEXTO_RECAD { get; set; }
	}
}
