using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_PERC_CONTRIBUICAO")]
    public class PercContribuicaoEntidade
    {
		[Key]
		public decimal OID_PERC_CONTRIBUICAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public decimal VAL_PERC_CONTRIBUICAO { get; set; }
        
    }
}
