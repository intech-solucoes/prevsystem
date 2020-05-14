using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_PERFIL_INVEST_INDICE")]
	public class PerfilInvestIndiceEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public decimal CD_PERFIL_INVEST { get; set; }
		public DateTime DT_REF { get; set; }
		public string CD_CT_RP { get; set; }
		public string CD_CT_FD { get; set; }
		public string CD_CT_PS { get; set; }
		public int? NUM_PERFIL { get; set; }
	}
}
