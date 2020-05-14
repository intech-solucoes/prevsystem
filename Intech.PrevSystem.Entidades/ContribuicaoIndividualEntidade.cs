using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_CONTRIB_INDIVIDUAIS")]
	public class ContribuicaoIndividualEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public decimal SEQ_PERC_CONTRIBUICAO { get; set; }
		public decimal? SRC { get; set; }
		public decimal? VL_PERC_EMP { get; set; }
		public decimal? VL_PERC_PAR { get; set; }
		public decimal? TOT_PARCELA { get; set; }
		public decimal? QTD_PARCELA { get; set; }
		public DateTime? DT_ATUALIZACAO { get; set; }
		public string OPCAO_PAGTO_JOIA { get; set; }
		public string CD_NIVEL_SALARIAL { get; set; }
		public decimal? VL_VALOR { get; set; }
		public DateTime? DT_INICIO { get; set; }
		public DateTime? DT_FIM { get; set; }
	}
}
