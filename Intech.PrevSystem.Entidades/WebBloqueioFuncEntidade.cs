using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_BLOQUEIO_FUNC")]
	public class WebBloqueioFuncEntidade
	{
		[Key]
		public decimal OID_BLOQUEIO_FUNC { get; set; }
		public decimal OID_FUNCIONALIDADE { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_PLANO { get; set; }
		public string NUM_MATRICULA { get; set; }
		public DateTime? DTA_INICIO { get; set; }
		public DateTime? DTA_FIM { get; set; }
		public DateTime DTA_CRIACAO { get; set; }
		public string TXT_MOTIVO_BLOQUEIO { get; set; }
		public string NOM_USUARIO { get; set; }
		[Write(false)] public string DES_FUNCIONALIDADE { get; set; }
		[Write(false)] public string SIGLA_ENTID { get; set; }
		[Write(false)] public string DS_PLANO { get; set; }
	}
}
