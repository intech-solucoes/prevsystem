using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CC_FICHA_FINANCEIRA")]
    public class FichaFinanceiraEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public decimal SEQ_CONTRIBUICAO { get; set; }
		public string CD_OPERACAO { get; set; }
		public decimal? SRC { get; set; }
		public decimal? REMUNERACAO { get; set; }
		public decimal? CONTRIB_PARTICIPANTE { get; set; }
		public decimal? CONTRIB_EMPRESA { get; set; }
		public decimal? DIF_CONTRIB_PARTICIPANTE { get; set; }
		public decimal? DIF_CONTRIB_EMPRESA { get; set; }
		public decimal? TAXA_ADM_PARTICIPANTE { get; set; }
		public decimal? TAXA_ADM_EMPRESA { get; set; }
		public decimal? QTD_COTA_RP_PARTICIPANTE { get; set; }
		public decimal? QTD_COTA_FD_PARTICIPANTE { get; set; }
		public decimal? QTD_COTA_RP_EMPRESA { get; set; }
		public decimal? QTD_COTA_FD_EMPRESA { get; set; }
		public string ANO_COMP { get; set; }
		public string MES_COMP { get; set; }
		public string CD_ORIGEM { get; set; }
		public string EXPORTADO { get; set; }
		public int? SEQ_PP_PR_PAR { get; set; }
		public decimal? ANO_PP_PR_PAR { get; set; }
		public int? SEQ_PP_PR_EMP { get; set; }
		public decimal? ANO_PP_PR_EMP { get; set; }
		public int? SEQ_PP_PR_TX_PAR { get; set; }
		public decimal? ANO_PP_PR_TX_PAR { get; set; }
		public int? SEQ_PP_PR_TX_EMP { get; set; }
		public decimal? ANO_PP_PR_TX_EMP { get; set; }
		public decimal? cd_perfil_invest { get; set; }
		public string COD_VINC { get; set; }
		public string ORIG_VINC { get; set; }
		public decimal? BENEF_RISCO_PARTICIPANTE { get; set; }
		public decimal? BENEF_RISCO_EMPRESA { get; set; }
		public DateTime? DT_MOVIMENTO { get; set; }
		public string USUARIO { get; set; }
		public DateTime? DATA_ALTERACAO { get; set; }
		public string OBS { get; set; }
		public string CALC_RESERVA { get; set; }
		public string CONTRIB_CANCELADA { get; set; }
		[Write(false)] public string DS_TIPO_CONTRIBUICAO { get; set; }
		[Write(false)] public decimal? TOTAL_CONTRIB { get; set; }
		[Write(false)] public decimal? QTD_COTA { get; set; }
		[Write(false)] public string DES_MES_REF { get; set; }
		[Write(false)] public string CALC_MARGEM_CONSIG { get; set; }
		[Write(false)] public string COMPOE_SALDO_BENEFICIO { get; set; }
        
    }
}
