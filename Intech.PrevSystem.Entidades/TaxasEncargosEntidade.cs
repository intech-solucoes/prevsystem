using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_TAXAS_ENCARGOS")]
	public class TaxasEncargosEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public decimal SEQUENCIA { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal CD_NATUR { get; set; }
		public DateTime DT_INIC_VIGENCIA { get; set; }
		public DateTime? DT_TERM_VIGENCIA { get; set; }
		public decimal? TX_RENOVACAO { get; set; }
		public decimal? TX_ADM { get; set; }
		public decimal? TX_INAD { get; set; }
		public decimal? TX_SEGURO { get; set; }
		public decimal? PERIODO_CARENCIA { get; set; }
		public string TP_CARENCIA { get; set; }
		public decimal? TX_MULTA { get; set; }
		public decimal? TX_JUROS_MORA { get; set; }
		public string COD_IND_JU_MORA { get; set; }
		public string CONSIDERAR_MULTA { get; set; }
		public decimal? TX_IOF { get; set; }
		public decimal? VL_MIN_PREST { get; set; }
		public decimal? VL_MAX_PREST { get; set; }
		public string TP_COBRANCA_IOF { get; set; }
		public string TP_COBRANCA_TX { get; set; }
		public decimal? TX_SEGURO_ESPECIAL_ASSIST { get; set; }
		public decimal? LIMITE_SEGURO_ASSIST { get; set; }
		public decimal? TX_SEGURO_ESPECIAL_ATIVO { get; set; }
		public decimal? LIMITE_SEGURO_ATIVO { get; set; }
		public decimal? TX_PROVISAO_IRRF { get; set; }
		public string DIA_PRO_RATA_PREST { get; set; }
		public string DIA_PRO_RATA_SALDO { get; set; }
		public string CORRIGIR_PREST_ATRASO { get; set; }
		public string CORRIGIR_SALDO_DEV { get; set; }
		public string CONSIDERAR_JUROS_CONC { get; set; }
		public string COBRAR_JUROS_NA_REFORMA { get; set; }
		public string CONSIDERAR_CORR_PREST { get; set; }
		public string SEGURO_TABELADO { get; set; }
		public string CONSIDERAR_RENOVACOES_ADM { get; set; }
		public string CONSIDERAR_RENOVACOES_INAD { get; set; }
		public string CONSIDERAR_RENOVACOES_SEGUROS { get; set; }
		public string CARENCIA_DIA_UTIL { get; set; }
		public string CARENCIA_VENCIMENTO { get; set; }
		public string CORRIGE_SALDO_RENOVACAO { get; set; }
		public string CORRIGE_SALDO_QUITACAO_MANUAL { get; set; }
		public decimal? TX_PREST_MIN { get; set; }
		public string TP_COBRANCA_RENOV { get; set; }
		public string TP_COBRANCA_INAD { get; set; }
		public string TP_COBRANCA_SEGURO { get; set; }
		public string PRAZO_ADM { get; set; }
		public string IND_JU_MORA { get; set; }
		public string TIPO_IND_JU_MORA { get; set; }
		public string TIPO_CALC_ADM { get; set; }
		public string CONSIDERAR_TX_PREST { get; set; }
		public decimal? TX_PRESTACAO { get; set; }
		public string TP_SIT_PLANO { get; set; }
		public decimal? TX_IOF_FIXA { get; set; }
		public string TP_COBRANCA_IOF_FIXA { get; set; }
		public string CONSIDERAR_IOF_COMPL_INAD { get; set; }
		public decimal? TARIFA_BANCARIA { get; set; }
		public decimal? ADITIVO_CONCESSAO { get; set; }
		public decimal? ADITIVO_PRESTACAO { get; set; }
		public string IOF_IN1609 { get; set; }
		public string ID_PROJECAO_IND { get; set; }
		public string IND_PROJECAO { get; set; }
	}
}
