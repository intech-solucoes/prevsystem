using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("VW_APP_INSTITUCIONAL_NOTICIA")]
    public class NoticiaSabesprevEntidade
    {
		[Key]
		public decimal INSTITUCIONAL_ID { get; set; }
		public string INSTITUCIONAL_NOME { get; set; }
		public string INSTITUCIONAL_TEXTO { get; set; }
		public DateTime DT_PUBLICACAO { get; set; }
		public string LINK_PORTAL { get; set; }
        
    }
}