using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_REQ_BENEFICIO")]
	public class WebReqBeneficioEntidade
	{
		[Key]
		public decimal OID_REQ_BENEFICIO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_ESPECIE { get; set; }
		public DateTime DTA_SOLICITACAO { get; set; }
		public string DES_ORIGEM { get; set; }
		public string IND_SITUACAO { get; set; }
		public string COD_VALIDACAO { get; set; }
		public string COD_PROTOCOLO { get; set; }
		public DateTime? DTA_EFETIVACAO { get; set; }
		public DateTime? DTA_RECUSA { get; set; }
		public string TXT_MOTIVO_RECUSA { get; set; }
		public decimal? NUM_IDADE { get; set; }
		public decimal? NUM_TEMPO_PATROC { get; set; }
		public decimal? NUM_TEMPO_PLANO { get; set; }
		public decimal? NUM_TEMPO_INSS { get; set; }
		public DateTime? DTA_ULTIMO_RECAD { get; set; }
		public DateTime? DTA_DEMISSAO { get; set; }
		public string COD_BANCO { get; set; }
		public string COD_AGENCIA { get; set; }
		public string COD_CONTA { get; set; }
		public string COD_DV_CONTA { get; set; }
		[Write(false)] public string TEXTO_REQ_BENEFICIO { get; set; }
	}
}
