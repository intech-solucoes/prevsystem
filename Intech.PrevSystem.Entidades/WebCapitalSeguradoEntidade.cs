using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_CAPITAL_SEGURADO")]
	public class WebCapitalSeguradoEntidade
	{
		[Key]
		public decimal OID_CAPITAL_SEGURADO { get; set; }
		public string NOM_SEGURADO { get; set; }
		public string COD_CPF { get; set; }
		public decimal VAL_CAP_SEG_MORTE { get; set; }
		public decimal VAL_CAP_SEG_INVALIDEZ { get; set; }
	}
}
