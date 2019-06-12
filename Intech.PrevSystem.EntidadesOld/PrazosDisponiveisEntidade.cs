using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_PRAZOS_DISPONIVEIS")]
    public class PrazosDisponiveisEntidade
    {
		public decimal CD_NATUR { get; set; }
		public decimal PRAZO { get; set; }
		public string DISPONIVEL { get; set; }
		public decimal? IDADE_MAX { get; set; }
        
    }
}
