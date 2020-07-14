using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_RUBRICAS_PREVIDENCIAL")]
	public class RubricasPrevidencialEntidade
	{
		public string CD_RUBRICA { get; set; }
		public string CD_CONSIGNATARIO { get; set; }
		public string CD_RUBRICA_IRRF { get; set; }
		public string CD_RUBRICA_CONTR { get; set; }
		public string CD_RUBRICA_PJUD { get; set; }
		public string DS_RUBRICA { get; set; }
		public string CD_RETENCAO_DIRF { get; set; }
		public string CALC_FUNDACAO { get; set; }
		public string CALC_COTA_EXCEDENTE { get; set; }
		public string CD_LANCAMENTO { get; set; }
		public string INCID_CONTR_ANUAL { get; set; }
		public string INCID_CONTR_MENSAL { get; set; }
		public string INCID_IRRF_ANUAL { get; set; }
		public string INCID_IRRF_MENSAL { get; set; }
		public string INCID_PJUD_ANUAL { get; set; }
		public string INCID_PJUD_MENSAL { get; set; }
		public string TIPO_MES_DIRF { get; set; }
		public string PRIORID_DESCONTO { get; set; }
		public string REVISAO_PROCESSO { get; set; }
		public string RUB_DESC_REV_PROC { get; set; }
		public string RUB_PROV_REV_PROC { get; set; }
		public string SINAL_OPERACAO_DIRF { get; set; }
		public string TIPO_CAMPO_DIRF { get; set; }
		public string TP_LANCAMENTO { get; set; }
		public string EMITE_FOLHA { get; set; }
		public string INCID_LIQUIDO { get; set; }
		public string PROVISAO_CONTAB { get; set; }
		public string COMP_REL_GERENCIAL { get; set; }
		public string PROVISAO_CONTAB_CONTRIB { get; set; }
		public string CD_RUB_CM { get; set; }
		public string TIPO_MES_DIRF2 { get; set; }
		public string SINAL_OPERACAO_DIRF2 { get; set; }
		public string TIPO_CAMPO_DIRF2 { get; set; }
		public string RUBRICA_PROV_DESC { get; set; }
		public string CD_RUBRICA_CPMF { get; set; }
		public string CD_RUB_CONTRIB_REV { get; set; }
		public string CD_RUB_IRRF_REV { get; set; }
		public string CD_RUB_PJUD_REV { get; set; }
		public string CD_RUB_CPMF_REV { get; set; }
		public string CD_RUB_CM_NEG { get; set; }
		public string CC_FOLHAS_AUTORIZADAS { get; set; }
		public string INCID_MARGEM_CONSIG { get; set; }
		public string COMPOE_RENDA_COMPL { get; set; }
		public string CD_RUB_RCOMPL_ADIANT { get; set; }
		public string CD_RUB_RCOMPL_ABONO { get; set; }
		public string COMPOE_LIQ_DESC { get; set; }
		public string INCID_FAT_RED { get; set; }
		public string INCID_DESC_MARGEM { get; set; }
		public string PROVISAO_CONTAB_CONTPAT { get; set; }
		public string INCID_DESC_MARGEM_FOLHA { get; set; }
		public string INCID_COMP_SALARIAL { get; set; }
		public string INCID_CONTRIB_ASSOC { get; set; }
		public string INCID_CONTRIB_EMPREG { get; set; }
		public string INCID_CONTRIB_SIND { get; set; }
		public string ID_RUB_SUPLEMENTACAO { get; set; }
		public string ID_RUB_CONTRIBUICAO { get; set; }
		public string CD_RUB_PAGTO_UNICO { get; set; }
		public string CD_RUB_PROPORCIONAL { get; set; }
		public string CD_RUB_RETROATIVO { get; set; }
		public string CD_RUB_DEPARA { get; set; }
		public string RUB_DESC_MARGEM { get; set; }
		public string DESC_CONTRIB_ASSISTENCIAL { get; set; }
		public string ID_RUB_EMPRESTIMO { get; set; }
		public string INCID_MASSA_FIXA { get; set; }
		public string INCID_SRB { get; set; }
		public string INCID_INSS { get; set; }
		public string INCID_ABONO_ANUAL { get; set; }
		public string INCID_ADIANT_ABONO_ANUAL { get; set; }
		public string REGRA_DESCONTO { get; set; }
		public string ID_RUB_AUTORIZADA { get; set; }
		public string CD_TIPO_FOLHA_CONV { get; set; }
		public string CD_RUB_REV_PROV { get; set; }
		public string CD_RUB_REV_DESC { get; set; }
		public string CD_REL_COLUNA { get; set; }
		public string RUB_CONSIG_COMP { get; set; }
		public string RUB_CONSIG_VOLUNT { get; set; }
		public decimal? CD_RUBRICA_CF { get; set; }
		public string ID_RUB_PA { get; set; }
		public string INCID_COTA { get; set; }
		public string ID_CALCULO_AUTOMATICO { get; set; }
		public decimal? CD_CALCULO { get; set; }
		public string RESGATE_COTAS { get; set; }
		public string AQUISICAO_COTAS { get; set; }
		public string PRIORID_CALCULO { get; set; }
		public string ID_RUB_IRJU { get; set; }
		public string RUB_NCOMP_QTD_PARC { get; set; }
		public string ID_RUB_IREXT { get; set; }
		public string ID_RUB_PSAUDE { get; set; }
		public string ID_RUB_PECULIO { get; set; }
		public string INCID_IN1452 { get; set; }
		public string ID_RUB_AUXILIO { get; set; }
		public string ID_RUB_BITRIBUTACAO { get; set; }
		public string CD_CONSIGNATARIO_PR { get; set; }
		public string INCID_REAJUSTE { get; set; }
		public string ID_RUB_TAXA_ADM { get; set; }
		public string COD_PP_TPPRODUTO { get; set; }
	}
}
