using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CE_PLANOS_CONTRATO")]
	public class PlanosContratoEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public decimal ANO_CONTRATO { get; set; }
		public int NUM_CONTRATO { get; set; }
		public string CD_PLANO { get; set; }
		public DateTime? DATA_INSCRICAO { get; set; }
	}
}
