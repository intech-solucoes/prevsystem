using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("GB_FAT_SIMULADOR_METRUS")]
    public class FatSimuladorMetrusEntidade
    {
		public decimal ANO { get; set; }
		public decimal FAT_MASC { get; set; }
		public decimal FAT_FEM { get; set; }
        
    }
}
