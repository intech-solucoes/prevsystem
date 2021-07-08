using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CE_RUBRICA_DESCONTO")]
	public class RubricaDescontoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal CD_NATUR { get; set; }
		public decimal SEQ_RUBRICA { get; set; }
		public string RUB_ATIVO { get; set; }
		public string RUB_ASSISTIDO { get; set; }
		public string RUB_AUXILIAR_ATIVO { get; set; }
		public string RUB_AUXILIAR_ASSISTIDO { get; set; }
		public string RUB_INAD_ATIVO { get; set; }
		public string RUB_INAD_ASSISTIDO { get; set; }
		public string RUB_AUXILIAR_INAD_ATIVO { get; set; }
		public string RUB_AUXILIAR_INAD_ASSISTIDO { get; set; }
	}
}