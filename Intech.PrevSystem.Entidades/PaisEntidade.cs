using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_PAIS")]
	public class PaisEntidade
	{
		[Key]
		public string CD_PAIS { get; set; }
		public string DS_PAIS { get; set; }
		public string CD_PAIS_EFINANCEIRA { get; set; }
	}
}
