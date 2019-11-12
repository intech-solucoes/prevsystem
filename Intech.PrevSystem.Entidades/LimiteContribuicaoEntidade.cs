using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_LIMITE_CONTRIBUICAO")]
    public class LimiteContribuicaoEntidade
    {
		[Key]
		public decimal OID_LIMITE_CONTRIBUICAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public decimal VAL_PERC_MINIMO_PART { get; set; }
		public decimal VAL_PERC_MAXIMO_PART { get; set; }
		public decimal VAL_PERC_MINIMO_PATROC { get; set; }
		public decimal VAL_PERC_MAXIMO_PATROC { get; set; }
        
    }
}
