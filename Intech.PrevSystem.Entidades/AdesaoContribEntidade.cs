using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_ADESAO_CONTRIB")]
    public class AdesaoContribEntidade
    {
		[Key]
		public decimal OID_ADESAO_CONTRIB { get; set; }
		public decimal OID_ADESAO_PLANO { get; set; }
		public string COD_CONTRIBUICAO { get; set; }
		public string DES_CONTRIBUICAO { get; set; }
		public decimal VAL_CONTRIBUICAO { get; set; }
		public string IND_VALOR_PERC { get; set; }
        
    }
}
