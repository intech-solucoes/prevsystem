using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_MARGENS_PLANO")]
    public class MargensPlanoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime DT_VIGENCIA { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal CD_NATUR { get; set; }
		public string TP_SALDO_RP { get; set; }
		public string TP_TX_ATIVO { get; set; }
		public decimal? TX_ATIVO_RP { get; set; }
		public decimal? TX_ATIVO_SP { get; set; }
		public decimal? TX_ATIVO_CR { get; set; }
		public decimal? TX_ATIVO_MC { get; set; }
		public decimal? VL_ATIVO_RP { get; set; }
		public decimal? VL_ATIVO_SP { get; set; }
		public decimal? VL_ATIVO_CR { get; set; }
		public decimal? TETO_MAXIMO_ATIVO { get; set; }
		public string TP_BENEFICIO { get; set; }
		public decimal? TX_ASSIST_BL { get; set; }
		public decimal? TX_ASSIST_BB { get; set; }
		public decimal? VL_ASSIST_BL { get; set; }
		public decimal? VL_ASSIST_BB { get; set; }
		public decimal? TETO_MAXIMO_ASSIST { get; set; }
		public decimal? TX_ASSIST_MC { get; set; }
		public string SSCA_ASSIST { get; set; }
		public string SSCA_ATIVO { get; set; }
		public decimal? TX_ATIVO_PREST_SP { get; set; }
		public decimal? VL_ATIVO_PREST_SP { get; set; }
		public decimal? TX_ASSIST_PREST_BL { get; set; }
		public decimal? VL_ASSIST_PREST_BL { get; set; }
		public string TP_DT_CONV_RP { get; set; }
		public string TP_TX_ASSIST { get; set; }
		public string MARGEM_CSA_EXTERNA { get; set; }
		public decimal? TX_FIADOR_ATIVO_RP { get; set; }
		public string MARGEM_BPA_EXTERNA { get; set; }
		public decimal? TX_ASSIST_RMV { get; set; }
		public decimal? VL_ASSIST_RMV { get; set; }
		public decimal? TX_ASSIST_PREST_CP { get; set; }
		public string ID_ATIVOS_SAD { get; set; }
		public decimal? TX_ATIVO_PREST_MEDIA_SP { get; set; }
		public decimal? TX_ASSISTIDO_PREST_MEDIA_SP { get; set; }
		public string DT_CONVERSAO_RP { get; set; }
		public decimal? TX_MANTENEDOR_RP { get; set; }
		public decimal? VL_MANTENEDOR_RP { get; set; }
		public decimal? TX_MANTENEDOR_PREST_SP { get; set; }
		public decimal? VL_MANTENEDOR_PREST_SP { get; set; }
		public decimal? QTD_ASSIST_SAL_MININO { get; set; }
		public decimal? TX_MANTENEDOR_CR { get; set; }
		public decimal? TX_MANTENEDOR_SP { get; set; }
		public decimal? VL_MANTENEDOR_CR { get; set; }
		public decimal? VL_MANTENEDOR_SP { get; set; }
		public decimal? TETO_MAXIMO_MANTENEDOR { get; set; }
		public string SSCA_MANTENEDOR { get; set; }
		public decimal? TX_DIFERIDO_CR { get; set; }
		public decimal? VL_DIFERIDO_CR { get; set; }
		public decimal? TX_DIFERIDO_RP { get; set; }
		public decimal? VL_DIFERIDO_RP { get; set; }
		public decimal? TX_DIFERIDO_SP { get; set; }
		public decimal? VL_DIFERIDO_SP { get; set; }
		public decimal? TETO_MAXIMO_DIFERIDO { get; set; }
		public string SSCA_DIFERIDO { get; set; }
		public decimal? TX_DIFERIDO_PREST_SP { get; set; }
		public decimal? VL_DIFERIDO_PREST_SP { get; set; }
		public decimal? PERC_PREST_MIN_ATIVO { get; set; }
		public string TIPO_PREST_MIN_ATIVO { get; set; }
		public decimal? PERC_PREST_MIN_ASSISTIDO { get; set; }
		public string TIPO_PREST_MIN_ASSISTIDO { get; set; }
		public decimal? PERC_PREST_MIN_MANTENEDOR { get; set; }
		public string TIPO_PREST_MIN_MANTENEDOR { get; set; }
		public decimal? PERC_PREST_MIN_DIFERIDO { get; set; }
		public string TIPO_PREST_MIN_DIFERIDO { get; set; }
		public decimal? TETO_MINIMO_ATIVO { get; set; }
		public decimal? TETO_MINIMO_ASSISTIDO { get; set; }
		public decimal? TETO_MINIMO_MANTENEDOR { get; set; }
		public decimal? TETO_MINIMO_DIFERIDO { get; set; }
		public decimal? TX_FIADOR_ATIVO_SP { get; set; }
		public decimal? TX_FIADOR_ATIVO_CR { get; set; }
		public decimal? TX_FIADOR_ASSIST_BL { get; set; }
		public decimal? TX_FIADOR_ASSIST_BB { get; set; }
		public decimal? VL_TETO_MINIMO_FIADOR_ATIVO { get; set; }
		public decimal? VL_TETO_MINIMO_FIADOR_ASSIST { get; set; }
		public decimal? PR_MAX_AVALIZADO_ATIVO { get; set; }
		public decimal? PR_MAX_AVALIZADO_ASSIST { get; set; }
		public string LIMITE_AVALIZADO_ATIVO { get; set; }
		public string LIMITE_AVALIZADO_ASSIST { get; set; }
		public decimal? PERC_LIM_DISP_ATIVO { get; set; }
		public decimal? PERC_LIM_DISP_ASSISTIDO { get; set; }
		public decimal? PERC_LIM_DISP_MANTENEDOR { get; set; }
		public decimal? PERC_LIM_DISP_DIFERIDO { get; set; }
		public string ID_SALARIO_ATIVO { get; set; }
		public string ID_SALARIO_ASSISTIDO { get; set; }
		public string ID_SALARIO_AUTOPATROCINADO { get; set; }
		public string ID_SALARIO_DIFERIDO { get; set; }
		public decimal? TETO_MAX_REFORMA_ASSIST { get; set; }
		public string DT_CONVERSAO_RP_AP { get; set; }
		public string TP_DT_CONV_RP_AP { get; set; }
		public string TP_SALDO_RP_AP { get; set; }
		public string DT_MAX_IND_AT { get; set; }
		public string DT_MAX_IND_AP { get; set; }
		public string DT_MAX_IND_DF { get; set; }
		public string TP_SALDO_RP_DF { get; set; }
		public string TP_DT_CONV_RP_DF { get; set; }
		public string DT_CONVERSAO_RP_DF { get; set; }
		public string RESGATE_RESERVA_AT { get; set; }
		public string RESGATE_RESERVA_AP { get; set; }
		public string RESGATE_RESERVA_DF { get; set; }
		public decimal? TX_ATIVO_VINC_MAIOR_SP { get; set; }
		public decimal? VL_ATIVO_VINC_MAIOR_SP { get; set; }
		public decimal? TX_ATIVO_VINC_MENOR_SP { get; set; }
		public decimal? VL_ATIVO_VINC_MENOR_SP { get; set; }
		public string TMP_VINC_PATROC { get; set; }
		public decimal? QTD_MESES_VINC { get; set; }
		public string ID_INSS { get; set; }
        
    }
}
