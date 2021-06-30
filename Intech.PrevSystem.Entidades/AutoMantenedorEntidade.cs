using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CS_AUTO_MANTENEDOR")]
	public class AutoMantenedorEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string NUM_INSCRICAO { get; set; }
		public string CD_PLANO { get; set; }
		public string MANUTENCAO_PARCIAL { get; set; }
		public string PID { get; set; }
		public DateTime DT_INICIO { get; set; }
		public DateTime? DT_TERMINO { get; set; }
		public string CK_IGNORA_DT_DESLIG { get; set; }
		public string OBSERVACAO { get; set; }
		public string CK_CEDIDO { get; set; }
		public string PROPRIO_BOLETO { get; set; }
	}
}