using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_FERIADO")]
	public class FeriadoEntidade
	{
		public string LOCAL { get; set; }
		public DateTime DT_FERIADO { get; set; }
	}
}
