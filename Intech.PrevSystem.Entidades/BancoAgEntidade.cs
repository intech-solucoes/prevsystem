using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_BANCO_AG")]
	public class BancoAgEntidade
	{
		public string COD_BANCO { get; set; }
		public string COD_AGENC { get; set; }
		public string DESC_BCO_AG { get; set; }
		public string CD_UNID_FED { get; set; }
		public string CD_COMP_AGENCIA { get; set; }
		public string PRACA_AGENCIA { get; set; }
		public int? COD_ENTID { get; set; }
		public string GERENTE_AG { get; set; }
		public string CEP_AG { get; set; }
	}
}
