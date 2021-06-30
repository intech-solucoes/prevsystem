using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("GB_FATOR_PLANO_BD")]
	public class FatorPlanoBDEntidade
	{
		public DateTime DT_VALIDADE { get; set; }
		public int IDADE_ENTRADA { get; set; }
		public int IDADE_SAIDA { get; set; }
		public decimal? FATOR_MASC { get; set; }
		public decimal? FATOR_FEM { get; set; }
	}
}