using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CS_TEMPO_SERVICO")]
	public class TempoServicoEntidade
	{
		public int COD_ENTID { get; set; }
		public int NUM_SEQ_EMP { get; set; }
		public int? CD_EMPREGADOR { get; set; }
		public string REGIME_ATIVIDADE { get; set; }
		public string TIPO_ATIVIDADE { get; set; }
		public decimal? CD_GRUPO_ATIVIDADE { get; set; }
		public DateTime? DT_INIC_ATIVIDADE { get; set; }
		public DateTime? DT_TERM_ATIVIDADE { get; set; }
		public decimal QTDE_ANOS { get; set; }
		public decimal QTDE_MESES { get; set; }
		public decimal QTDE_DIAS { get; set; }
		[Write(false)] public string DS_EMPREGADOR { get; set; }
	}
}