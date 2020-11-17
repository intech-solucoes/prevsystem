using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TBG_BOLETO_AVULSO")]
	public class BoletoAvulsoEntidade
	{
		[Key]
		public decimal OID_BOLETO_AVULSO { get; set; }
		public string CPF { get; set; }
		public string MATRICULA { get; set; }
		public string NOME { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime DT_EMISSAO { get; set; }
		public decimal VALOR { get; set; }
	}
}
