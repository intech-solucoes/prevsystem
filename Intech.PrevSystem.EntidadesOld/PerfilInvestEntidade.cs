using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_PERFIL_INVEST")]
    public class PerfilInvestEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public decimal CD_PERFIL_INVEST { get; set; }
		public string DS_PERFIL_INVEST { get; set; }
		public DateTime? DT_INI_VIGENCIA { get; set; }
		public DateTime? DT_FIM_VIGENCIA { get; set; }
		public decimal? IDADE_LIMITE { get; set; }
		public decimal? CD_PLANO_PERFIL_CONTABIL { get; set; }
		public string NAT_PP_ATIVO { get; set; }
		public string NAT_PR_ATIVO { get; set; }
		public string TP_APLIC_ATIVO { get; set; }
		public string NAT_PP_BENEF { get; set; }
		public string NAT_PR_BENEF { get; set; }
		public decimal? CD_PERFIL_INVEST_AUTO { get; set; }
		public string CD_GESTOR { get; set; }
		public string CD_FUNDO { get; set; }
		[Write(false)] public List<TaxaEvolPerfilEntidade> TaxasProjetadas { get; set; }
        
    }
}
