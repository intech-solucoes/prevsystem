using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_CATEGORIA")]
    public class CategoriaEntidade
    {
		public string CD_CATEGORIA { get; set; }
		public string DS_CATEGORIA { get; set; }
		public decimal? NUM_FIADORES { get; set; }
		public string CD_TIPO_COBRANCA { get; set; }
		public string PERMITE_EMPRESTIMO { get; set; }
        
    }
}
