using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_PARAMETROS")]
	public class ParametrosEntidade
	{
		public string VERSAO { get; set; }
		public string TIPO_CONTABILIZACAO { get; set; }
		public string TIPO_LANC_CONTABIL { get; set; }
		public string CT_POLI_OUTROS { get; set; }
		public string CF_POLI_OUTROS { get; set; }
		public string QT_POLI_OUTROS { get; set; }
		public string TIPO_COTAS { get; set; }
		public string SINAL_DEBITO { get; set; }
		public string SINAL_CREDITO { get; set; }
		public string CSA_POLI_OUTROS { get; set; }
		public string PBA_POLI_OUTROS { get; set; }
		public string CSA_BLOQUEIO { get; set; }
		public string IMP_DA_EMPR { get; set; }
		public string IMP_CONTRATOS { get; set; }
		public decimal? MAX_CONTR_ATIVOS { get; set; }
		public string CONTROLE_CONTR_ATIVOS { get; set; }
		public string CREDITO_BANCARIO { get; set; }
		public string LIMITA_CONCESSAO_RD { get; set; }
		public string VISUALIZA_CONTRATOS_REFORMAR { get; set; }
		public string TP_DT_REF_FOLHA { get; set; }
		public string TP_DT_COMP_FOLHA { get; set; }
		public string TP_APROPRIACAO { get; set; }
		public string CONTABILIZAR_PERDAS_INAD { get; set; }
		public string GERAR_PR_REC_MANUAL { get; set; }
		public string AGRUPAR_CONTABILIZACAO { get; set; }
		public string RE_INADIMPLENTES { get; set; }
		public string RE_SALDODEVEDOR { get; set; }
		public string RE_CONTABIL { get; set; }
		public string RE_VALORSOLICITADO { get; set; }
		public string RE_IMPORTAR_PRESTACAO { get; set; }
		public string RE_GERAR_PRESTACAO { get; set; }
		public string RE_APLICAR_CORRECAO { get; set; }
		public string RE_RECEBIMENTO_AUTOMATICO { get; set; }
		public string RE_RECURSO_DISPONIVEL { get; set; }
		public decimal? QTDE_CONTRATOS_AFIANCADOS { get; set; }
		public string CRITICA_FIADOR { get; set; }
		public string SRC_FIADOR_MAIOR_AFIANCADO { get; set; }
		public string RE_IMPORTAR_MARGEM { get; set; }
		public string CD_FORMA_PAGTO { get; set; }
		public DateTime? REF_INTEGR_CF { get; set; }
		public DateTime? DT_INTEGR_CF { get; set; }
		public string USUARIO_INTEGR_CF { get; set; }
		public string CRIA_DIR_TEMP { get; set; }
		public string RE_CARTEIRA_EMPRESTIMO { get; set; }
		public DateTime? DT_FECHAMENTO_CE { get; set; }
		public DateTime? REF_FECHAMENTO_CE { get; set; }
		public string USUARIO_FECHAMENTO_CE { get; set; }
		public string ALTERA_DADOS_BANCARIOS { get; set; }
		public decimal? VL_SALARIO_MINIMO { get; set; }
		public string RE_VALIDAR_PENDENTES { get; set; }
		public DateTime? DT_FECHAMENTO_CT { get; set; }
		public DateTime? REF_FECHAMENTO_CT { get; set; }
		public string USUARIO_FECHAMENTO_CT { get; set; }
		public string ID_LIMITE_DEPENDENTE { get; set; }
		public string GERAR_PR_EFETIVA_MOV { get; set; }
		public string INAD_SALDO_RENTAB { get; set; }
		public string INTEGR_CF_EMPRESA { get; set; }
		public string INTEGR_CF_PLANO { get; set; }
		public string INTEGR_CF_MODAL { get; set; }
		public string INTEGR_CF_NATUR { get; set; }
		public string INTEGR_CF_BANCO { get; set; }
		public string INTEGR_CF_FORMA_PAGAMENTO { get; set; }
		public string DEVEDOR_PR_EFETIVA_MOV { get; set; }
		public string EMPRESTIMO_CARIMBADO { get; set; }
		public decimal? EMPRESA_COMUM_CT { get; set; }
		public decimal? PLANO_COMUM_CT { get; set; }
		public decimal? PERC_PROV_1 { get; set; }
		public decimal? PERC_PROV_2 { get; set; }
		public decimal? PERC_PROV_3 { get; set; }
		public decimal? PERC_PROV_4 { get; set; }
		public string PROV_MULTA_MORA { get; set; }
		public decimal? SEQ_CARTAO_BANCO { get; set; }
		public string ID_LIMITE_BENEFICIO { get; set; }
		public string TP_AGRUPAMENTO_CONTABIL { get; set; }
		public string EXPORTAR_PREST_QUITADOS { get; set; }
		public string EMPRESTIMO_MULTI_PLANO { get; set; }
		public string EXPORTAR_PREST_INAD { get; set; }
		public string NUMERACAO_CONTRATO_ANUAL { get; set; }
		public string CREDITO_CONTRATO_SIMULACAO { get; set; }
		public string EXPORTAR_PREST_INAD_CTN { get; set; }
		public string CREDOR_PP_CF { get; set; }
		public string EXPORTAR_RUB_PLANO { get; set; }
		public int? PAR_EMITENTE_PP { get; set; }
		public string CONCESSAO_DESKTOP { get; set; }
		public string REGRA_MARGEM_PLANO { get; set; }
		public string TAXA_EMPR_PLANO { get; set; }
		public string TIPO_REFORMA { get; set; }
		public string ID_DEV_CONTR_QUITADO { get; set; }
		public string ID_DEV_PREST_NAOENVIADA { get; set; }
		public string ID_MAIOR_VALOR { get; set; }
		public string ID_DEV_PREST_RECEBIDA { get; set; }
		public string PROVISAO_SALDO_RENTAB { get; set; }
		public decimal? VL_IN20 { get; set; }
		public decimal? PRAZO_IN20 { get; set; }
		public string ID_CONTR_PAGAMENTO { get; set; }
		public string ID_CONTAB_PERFIL { get; set; }
		public string ID_NAT_PLANO { get; set; }
		public string ADITIVO { get; set; }
		public string INTEGR_COMPLIANCE { get; set; }
		public string DIRETORIO_DIGITALIZACAO { get; set; }
		public int? CARENCIA_MAXMESES { get; set; }
		public int? CARENCIA_MESESPERIODO { get; set; }
		public string OID_FUNDACAO { get; set; }
		public string ALTERA_DADOS_BANCARIOS_DEV { get; set; }
		public decimal? VL_ADITIVO_CONCESSAO { get; set; }
		public decimal? VL_ADITIVO_PRESTACAO { get; set; }
		public string TIPO_FECHAMENTO_CE { get; set; }
		public string GERAR_PR_EXP_MOV { get; set; }
		public string ATUALIZA_PLANOS_CONTRATO { get; set; }
		public decimal? CD_EMPRESA_PGA { get; set; }
		public decimal? CD_PLANO_PGA { get; set; }
		public string NAT_TAXA_PP { get; set; }
		public string NAT_TAXA_PR { get; set; }
		public decimal? NUM_PERFIL { get; set; }
		public string GERAR_PR_BOLETO { get; set; }
		public string MP_POLI_OUTROS { get; set; }
		public string TP_INTEGR_COMPLICE { get; set; }
		public string GERAR_TX_RUBRICA { get; set; }
		public string OID_FUNDACAO_TES { get; set; }
		public decimal? PRAZO_SUSP { get; set; }
		public decimal? QTD_SUSP { get; set; }
		public decimal? QTD_PAGAS { get; set; }
	}
}