using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_INDICE")]
    public class IndiceEntidade
    {
		public string COD_IND { get; set; }
		public string DESC_IND { get; set; }
		public string PERIODIC { get; set; }
		public decimal? DEC_PRORATA { get; set; }
		public string PRORATA_DU { get; set; }
		public string ATRASADO { get; set; }
		public string CDI { get; set; }
		public string ANBID { get; set; }
		public decimal? DIA_ANIV { get; set; }
		public string COD_CETIP { get; set; }
		public string COD_CUSTOD { get; set; }
		public string COD_SPC { get; set; }
		public List<IndiceValoresEntidade> VALORES { get; set; }
        
    }
}
