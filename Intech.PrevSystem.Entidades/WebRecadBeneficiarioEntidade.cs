using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RECAD_BENEFICIARIO")]
	public class WebRecadBeneficiarioEntidade
	{
		[Key]
		public decimal OID_RECAD_BENEFICIARIO { get; set; }
		public decimal OID_RECAD_DADOS { get; set; }
		public string COD_PLANO { get; set; }
		public decimal NUM_SEQ_DEP { get; set; }
		public string NOM_DEPENDENTE { get; set; }
		public string COD_GRAU_PARENTESCO { get; set; }
		public string DES_GRAU_PARENTESCO { get; set; }
		public DateTime? DTA_NASCIMENTO { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_CPF { get; set; }
		public decimal? COD_PERC_RATEIO { get; set; }
		public string IND_OPERACAO { get; set; }
		public string IND_VALIDO { get; set; }
		[Write(false)] public string IND_HERDEIRO { get; set; }
	}
}
