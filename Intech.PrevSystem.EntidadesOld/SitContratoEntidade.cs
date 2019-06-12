using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_SITUACAO_CONTRATO")]
    public class SitContratoEntidade
    {
		public decimal CD_SITUACAO { get; set; }
		public string DS_SITUACAO { get; set; }
		public string STATUS { get; set; }
        
    }
}
