using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_FATOR_ATUARIAL")]
	public class WebFatorAtuarialEntidade
	{
		[Key]
		public decimal OID_FATOR_ATUARIAL { get; set; }
		public string COD_TABELA { get; set; }
		public DateTime DTA_INICIO_VALIDADE { get; set; }
		public string IND_SEXO { get; set; }
		public decimal NUM_IDADE_ANOS { get; set; }
		public decimal VAL_FATOR { get; set; }
	}
}
