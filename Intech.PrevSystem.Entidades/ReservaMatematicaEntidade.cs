using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CC_RESERVA_MATEMATICA")]
	public class ReservaMatematicaEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string MES_REF { get; set; }
		public string ANO_REF { get; set; }
		public decimal SEQ_CONTRIBUICAO { get; set; }
		public decimal VL_RESERVA { get; set; }
		public decimal CT_RP_RESERVA { get; set; }
		public decimal CT_FD_RESERVA { get; set; }
		public decimal? CT_RM_RESERVA { get; set; }
	}
}