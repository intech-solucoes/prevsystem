using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TB_PARAMETRO_TAXA_ADM")]
	public class ParametroTaxaAdmEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string CD_MANTENEDORA { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public string CALC_BASE_SRC { get; set; }
		public decimal PERC_TX_ADM { get; set; }
		public string DESCONTA { get; set; }
		public string PERCENT_POR_FAIXA { get; set; }
	}
}