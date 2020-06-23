using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_TAXA_EVOL_PERFIL")]
	public class TaxaEvolPerfilEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public decimal CD_PERFIL_INVEST { get; set; }
		public string ANO_RENTABILIDADE { get; set; }
		public decimal? RENTABILIDADE_MINIMA { get; set; }
		public decimal? RENTABILIDADE_MEDIA { get; set; }
		public decimal? RENTABILIDADE_MAXIMA { get; set; }
	}
}
