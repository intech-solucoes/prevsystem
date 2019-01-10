using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CC_FICHA_FECHAMENTO")]
    public class FichaFechamentoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string ANO_REF { get; set; }
		public string MES_REF { get; set; }
		public decimal VL_GRUPO1 { get; set; }
		public decimal VL_GRUPO2 { get; set; }
		public decimal VL_GRUPO3 { get; set; }
		public decimal VL_GRUPO4 { get; set; }
		public decimal VL_GRUPO5 { get; set; }
		public decimal VL_GRUPO6 { get; set; }
		public decimal VL_LIQUIDO { get; set; }
		public decimal VL_COTA { get; set; }
		public decimal QTE_COTA { get; set; }
		public decimal? QTE_COTA_ACUM { get; set; }
		public decimal? VL_ACUMULADO { get; set; }
		public DateTime? DT_FECHAMENTO { get; set; }
        
    }
}
