using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_FAIXA_VALOR_CONTRIB")]
    public class FaixaValorContribEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string CD_MANTENEDORA { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public decimal SEQ_FAIXA { get; set; }
		public decimal PERC_FAIXA { get; set; }
		public decimal LIMITE_INF_FAIXA { get; set; }
		public decimal LIMITE_SUP_FAIXA { get; set; }
		public decimal DEDUCAO_FAIXA { get; set; }
		public string PERC_FUNDADOR { get; set; }
		public decimal? VL_PERC_MIN { get; set; }
		public decimal? VL_PERC_MAX { get; set; }
        
    }
}
