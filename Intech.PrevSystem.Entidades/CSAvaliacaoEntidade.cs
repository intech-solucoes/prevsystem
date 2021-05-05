using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CS_AVALIACAO")]
	public class CSAvaliacaoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public decimal? IDADE { get; set; }
		public decimal? TMP_INSS { get; set; }
		public decimal? TMP_EMPR { get; set; }
		public decimal? TMP_FUND { get; set; }
		public decimal? SAL_BASE { get; set; }
		public decimal? SRC { get; set; }
		public decimal? SRB { get; set; }
		public decimal? SALDO_PART { get; set; }
		public decimal? QTD_DEP { get; set; }
		public DateTime? DT_CONVERSAO { get; set; }
		public string AUXILIO_DOENCA { get; set; }
		public decimal? TMP_AFAST { get; set; }
		public decimal? PERC_JOIA { get; set; }
		public decimal? QTD_SRC { get; set; }
		public decimal? VLR_SALDADO_PATR { get; set; }
		public decimal? VLR_SALDADO_INSS { get; set; }
		public int? CARENCIA_APOS { get; set; }
		public decimal? VLR_CONTRIB_PART { get; set; }
		public decimal? VLR_PRINCIPAL { get; set; }
		public decimal? VLR_AMPLIACAO { get; set; }
		public decimal? VLR_4FAIXA { get; set; }
		public decimal? VLR_JOIA { get; set; }
		public string TIPO_TEMPO { get; set; }
		public decimal? SB_HIPOTETICO { get; set; }
		public decimal? VLR_PECULIO { get; set; }
		public string CPF { get; set; }
		public string SEXO { get; set; }
		public DateTime? DT_NASCIMENTO { get; set; }
		public DateTime? DT_ADMISSAO { get; set; }
		public DateTime? DT_INSCRICAO { get; set; }
		public string ESTADO_CIVIL { get; set; }
		public DateTime? DT_APOSENTADORIA { get; set; }
		public string TEMPO_ANTERIOR { get; set; }
		public string CATEGORIA { get; set; }
		public decimal? VALOR_PORTADO { get; set; }
		public int? PRAZO_JOIA { get; set; }
		public DateTime? DT_INSS { get; set; }
		public decimal? SALDO_EMP { get; set; }
		public decimal? PERC_PART { get; set; }
		public decimal? PERC_EMP { get; set; }
		public decimal? FUNDO_INDIVIDUAL { get; set; }
		public decimal? FUNDO_TRANSFERENCIA { get; set; }
		public decimal? FUNDO_PATROCINADO { get; set; }
		public decimal? FUNDO_INDIV_PORTADO { get; set; }
		public decimal? PERC_RISCO { get; set; }
		public decimal? VALOR_RISCO { get; set; }
		public decimal? VLR_CONTRIB_EMP { get; set; }
		public string TIPO_AVALIACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string TIPO_BENEFICIO { get; set; }
		[Write(false)] public string NUM_MATRICULA { get; set; }
	}
}