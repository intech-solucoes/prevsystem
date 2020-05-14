using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_NACIONALIDADE")]
	public class NacionalidadeEntidade
	{
		[Key]
		public string CD_NACIONALIDADE { get; set; }
		public string DS_NACIONALIDADE { get; set; }
		public string CD_PAIS_EFINANCEIRA { get; set; }
	}
}
