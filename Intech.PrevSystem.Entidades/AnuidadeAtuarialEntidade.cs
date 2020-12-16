using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_ANUIDADE_ATUARIAL")]
	public class AnuidadeAtuarialEntidade
	{
		public decimal? IDADE { get; set; }
		public decimal? VL_ANUID_AX { get; set; }
		public decimal? VL_ANUID_CX { get; set; }
		public decimal? VL_ANUID_DX { get; set; }
		public decimal? VL_ANUID_LX { get; set; }
		public decimal? VL_ANUID_HX { get; set; }
		public decimal? VL_ANUID_AXAA { get; set; }
		public decimal? VL_ANUID_DAAX { get; set; }
	}
}
