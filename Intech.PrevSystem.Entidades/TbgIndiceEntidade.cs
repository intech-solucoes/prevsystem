using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TBG_INDICE")]
    public class TbgIndiceEntidade
    {
		[Key]
		public decimal OID_INDICE { get; set; }
		public string COD_INDICE { get; set; }
		public string DES_INDICE { get; set; }
		public string IND_PERIODICIDADE { get; set; }
		public decimal NUM_DIA_ANIV { get; set; }
		public string OBS_INDICE { get; set; }
		public string NOM_USUARIO_CRIACAO { get; set; }
		public DateTime? DTA_CRIACAO { get; set; }
		public string NOM_USUARIO_ATUALIZACAO { get; set; }
		public DateTime? DTA_ATUALIZACAO { get; set; }
		public decimal NUM_RAIZ { get; set; }
		[Write(false)] public List<TbgIndiceValEntidade> Valores { get; set; }
        
    }
}
