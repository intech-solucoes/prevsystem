using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_RECEBEDOR_BENEFICIO")]
	public class RecebedorBeneficioEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public int SEQ_RECEBEDOR { get; set; }
		public string CD_FORMA_PAG { get; set; }
		public string CD_SITUACAO { get; set; }
		public string CD_MOT_SITUACAO { get; set; }
		public string CD_TIPO_RECEBEDOR { get; set; }
		public string CD_EMPRESA { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal? NUM_SEQ_GR_FAMIL { get; set; }
		public string TIPO_CALC_CONTRIB { get; set; }
		public string CD_QUALID_RECEB { get; set; }
		public string DESC_ASSOCIACAO { get; set; }
		public string CD_TIPO_RETENCAO { get; set; }
		public string CD_MOT_ISENCAO { get; set; }
		public int COD_ENTID { get; set; }
		public DateTime? DT_NASCIMENTO { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string FAIXA_SEGURO_VIDA { get; set; }
		public string DESC_MENS_SINDICAL { get; set; }
		public string DESC_ASSOC_EMPREG { get; set; }
		public DateTime? DT_INIC_ISENC_IRRF { get; set; }
		public DateTime? DT_TERM_ISENC_IRRF { get; set; }
		public string CD_LOCALIDADE { get; set; }
		public string RATEIO_INDIVIDUAL { get; set; }
		public decimal? PERC_RATEIO_INDIVIDUAL { get; set; }
		public string COD_DESTINO_CH { get; set; }
		public string NUM_INSCRICAO_RECEB { get; set; }
		public string PAGA_CONTRIB_PATRONAL { get; set; }
		public decimal? PERC_CONTRIB_PATRONAL { get; set; }
		public string DESC_ANUIDADE { get; set; }
		public decimal? PERC_RETENCAO_JUDICIAL { get; set; }
		public string CONVENIADO_PREV { get; set; }
		public DateTime? DT_RECADASTRO { get; set; }
		public string NU_IDENT { get; set; }
		public string ORG_EMIS_IDENT { get; set; }
		public string PIS { get; set; }
		public string SEXO { get; set; }
		public string CD_ESTADO_CIVIL { get; set; }
		public decimal? QTD_DEP_IRRF { get; set; }
		public decimal? PERC_CONTRIB_ASSIST { get; set; }
		public string CD_SEGURADORA { get; set; }
		public string NUM_MATRICULA_EXTERNA { get; set; }
		public int? CREDOR_IRRF_JUDICIAL { get; set; }
		public string NUM_PROCESSO_PREV { get; set; }
		public string ABATE_IDOSO_IRRF { get; set; }
		public decimal? PERC_ISENCAO_IRRF { get; set; }
		public string MSG_INFORME { get; set; }
		public decimal? VAL_INSS_LIQ { get; set; }
		public string CD_GRUPO_PREV { get; set; }
		public string VINCULADO { get; set; }
		public string TIPO_VINCULADO { get; set; }
		public DateTime? DT_DESVINCULO { get; set; }
		public decimal? PERC_ISENCAO_IRRF_TOTAL { get; set; }
		public string PL_SAUDE { get; set; }
		public int? CD_TIPO_PLANO { get; set; }
		public int? TOT_DEP_PSAUDE { get; set; }
		public decimal? CD_PSAUDE { get; set; }
		public string BLOQUEIA_ADIANT { get; set; }
		public string IMP_DEMO_PGTO { get; set; }
		public string CD_MOEDA_RMENSAL { get; set; }
		public string ENVIA_CC_MAIL { get; set; }
		public string IND_CONTRIB_DED_IRRF { get; set; }
		public DateTime? DATA_INCLUSAO { get; set; }
		public int? TIPO_CID { get; set; }
	}
}