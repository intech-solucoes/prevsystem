using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CE_MARGENS_CALCULADAS")]
	public class MargensCalculadasEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public int? CD_ORIGEM { get; set; }
		public string NUM_MATRICULA { get; set; }
		public DateTime? DATA_REF { get; set; }
		public decimal? VL_MARGEM { get; set; }
		public int? NUM_SEQ_GR_FAMIL { get; set; }
		public string CD_PLANO { get; set; }
	}
}