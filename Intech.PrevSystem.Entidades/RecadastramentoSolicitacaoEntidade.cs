using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("REC_SOLICITACAO")]
	public class RecadastramentoSolicitacaoEntidade
	{
		[Key]
		public decimal OID_SOLICITACAO { get; set; }
		public DateTime DTA_SOLICITACAO { get; set; }
		public DateTime? DTA_RECADASTRO { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string COD_IDENTIFICADOR { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string IND_FECHADA { get; set; }
		public string IND_RECUSADA { get; set; }
		public string TXT_MOTIVO { get; set; }
		public string CD_PLANO { get; set; }
	}
}
