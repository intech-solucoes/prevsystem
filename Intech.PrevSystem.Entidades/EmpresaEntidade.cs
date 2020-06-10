using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_EMPRESA")]
	public class EmpresaEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public int COD_ENTID { get; set; }
		public string IND_RESERVA_POUP { get; set; }
		public string IND_FUNDO { get; set; }
		public string CALCULA_SRC { get; set; }
		public decimal? PERCENT_DIF_CONTRIB { get; set; }
		public decimal? QTDE_MESES_INF { get; set; }
		public string INDICE_PLANO { get; set; }
		public decimal? TP_RATEIO { get; set; }
		public string IND_PASSIVO { get; set; }
		public decimal? CD_EMPRESA_CT { get; set; }
		public decimal? EXC_PRESTADORA { get; set; }
		public decimal? NUM_CD_CC { get; set; }
		public decimal? NUM_CD_DR { get; set; }
		public decimal? NUM_CD_AM { get; set; }
		public string COD_MCI { get; set; }
		public int? SIAPE { get; set; }
		public string IND_RES_MATEM { get; set; }
		public decimal? NUM_CD_PT { get; set; }
		public int? NUM_SEQUENCIAL_COBRANCA { get; set; }
		public string IND_CALC_PROJETADO { get; set; }
		public string IND_MATRIC_IGUAL_INSC { get; set; }
		public string IND_INSC_IGUAL_MATRIC { get; set; }
		public string CK_SEQ_MATRICULA { get; set; }
		[Write(false)] public string NOME_ENTID { get; set; }
		[Write(false)] public string CPF_CGC { get; set; }
		[Write(false)] public List<PlanoEntidade> Planos { get; set; }
		[Write(false)] public string SIGLA_ENTID { get; set; }
	}
}
