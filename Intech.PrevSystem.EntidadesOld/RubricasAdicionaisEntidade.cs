using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CE_RUBRICAS_ADCIONAIS")]
    public class RubricasAdicionaisEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public decimal CD_ORIGEM { get; set; }
		public string NUM_MATRICULA { get; set; }
		public DateTime DATA_REF { get; set; }
		public string CD_RUBRICA { get; set; }
		public decimal? VL_RUBRICA { get; set; }
		public decimal? NUM_SEQ_GR_FAMIL { get; set; }
        
    }
}
