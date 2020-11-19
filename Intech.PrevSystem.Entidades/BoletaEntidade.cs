using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("AM_BOLETA")]
	public class BoletaEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public DateTime DT_INICIO { get; set; }
		public DateTime DT_REFERENCIA { get; set; }
		public string CD_TIPO_COBRANCA { get; set; }
		public string CD_ORIGEM_PAGTO { get; set; }
		public DateTime DT_VENCTO { get; set; }
		public DateTime? DT_PAGTO { get; set; }
		public string SITUACAO { get; set; }
		public string NOSSO_NUMERO { get; set; }
		public decimal SALARIOB_BASE { get; set; }
		public decimal? VL_BOLETA { get; set; }
		public decimal? VL_MULTA { get; set; }
		public decimal? VL_JUROS_MORA { get; set; }
		public decimal? VL_CORRECAO { get; set; }
		public decimal? VL_DESCONTO { get; set; }
		public decimal? VL_COBRADO { get; set; }
		public decimal? VL_TARIFA_BANCARIA { get; set; }
		public string EMIT_PP { get; set; }
		public decimal? ANO_PP { get; set; }
		public int? NUM_PP { get; set; }
		public string OBSERVACAO { get; set; }
		public decimal? VL_EXCEDENTE { get; set; }
		public string NUM_DOC { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
	}
}
