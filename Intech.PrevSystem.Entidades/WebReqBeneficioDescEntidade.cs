using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_REQ_BENEFICIO_DESC")]
	public class WebReqBeneficioDescEntidade
	{
		[Key]
		public decimal OID_REQ_BENEFICIO_DESC { get; set; }
		public decimal OID_REQ_BENEFICIO { get; set; }
		public decimal OID_DESC_AUTORIZADO { get; set; }
		public string IND_AUTORIZADO { get; set; }
	}
}
