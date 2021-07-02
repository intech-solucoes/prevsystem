using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CE_TAXAS_CONCESSAO")]
	public class TaxasConcessaoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public decimal SEQUENCIA { get; set; }
		public decimal CD_MODAL { get; set; }
		public decimal CD_NATUR { get; set; }
		public decimal? TX_JUROS { get; set; }
		public string COD_IND { get; set; }
		public string TIPO_IND { get; set; }
		public string OPERACAO { get; set; }
		public string IND_CALC_PREST_CONC { get; set; }
		public string COD_IND_2 { get; set; }
		public string IND_DEFAZAGEM { get; set; }
		public string IND_ACUMULADO { get; set; }
		public decimal? IND_MESES_DEFAZAGEM { get; set; }
		public decimal? IND_MESES_ACUMULADO { get; set; }
		public string INDICE_CONCESSAO_PRESTACOES { get; set; }
	}
}