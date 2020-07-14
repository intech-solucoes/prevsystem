using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_MENSAGEM_CCHEQUE")]
	public class MensagemCChequeEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_TIPO_FOLHA { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public decimal SEQ_MENSAGEM { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public int? SEQ_RECEBEDOR { get; set; }
		public string MENSAGEM_2 { get; set; }
		public string MENSAGEM_3 { get; set; }
		public string CD_RUBRICA { get; set; }
		public string MENSAGEM_4 { get; set; }
		public string MENSAGEM_5 { get; set; }
		public string MENSAGEM_6 { get; set; }
		public string MENSAGEM_7 { get; set; }
		public string MENSAGEM_8 { get; set; }
		public string MENSAGEM_9 { get; set; }
		public string MENSAGEM_10 { get; set; }
		public string MENSAGEM_11 { get; set; }
		public string MENSAGEM { get; set; }
	}
}
