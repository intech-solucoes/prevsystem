using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("REC_SOLICITACAO_VALOR")]
	public class RecadastramentoSolicitacaoValorEntidade
	{
		[Key]
		public decimal OID_SOLICITACAO_VALOR { get; set; }
		public decimal NUM_PASSO { get; set; }
		public string COD_GRUPO { get; set; }
		public string COD_CAMPO { get; set; }
		public string TXT_VALOR_ANTIGO { get; set; }
		public string TXT_VALOR_NOVO { get; set; }
		public decimal OID_SOLICITACAO { get; set; }
		public string TXT_ARQUIVO { get; set; }
		public string TXT_DESCRICAO { get; set; }
	}
}
