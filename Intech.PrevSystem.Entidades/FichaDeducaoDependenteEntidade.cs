using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_FICHA_DEDUCAO_DEPENDENTE")]
	public class FichaDeducaoDependenteEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public int SEQ_RECEBEDOR { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public string ABONO_ANUAL { get; set; }
		public decimal VL_DEDUCAO { get; set; }
	}
}
