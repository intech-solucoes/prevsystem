using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_FAT_AT83")]
	public class FatAt83Entidade
	{
		public decimal? IDADE { get; set; }
		public decimal? VALOR_QX { get; set; }
		public decimal? VALOR_LX { get; set; }
		public decimal? VALOR_DX { get; set; }
	}
}
