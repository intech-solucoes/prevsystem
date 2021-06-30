using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_FUNCIONALIDADE")]
	public class FuncionalidadeEntidade
	{
		[Key]
		public decimal OID_FUNCIONALIDADE { get; set; }
		public decimal NUM_FUNCIONALIDADE { get; set; }
		public string DES_FUNCIONALIDADE { get; set; }
		public string IND_ATIVO { get; set; }
		public string IND_USA_PROTOCOLO { get; set; }
		[Write(false)] public string SIGLA_ENTID { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
		[Write(false)] public string NUM_MATRICULA { get; set; }
		[Write(false)] public DateTime? DTA_INICIO { get; set; }
	}
}