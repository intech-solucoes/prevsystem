using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_HIST_RENDAS")]
	public class HistRendasEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public decimal NUM_PROCESSO { get; set; }
		public string ANO_PROCESSO { get; set; }
		public DateTime DT_INIC_VALIDADE { get; set; }
		public string CD_MOT_ALT_RENDA { get; set; }
		public string CD_OPCAO_RECEB { get; set; }
		public decimal? VL_RENDA_FUNDACAO { get; set; }
		public decimal? VL_RENDA_PREVIDENCIA { get; set; }
		public decimal? VL_SAL_BENEF_FUNDACAO { get; set; }
		public decimal? VL_SAL_BENEF_PREVIDENCIA { get; set; }
		public decimal? VL_PARCELA_MENSAL { get; set; }
		public decimal VERSAO { get; set; }
		public decimal? VL_ABONO_APOSENT { get; set; }
		public decimal? VL_BENEF_MINIMO { get; set; }
		public decimal? VL_BASE_SRB { get; set; }
		public decimal? VL_BASE_PREVIDENCIA { get; set; }
		public decimal? VL_BASE_AB_APOSENT { get; set; }
		public string BONUS_SUPLEMENTAR { get; set; }
		public decimal? VL_ABONO_APOS_SLIM { get; set; }
		public decimal? VL_INSS_SLIM { get; set; }
		public string RENDA_INSS_MIN { get; set; }
		public string OPCAO_RECB_13 { get; set; }
		public decimal? VL_TX_ANUAL { get; set; }
		public decimal? CD_TIPO_CALC_CD { get; set; }
		public decimal? VL_SRC_CONTRIB_AUX_DOENCA { get; set; }
		public decimal? NUM_TOT_PARCELAS { get; set; }
		public decimal? VL_SAL_BENEF_JUDICIAL { get; set; }
		public decimal? PERC_RESERVA { get; set; }
		public decimal? VL_IND_COTA { get; set; }
	}
}
