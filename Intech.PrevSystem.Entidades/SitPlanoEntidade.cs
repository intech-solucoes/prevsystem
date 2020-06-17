using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_SIT_PLANO")]
	public class SitPlanoEntidade
	{
		public string CD_SIT_PLANO { get; set; }
		public string DS_SIT_PLANO { get; set; }
		public string CD_CATEGORIA { get; set; }
		public string ATUALIZA_DADOS { get; set; }
		public string CONTRIBUI { get; set; }
		public string PERMITE_RESGATE { get; set; }
		public string RESGATE { get; set; }
		public string ALERTA_EM { get; set; }
		public string COBRAR_TX_EMP { get; set; }
		public decimal? CD_PERFIL_INVEST_DEFAULT { get; set; }
		public string SIT_PLANO_MUDA_PERFIL { get; set; }
		public string PERFIL_AUTOMATICO { get; set; }
		public string ALTERA_SALARIO_EM { get; set; }
		public string PERMITE_EMPRESTIMO_EM { get; set; }
		public string EXP_RUB_FOLHA_PGTO { get; set; }
		public string AUX_DOENCA { get; set; }
		[Write(false)] public string altera_salario_em { get; set; }
	}
}
