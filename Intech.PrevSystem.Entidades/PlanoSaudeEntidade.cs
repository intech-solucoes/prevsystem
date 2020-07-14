using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_DIRF_PSAUDE")]
	public class PlanoSaudeEntidade
	{
		public string NUM_MATRICULA { get; set; }
		public string NUM_IDENT { get; set; }
		public string ID_REGISTRO { get; set; }
		public string CPF { get; set; }
		public string DT_NASCIMENTO { get; set; }
		public string NOME { get; set; }
		public string GRAU_PARENT { get; set; }
		public decimal? VALOR { get; set; }
		public decimal ANO_CALENDARIO { get; set; }
	}
}
