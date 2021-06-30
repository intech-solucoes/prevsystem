using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("GB_RUBRICA_CONCESSAO")]
	public class RubricaConcessaoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_RUBRICA { get; set; }
		public DateTime DT_VIGENCIA { get; set; }
		public string COD_IND_CONC { get; set; }
		public string ADESAO_PCS { get; set; }
		public decimal? CD_CALCULO { get; set; }
		public string COD_IND_LIMIT { get; set; }
	}
}