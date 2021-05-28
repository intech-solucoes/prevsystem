using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CC_PORTABILIDADE_EXT")]
	public class PortabilidadeExtEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime DT_APORTE_RECURSO { get; set; }
		public DateTime? DT_CONVERSAO { get; set; }
		public decimal? VL_BASE { get; set; }
		public DateTime? DT_BASE_ORIGEM { get; set; }
		public string IND_ORIGEM { get; set; }
		public string TIPO_IRRF { get; set; }
		public string COD_ENTID { get; set; }
		public string NOME_PLANO_ORIGEM { get; set; }
		public string REGISTRO_PLANO { get; set; }
		public string TP_ENTID { get; set; }
		public string NOME_REPRESENTANTE { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public string CD_TIPO_CONTRIBUICAOP { get; set; }
		public int NUM_PROCESSO { get; set; }
		public decimal? PERC_PMP { get; set; }
		public string TIPO_PORT { get; set; }
		public DateTime? DT_VENCIMENTO { get; set; }
		public string SITUACAO { get; set; }
		public string EMIT_PP { get; set; }
		public int? NUM_PP { get; set; }
		public decimal? ANO_PP { get; set; }
		public decimal? CD_FORMA_REC { get; set; }
	}
}