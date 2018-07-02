using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CS_ESTADO_CIVIL")]
    public class EstadoCivilEntidade
    {
		public string CD_ESTADO_CIVIL { get; set; }
		public string DS_ESTADO_CIVIL { get; set; }
        
    }
}
