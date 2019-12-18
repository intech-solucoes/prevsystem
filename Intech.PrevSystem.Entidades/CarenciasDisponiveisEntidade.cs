using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_CARENCIAS_DISPONIVEIS")]
    public class CarenciasDisponiveisEntidade
    {
		public decimal CD_NATUR { get; set; }
		public decimal MES { get; set; }
		public string DISPONIVEL { get; set; }
        
    }
}
