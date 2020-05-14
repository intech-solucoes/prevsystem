using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("DR_PARAMETROS_RESGATE")]
	public class ParametrosResgateEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string CD_TIPO_RESGATE { get; set; }
		public string CD_INDICE_PARTICIPANTE { get; set; }
		public decimal? VLR_PERC_PARTICIPANTE { get; set; }
		public decimal? QTD_DIAS_CONV_PARTICIPANTE { get; set; }
		public string TIPO_COTA_PARTICIPANTE { get; set; }
		public string CONV_DT_CRED_PARTICIPANTE { get; set; }
		public string CD_INDICE_EMPRESA { get; set; }
		public decimal? VLR_PERC_EMPRESA { get; set; }
		public decimal? QTD_DIAS_CONV_EMPRESA { get; set; }
		public string TIPO_COTA_EMPRESA { get; set; }
		public string CONV_DT_CRED_EMPRESA { get; set; }
		public decimal? MESES_CARENCIA_PLANO { get; set; }
		public decimal? MESES_CARENCIA_EMPRESA { get; set; }
		public string PERC_IDADE_PARTICIPANTE { get; set; }
		public string PERC_IDADE_EMPRESA { get; set; }
		public decimal? MESES_CARENCIA_PLANO_EMP { get; set; }
		public decimal? MESES_CARENCIA_EMPRESA_EMP { get; set; }
		public string CALC_JUROS_PART { get; set; }
		public string CALC_JUROS_EMP { get; set; }
		public decimal? VL_PERC_JUROS_PART { get; set; }
		public decimal? VL_PERC_JUROS_EMP { get; set; }
		public string ADIC_RES_PART { get; set; }
		public string ADIC_RES_EMP { get; set; }
		public string DEB_CONTRIB_PARTICIPANTE { get; set; }
		public string CRED_CONTRIB_PARTICIPANTE { get; set; }
		public string CD_CRED_CTR_PARTICIPANTE { get; set; }
		public string DEB_CONTRIB_EMPRESA { get; set; }
		public string CRED_CONTRIB_EMPRESA { get; set; }
		public string CD_CRED_CTR_EMPRESA { get; set; }
		public string CALCULA_IRRF_PART { get; set; }
		public string CALCULA_IRRF_EMPR { get; set; }
		public decimal? MESES_CAR_ULT_CONTRIB_PART { get; set; }
		public decimal? MESES_CAR_ULT_CONTRIB_EMP { get; set; }
		public string DESC_IRRF_EMPRESTIMO { get; set; }
	}
}
