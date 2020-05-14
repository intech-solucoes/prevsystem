using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_BLOQUEIO")]
	public class BloqueioEntidade
	{
		public int COD_ENTID { get; set; }
		public string CD_TIPO_BLOQUEIO { get; set; }
		public DateTime DT_BLOQUEIO { get; set; }
		public string MOTIVO_BLOQUEIO { get; set; }
		public DateTime? DT_LIBERACAO { get; set; }
		public string RESP_LIBERACAO { get; set; }
	}
}
