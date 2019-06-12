using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_PROCESSOS_BENEFICIO")]
    public class ProcessoBeneficioEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public decimal NUM_PROCESSO { get; set; }
		public string ANO_PROCESSO { get; set; }
		public decimal VERSAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PERFIL_INVESTIM { get; set; }
		public DateTime? DT_PROX_PAGTO { get; set; }
		public DateTime? DT_TERMINO { get; set; }
		public DateTime? DT_RETROATIVIDADE { get; set; }
		public DateTime? DT_CONCESSAO { get; set; }
		public decimal? NUM_TOT_PARCELAS { get; set; }
		public decimal? NUM_PARCELAS_PAG { get; set; }
		public decimal? SALDO_INICIAL { get; set; }
		public decimal? SALDO_ATUAL { get; set; }
		public decimal? SALDO_ANTERIOR { get; set; }
		public string TIPO_CALCULO { get; set; }
		public string CD_SITUACAO { get; set; }
		public string CD_CARGO { get; set; }
		public string CD_NIVEL_SALARIAL { get; set; }
		public decimal? VL_PERC_RESGATE { get; set; }
		public decimal? VL_PARC_RESGATE { get; set; }
		public decimal? VL_FATOR_REDUTOR { get; set; }
		public decimal? VL_REDUTOR_ATUARIAL { get; set; }
		public DateTime? DT_REINICIO_PAGTO { get; set; }
		public string NUM_PROCESSO_PREV { get; set; }
		public DateTime? DT_INI_REVISAO { get; set; }
		public decimal? FATOR_VINCULACAO { get; set; }
		public decimal? FATOR_ALIQUOTA { get; set; }
		public string CD_OPCAO_RECEB_RENDA { get; set; }
		public string CD_OPCAO_RECEB_BP { get; set; }
		public string CD_OPCAO_RECEB_BAV { get; set; }
		public DateTime? DT_INICIO_RENDA { get; set; }
		public DateTime? DT_INICIO_BP { get; set; }
		public DateTime? DT_INICIO_BAV { get; set; }
		public DateTime? DT_TERMINO_RENDA { get; set; }
		public DateTime? DT_TERMINO_BP { get; set; }
		public DateTime? DT_TERMINO_BAV { get; set; }
		public decimal? PRAZO_RECEB { get; set; }
		public DateTime? DT_ULTIMO_PROCESSAMENTO { get; set; }
		public decimal? CD_TIPO_CALC_CD { get; set; }
		public string PROC_REVISAO { get; set; }
		public DateTime? DT_ULTIMA_REVISAO { get; set; }
		public decimal? SALDO_RISCO { get; set; }
		public DateTime? DT_PREV_PAGTO_SAQUE { get; set; }
		public DateTime? DT_PAGTO_SAQUE { get; set; }
		public string CD_CALC_REGRESSIVO { get; set; }
		public decimal? VL_PMP { get; set; }
		public string CD_PLANO_SALARIAL { get; set; }
		public string TIPO_PAGTO_TAXA { get; set; }
		public string ID_COMP_LIQUID { get; set; }
		public decimal? FATOR_REDUTOR { get; set; }
		public string ANT_PECUL_BENEF { get; set; }
		public decimal? PERC_REAJ_VR { get; set; }
		public decimal? SALDO_RVITALICIA { get; set; }
		public decimal? NUM_SEQ_DEP { get; set; }
		public string SEXO_DEP { get; set; }
		public DateTime? DT_NASC_DEP { get; set; }
		public DateTime? DT_VALIDADE_DEP { get; set; }
		public decimal? VL_ADICIONAL { get; set; }
		public decimal? VL_INDIVIDUAL { get; set; }
		public decimal? VL_GLOBAL { get; set; }
		public decimal? SALDO_PARTICIPANTE { get; set; }
		public decimal? SALDO_PATROCINADORA { get; set; }
		public DateTime? DT_OPCAO_BPD { get; set; }
		public int? PRAZO_DIFERIMENTO { get; set; }
		public decimal? SALDO_CUSTEIO_PLANO { get; set; }
		public decimal? VAL_CUST_ADM { get; set; }
		public decimal? VAL_CUST_FUNDO { get; set; }
		public decimal? SALDO_ANT_RISCO { get; set; }
		public decimal? SALDO_ATUAL_RISCO { get; set; }
		public decimal? PERC_SALDO_RISCO { get; set; }
		public decimal? SALDO_INIC_RISCO { get; set; }
		[Write(false)] public string DS_ESPECIE { get; set; }
		[Write(false)] public string DS_SITUACAO { get; set; }
		[Write(false)] public DateTime? DT_REQUERIMENTO { get; set; }
		[Write(false)] public DateTime? DT_AFASTAMENTO { get; set; }
		[Write(false)] public DateTime? DT_INICIO_PREV { get; set; }
		[Write(false)] public DateTime? DT_INICIO_FUND { get; set; }
		[Write(false)] public decimal? VL_PARCELA_MENSAL { get; set; }
		[Write(false)] public string DS_OPCAO_RECEB { get; set; }
		[Write(false)] public DateTime? DT_APOSENTADORIA { get; set; }
        
    }
}
