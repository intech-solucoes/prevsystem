using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CE_CONTRATOS")]
	public class ContratoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public decimal ANO_CONTRATO { get; set; }
		public int NUM_CONTRATO { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal CD_NATUR { get; set; }
		public decimal CD_SITUACAO { get; set; }
		public decimal? CD_MOTIVO_QUIT { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal? NUM_SEQ_GR_FAMIL { get; set; }
		public decimal SEQ_RUBRICA { get; set; }
		public decimal PRAZO { get; set; }
		public DateTime DT_SOLICITACAO { get; set; }
		public DateTime DT_CREDITO { get; set; }
		public DateTime DT_CREDITO_AUX { get; set; }
		public DateTime? DT_QUITACAO { get; set; }
		public DateTime? DT_REF_QUITACAO { get; set; }
		public decimal? VL_SOLICITADO { get; set; }
		public decimal? VL_LIQUIDO { get; set; }
		public decimal? VL_TX_ADM { get; set; }
		public decimal? VL_TX_SEGURO { get; set; }
		public decimal? VL_TX_INAD { get; set; }
		public decimal? VL_TX_RENOVACAO { get; set; }
		public decimal? VL_IOF { get; set; }
		public decimal? VL_CORRIGIDO { get; set; }
		public decimal? VL_ANTECIPADO { get; set; }
		public decimal? VL_PRESTACAO { get; set; }
		public decimal? VL_LIMITE { get; set; }
		public decimal? VL_BASE_CALC { get; set; }
		public decimal? VL_PERC_CALC { get; set; }
		public decimal? VL_MARGEM_CONSIG { get; set; }
		public decimal? VL_REMUNERACAO { get; set; }
		public decimal? VL_DESCONTO_AUT { get; set; }
		public decimal? VL_PRINC_QUITACAO { get; set; }
		public decimal? VL_JUROS_QUITACAO { get; set; }
		public decimal? VL_PREST_ATRASO { get; set; }
		public decimal? VL_JUROS_PREST_ATRASO { get; set; }
		public decimal? VL_JUROS_MORA_PREST { get; set; }
		public decimal? VL_MULTA_PREST { get; set; }
		public decimal? TX_JUROS { get; set; }
		public decimal? TX_APLICADA { get; set; }
		public decimal? CD_REPRESENTANTE { get; set; }
		public string GEROU_CREDITO { get; set; }
		public decimal? VL_REFORMADO { get; set; }
		public decimal? VL_JUROS_PREST_MES { get; set; }
		public decimal? VL_DESCONTO_QUITACAO { get; set; }
		public decimal? VL_DEBITOS { get; set; }
		public decimal? VL_PREST_ATRASO_CONCESSAO { get; set; }
		public decimal? VL_PREST_MES_CONCESSAO { get; set; }
		public decimal? VL_PRINC_PREST_ATRASO { get; set; }
		public decimal? VL_CORR_PREST_ATRASO { get; set; }
		public string OBSERVACAO { get; set; }
		public decimal? VL_RESIDUO_AMORTIZACAO { get; set; }
		public string CD_SIT_FUNDACAO { get; set; }
		public decimal? VL_TX_INVALIDEZ { get; set; }
		public int? COD_CONVENIO { get; set; }
		public string CD_FORMA_PAGTO { get; set; }
		public decimal? VL_RESERVA_POUPANCA { get; set; }
		public DateTime? DT_PREST_ATUALIZADA { get; set; }
		public decimal? VL_CORRECAO_SALDO_QUITACAO { get; set; }
		public decimal? VL_ACRESCIMO_QUITACAO { get; set; }
		public decimal? TP_COBRANCA_PREST { get; set; }
		public decimal? VL_TX_SEGURO_ESPECIAL { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public decimal? VL_DESC_SEGURO_QUITACAO { get; set; }
		public decimal? VL_DESC_SEGURO_QUIT { get; set; }
		public decimal? VL_DESC_SEGURO_ESPECIAL_QUIT { get; set; }
		public decimal? VL_TX_INAD_QUITACAO { get; set; }
		public decimal? VL_TX_ADM_QUITACAO { get; set; }
		public decimal? VL_TX_SEGURO_QUITACAO { get; set; }
		public DateTime? DT_CANCELAMENTO { get; set; }
		public string MOTIVO_CANCELAMENTO { get; set; }
		public decimal? TX_FATOR_ANTECIPACAO { get; set; }
		public decimal? TX_FATOR_ATUALIZACAO { get; set; }
		public string CD_TIPO_COBRANCA { get; set; }
		public decimal? VL_PRINC_PREST_MES { get; set; }
		public decimal? VL_SEGURO_QUIT { get; set; }
		public decimal? PERC_PRESTACAO { get; set; }
		public decimal? VL_CORRIGIDO_JUROS { get; set; }
		public decimal? VL_CORRIGIDO_SEGURO { get; set; }
		public decimal? VL_SEGURO_PRORATA { get; set; }
		public string CD_PLANO { get; set; }
		public decimal? VL_CORR_PRINC_PREST_MES { get; set; }
		public decimal? VL_CORR_JUROS_PREST_MES { get; set; }
		public string NUM_INSCRICAO_FIADOR1 { get; set; }
		public string NUM_INSCRICAO_FIADOR2 { get; set; }
		public string ID_AUTORIZACAO { get; set; }
		public string ID_AUTORIZADO { get; set; }
		public decimal? VL_TX_ADM_MES_QUIT { get; set; }
		public decimal? CARENCIA { get; set; }
		public decimal? VL_INSS { get; set; }
		public decimal? VL_NOVOS_REC { get; set; }
		public decimal? VL_IOF_NOVOS_REC { get; set; }
		public decimal? VL_SALDO_DEV_NOV { get; set; }
		public decimal? VL_IOF_COMPLEMENTAR { get; set; }
		public decimal? VL_IOF_COMPL_QUIT { get; set; }
		public decimal? VL_ADM_PRORATA { get; set; }
		public DateTime? DT_ADITIVO { get; set; }
		public decimal? PRAZO_ADITIVO { get; set; }
		public decimal? TARIFA_BANCARIA { get; set; }
		public decimal? VL_ADITIVO_CONCESSAO { get; set; }
		public decimal? VL_ADITIVO_PRESTACAO { get; set; }
		public string BLOQUEIO_COBRANCA { get; set; }
		public decimal? PERCENTUAL_DESCONTO { get; set; }
		public decimal? TX_QQM_BRUTO { get; set; }
		public decimal? TX_QQM_LIQUIDO { get; set; }
		public string DS_TIPO_CONTA { get; set; }
		public string CD_TIPO_CONTA { get; set; }
		public decimal? VL_TX_INAD_MES_QUIT { get; set; }
		public string ID_CF { get; set; }
		public string STATUS_CF { get; set; }
		public string OBSERVACAO2 { get; set; }
		public string ID_IOF_CF { get; set; }
		public string STATUS_IOF_CF { get; set; }
		public string PERMITE_SUSPENSAO { get; set; }
		public DateTime? DT_SUSPENSAO { get; set; }
		public string USUARIO_SUSP { get; set; }
		[Write(false)] public string DES_NUM_CONTRATO { get; set; }
		[Write(false)] public string DES_PARCELAS { get; set; }
		[Write(false)] public decimal? NUM_SALDO_DEVEDOR { get; set; }
		[Write(false)] public List<PrestacaoEntidade> Prestacoes { get; set; }
		[Write(false)] public ModalidadeEntidade Modalidade { get; set; }
		[Write(false)] public SaldoDevedorEntidade SaldoDevedor { get; set; }
		[Write(false)] public string DS_SITUACAO { get; set; }
		[Write(false)] public string NOME_PARTICIPANTE { get; set; }
		[Write(false)] public string CPF_PARTICIPANTE { get; set; }
		[Write(false)] public string NOME_PENSIONISTA { get; set; }
		[Write(false)] public string CPF_PENSIONISTA { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
		[Write(false)] public string DS_NATUR { get; set; }
		[Write(false)] public string DS_MODAL { get; set; }
		[Write(false)] public string SITUACAO_PGTO { get; set; }
		[Write(false)] public List<SaldoDevedorEntidade> ListaSaldosDevedores { get; set; }
		[Write(false)] public NaturezaEntidade Natureza { get; set; }
		[Write(false)] public string NUM_MATRICULA { get; set; }
	}
}