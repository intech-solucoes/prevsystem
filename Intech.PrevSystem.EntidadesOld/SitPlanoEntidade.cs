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
		public string sit_plano_muda_perfil { get; set; }
		public string perfil_automatico { get; set; }
		public string altera_salario_em { get; set; }
		public string permite_emprestimo_em { get; set; }
		public string EXP_RUB_FOLHA_PGTO { get; set; }
		public string AUX_DOENCA { get; set; }
        
    }
}
