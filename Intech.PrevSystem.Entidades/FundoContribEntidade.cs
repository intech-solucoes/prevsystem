using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_FUNDO_CONTRIB")]
	public class FundoContribEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public decimal CD_FUNDO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string CD_MANTENEDORA { get; set; }
		public string CD_OPERACAO { get; set; }
	}
}
