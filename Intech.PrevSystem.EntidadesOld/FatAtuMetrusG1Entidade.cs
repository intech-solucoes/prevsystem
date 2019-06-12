using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_FAT_ATU_METRUS_G1")]
    public class FatAtuMetrusG1Entidade
    {
		public string TIPO { get; set; }
		public decimal IDADE { get; set; }
		public decimal? FATOR { get; set; }
        
    }
}
