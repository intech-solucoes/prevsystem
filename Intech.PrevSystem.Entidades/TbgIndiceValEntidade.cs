using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TBG_INDICE_VAL")]
	public class TbgIndiceValEntidade
	{
		[Key]
		public decimal OID_INDICE_VAL { get; set; }
		public decimal OID_INDICE { get; set; }
		public DateTime DTA_INDICE { get; set; }
		public decimal VLR_INDICE { get; set; }
		public decimal VLR_VARIACAO { get; set; }
		public string NOM_USUARIO_CRIACAO { get; set; }
		public DateTime? DTA_CRIACAO { get; set; }
		public string NOM_USUARIO_ATUALIZACAO { get; set; }
		public DateTime? DTA_ATUALIZACAO { get; set; }
		public decimal VLR_VAR_MES { get; set; }
		public decimal VLR_VAR_ANO { get; set; }
		public decimal VLR_VAR_TRIMESTRE { get; set; }
		public decimal VLR_VAR_12MESES { get; set; }
		public decimal VLR_VAR_36MESES { get; set; }
	}
}
