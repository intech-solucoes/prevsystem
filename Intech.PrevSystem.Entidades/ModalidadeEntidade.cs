using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_MODALIDADE")]
    public class ModalidadeEntidade
    {
		public decimal CD_MODAL { get; set; }
		public string DS_MODAL { get; set; }
		public string CREDITO_UNICO { get; set; }
		public decimal? DIA_CREDITO { get; set; }
		public decimal MES_CALC_CRED { get; set; }
		public string DT_CRED_FSF { get; set; }
		public string ANTECIPAR { get; set; }
		public decimal? DIA_ANTECIPACAO { get; set; }
		public decimal? MES_CALC_ANTECIP { get; set; }
		public string DT_ANTEC_FSF { get; set; }
		public string COD_IND { get; set; }
		public string RESULTADO_ANTEC { get; set; }
		public string CORRIGIR { get; set; }
		public string RESULTADO_CORRE { get; set; }
		public decimal? MAX_CONTR_ATIVOS { get; set; }
		public string GERAR_PREST { get; set; }
		public string CORRECAO_MONET { get; set; }
		public string SOMA_TAXAS_PREST { get; set; }
		public string SOMA_CORR_PREST { get; set; }
		public string TIPO_CALC_PREST { get; set; }
		public string TIPO_CORR_PREST { get; set; }
		public string EXIGE_FIADOR { get; set; }
		public string EXIGE_REPRES { get; set; }
		public string ALT_VL_REMUNERACAO { get; set; }
		public string ALT_VL_DESCONTO { get; set; }
		public string ALT_VL_PRESTACAO { get; set; }
		public string DIA_CORRECAO { get; set; }
		public string VL_DESC_MENOR_PRESTACAO { get; set; }
		public string VL_DESC_MAIOR_PRESTACAO { get; set; }
		public string IND_CORR_PREST { get; set; }
		public string IND_CORR_VL_SOLIC { get; set; }
		public string ANTECIPACAO_UNICA { get; set; }
		public decimal? DIA_UNICO_ATEC { get; set; }
		public string PREV_REC_PREST { get; set; }
		public string PRORATA_TX_JUROS { get; set; }
		public string INCLUIR_OUTROS_DEBITOS { get; set; }
		public string COBRAR_PA_CONCESSAO { get; set; }
		public string TIPO_JUROS_MORA { get; set; }
		public string BASE_CALC_ANTECIPACAO { get; set; }
		public string JUROS_CONTRATO_ANTEC { get; set; }
		public string EXIGE_FIADOR_OCASIAO { get; set; }
		public string ALT_VL_MARGEM { get; set; }
		public string DIF_DIAS { get; set; }
		public decimal? DIA_CORR_INFORMADO { get; set; }
		public string SITUACAO { get; set; }
		public string RECEBER_PRESTACAO_PARCIAL { get; set; }
		public string SALDO_REFORMA { get; set; }
		public string REC_PRESTACAO_PARCIAL_MES { get; set; }
		public string TIPO_DEBITOS { get; set; }
		public string RECEBE_VL_PARCIAL_AMENOR { get; set; }
		public string ENCARGOS_PREST_REAL { get; set; }
		public string COBRAR_PM_CONCESSAO { get; set; }
		public string REF_MODALIDADES { get; set; }
		public string PREST_ORIG_REC_REFORMA { get; set; }
		public string PREST_ORIG_REC_QUIT_MANUAL { get; set; }
		public string AVALISTA { get; set; }
		public decimal? TMP_VINC_AVALISTA { get; set; }
		public string BLOQUEIO_COBRANCA { get; set; }
		[Write(false)] public List<NaturezaEntidade> Naturezas { get; set; }
        
    }
}
