using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RECAD_CAMPANHA")]
	public class WebRecadCampanhaEntidade
	{
		[Key]
		public decimal OID_RECAD_CAMPANHA { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string NOM_CAMPANHA { get; set; }
		public DateTime DTA_INICIO { get; set; }
		public DateTime DTA_TERMINO { get; set; }
		public string IND_ATIVO { get; set; }
	}
}
