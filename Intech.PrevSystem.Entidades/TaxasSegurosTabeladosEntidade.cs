using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CE_TAXAS_SEGUROS_TABELADOS")]
	public class TaxasSegurosTabeladosEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public decimal IDADE { get; set; }
		public decimal PRAZO { get; set; }
		public decimal? TX_QQI_ATIVO { get; set; }
		public decimal? TX_QQM_ATIVO { get; set; }
		public decimal? TX_QQM_ASSISTIDO { get; set; }
		public DateTime DT_VIGENCIA { get; set; }
		public decimal? TX_QQM_ATIVO_BRUTO { get; set; }
		public decimal? TX_QQM_ATIVO_LIQUIDO { get; set; }
		public decimal? TX_QQM_ASSISTIDO_BRUTO { get; set; }
		public decimal? TX_QQM_ASSISTIDO_LIQUIDO { get; set; }
	}
}