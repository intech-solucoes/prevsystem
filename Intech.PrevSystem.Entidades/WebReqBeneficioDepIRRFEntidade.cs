using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_REQ_BENEFICIO_DEP_IRRF")]
	public class WebReqBeneficioDepIRRFEntidade
	{
		[Key]
		public decimal OID_REQ_BENEFICIO_DEP_IRRF { get; set; }
		public decimal OID_REQ_BENEFICIO { get; set; }
		public decimal NUM_SEQ_DEP { get; set; }
		public string NOM_DEPENDENTE { get; set; }
		public string COD_GRAU_PARENTESCO { get; set; }
		public string DES_GRAU_PARENTESCO { get; set; }
		public DateTime DTA_NASCIMENTO { get; set; }
		public DateTime DTA_INICIO_IRRF { get; set; }
		public DateTime DTA_TERMINO_IRRF { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_CPF { get; set; }
		public string IND_OPERACAO { get; set; }
	}
}
