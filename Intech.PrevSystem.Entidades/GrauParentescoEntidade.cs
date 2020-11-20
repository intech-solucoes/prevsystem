using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_GRAU_PARENTESCO")]
	public class GrauParentescoEntidade
	{
		[Key]
		public string CD_GRAU_PARENTESCO { get; set; }
		public string DS_GRAU_PARENTESCO { get; set; }
		public decimal NUM_ANOS_VALIDADE { get; set; }
		public string TIPO_VALIDADE { get; set; }
		public string TIPO_CARENCIA { get; set; }
		public decimal? PRAZO_CARENCIA { get; set; }
		public string CD_CATEG_PARENTESCO { get; set; }
		public string ID_EMPRESTIMO { get; set; }
		public decimal NUM_ANOS_VALIDADE_IRRF { get; set; }
		public decimal? MAX_DEP { get; set; }
		public string TIPO_DT_FAT_BENEF { get; set; }
		public string CK_VALIDO { get; set; }
		public string CK_PADRAO_ASSISTENCIAL { get; set; }
		public string CK_PADRAO_PREVIDENCIAL { get; set; }
		[Write(false)] public string TIPO_HERDEIRO { get; set; }
	}
}
