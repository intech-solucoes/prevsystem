using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("DR_VALORES_PERC_IDADE")]
    public class ValoresPercIdadeEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_TIPO_RESGATE { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_MANTENEDORA { get; set; }
		public decimal ANOS_IDADE { get; set; }
		public decimal ANOS_CONTRIBUICAO { get; set; }
		public decimal ANOS_PATROC { get; set; }
		public decimal QTD_CONTRIB { get; set; }
		public decimal PERCENTUAL { get; set; }
        
    }
}
