using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_ADESAO_EMPRESA_PLANO")]
	public class AdesaoEmpresaPlanoEntidade
	{
		[Key]
		public decimal OID_ADESAO_EMPRESA_PLANO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
	}
}
