using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_ADESAO_PLANO")]
	public class AdesaoPlanoEntidade
	{
		[Key]
		public decimal OID_ADESAO_PLANO { get; set; }
		public decimal OID_ADESAO { get; set; }
		public string COD_PLANO { get; set; }
		public string DES_PLANO { get; set; }
		public string IND_REGIME_TRIBUTACAO { get; set; }
	}
}
