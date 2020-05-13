using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_SALARIO_BASE")]
	public class SalarioBaseEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string NUM_MATRICULA { get; set; }
		public DateTime DT_BASE { get; set; }
		public decimal? VL_SALARIO { get; set; }
		public decimal? VL_SALARIO_13 { get; set; }
		public decimal? VL_SALARIO_NAOINCORP { get; set; }
		public decimal? VL_SALARIO_NAOINCORP_13 { get; set; }
		public decimal? VL_SALARIO_PROPORCIONAL { get; set; }
		public string IND_NAOINCORPORAVEL { get; set; }
	}
}
