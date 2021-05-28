using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CC_FICHA_FINANC_ISENCAO")]
	public class FichaFinancIsencaoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public decimal SEQ_CONTRIBUICAO { get; set; }
		public string CD_OPERACAO { get; set; }
		public decimal? CONTRIB_PARTICIPANTE { get; set; }
		public decimal? CONTRIB_EMPRESA { get; set; }
		public decimal? TAXA_ADM_PARTICIPANTE { get; set; }
		public decimal? TAXA_ADM_EMPRESA { get; set; }
		public decimal? QTD_COTA_PARTICIPANTE { get; set; }
		public decimal? QTD_COTA_EMPRESA { get; set; }
		public decimal? QTD_COTA_PART_ANT { get; set; }
		public decimal? QTD_COTA_EMPR_ANT { get; set; }
		public string ANO_COMP { get; set; }
		public string MES_COMP { get; set; }
		public string CD_ORIGEM { get; set; }
		public string IND_RESERVA_IN1343 { get; set; }
		public decimal? VALOR_IND { get; set; }
		public string CD_PLANO_RESG { get; set; }
		public string CD_TIPO_FOLHA { get; set; }
	}
}