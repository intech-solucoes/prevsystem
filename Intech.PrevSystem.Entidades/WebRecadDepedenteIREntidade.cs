using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RECAD_DEPENDENTE_IR")]
	public class WebRecadDepedenteIREntidade
	{
		[Key]
		public decimal OID_RECAD_DEPENDENTE_IR { get; set; }
		public decimal OID_RECAD_DADOS { get; set; }
		public decimal NUM_SEQ_DEP { get; set; }
		public string NOM_DEPENDENTE { get; set; }
		public string COD_GRAU_PARENTESCO { get; set; }
		public string DES_GRAU_PARENTESCO { get; set; }
		public DateTime? DTA_NASCIMENTO { get; set; }
		public DateTime? DTA_INICIO_IRRF { get; set; }
		public DateTime? DTA_TERMINO_IRRF { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_CPF { get; set; }
		public string IND_OPERACAO { get; set; }
		public string IND_VALIDO { get; set; }
	}
}
