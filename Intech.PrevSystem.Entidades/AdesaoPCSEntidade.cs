using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CS_ADESAO_PCS")]
	public class AdesaoPCSEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public decimal? SEQ_ADESAO_PCS { get; set; }
		public DateTime DT_INICIO { get; set; }
		public string ADESAO_PCS { get; set; }
		public DateTime? DT_INCLUSAO { get; set; }
	}
}