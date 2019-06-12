using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_PRESTACOES")]
    public class PrestacaoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public decimal ANO_CONTRATO { get; set; }
		public int NUM_CONTRATO { get; set; }
		public decimal SEQ_PREST { get; set; }
		public string TIPO { get; set; }
		public decimal? PARCELA { get; set; }
		public DateTime? DT_VENC { get; set; }
		public DateTime? DT_PAGTO { get; set; }
		public decimal? CD_ORIGEM_REC { get; set; }
		public decimal? VL_PRINCIPAL { get; set; }
		public decimal? VL_JUROS { get; set; }
		public decimal? VL_PRESTACAO { get; set; }
		public decimal? VL_MULTA { get; set; }
		public decimal? VL_MORA { get; set; }
		public decimal? VL_MULTA_SALDO { get; set; }
		public decimal? VL_MORA_SALDO { get; set; }
		public decimal? VL_DESCONTO { get; set; }
		public decimal? VL_RECEBIDO { get; set; }
		public decimal? VL_SALDO_ANT { get; set; }
		public decimal? VL_SALDO_ATUAL { get; set; }
		public decimal? VL_TX_ADM { get; set; }
		public decimal? VL_TX_SEGURO { get; set; }
		public decimal? VL_TX_INAD { get; set; }
		public decimal? VL_IOF { get; set; }
		public decimal? VL_CORR_SALDO { get; set; }
		public decimal? VL_CORR_PRINC { get; set; }
		public decimal? VL_CORR_JUROS { get; set; }
		public decimal? VL_INDICE { get; set; }
		public decimal? VL_INDICE_ACUM { get; set; }
		public decimal? VL_CORR_PREST_ATRASO { get; set; }
		public decimal? VL_ACRESCIMO { get; set; }
		public decimal? ENVIO_COBRANCA { get; set; }
		public DateTime? DT_ENVIO_COBRANCA { get; set; }
		public string ORIGEM_LANC { get; set; }
		public decimal? VL_CORR_PREST { get; set; }
		public decimal? VL_CORR_PREST_ACUM { get; set; }
		public decimal? VL_MORA_ACUM { get; set; }
		public decimal? VL_TX_INVALIDEZ { get; set; }
		public decimal? TX_JUROS_ACUM { get; set; }
		public decimal? NOVO_PRAZO { get; set; }
		public decimal? VL_DESC_SEGURO { get; set; }
		public decimal? VL_DESC_SEGURO_ESPECIAL { get; set; }
		public decimal? VL_JUROS_CONTRATO { get; set; }
		public decimal? VL_PAGTO_PARCIAL { get; set; }
		public string ID_MORATORIA { get; set; }
		public decimal? VL_IOF_COMPLEMENTAR { get; set; }
		public decimal? TX_NOVO_JUROS { get; set; }
		public string BLOQUEIO_COBRANCA { get; set; }
		public decimal? VL_SALDO_MEDIO { get; set; }
		public DateTime? DT_ENVIO_NOT_COBRANCA { get; set; }
		public int? NUM_NOT_COBRANCA_ENVIADA { get; set; }
		[Write(false)] public string DES_VL_RECEBIDO { get; set; }
        
    }
}
