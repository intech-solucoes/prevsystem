using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_COMP_SRC")]
    public class ComposicaoSRCEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
        
    }
}
