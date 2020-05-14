using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_UNID_FED")]
	public class UFEntidade
	{
		[Key]
		public string CD_UNID_FED { get; set; }
		public string DS_UNID_FED { get; set; }
		public string FX1_INIC_CEP_UF { get; set; }
		public string FX1_TERM_CEP_UF { get; set; }
		public string FX2_INIC_CEP_UF { get; set; }
		public string FX2_TERM_CEP_UF { get; set; }
	}
}
