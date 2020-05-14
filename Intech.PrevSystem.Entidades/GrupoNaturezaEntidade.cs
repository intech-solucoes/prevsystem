using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_GRUPO_NATUREZA")]
	public class GrupoNaturezaEntidade
	{
		public decimal CD_GRUPO { get; set; }
		public string DS_GRUPO { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal? MAX_CONTR_ATIVOS { get; set; }
		public string CD_PLANO { get; set; }
	}
}
