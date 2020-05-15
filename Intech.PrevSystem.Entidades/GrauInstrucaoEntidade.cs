using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_GRAU_INSTRUCAO")]
	public class GrauInstrucaoEntidade
	{
		public string CD_GRAU_INSTRUCAO { get; set; }
		public string DS_GRAU_INSTRUCAO { get; set; }
		public string VINC_GRAU_INSTRUCAO { get; set; }
	}
}
