using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_CONTRIBUICAO")]
	public class WebContribuicaoEntidade
	{
		[Key]
		public decimal OID_CONTRIBUICAO { get; set; }
		public string CD_FUNDACAO { get; set; }
		public string CD_PLANO { get; set; }
		public string CD_TIPO_CONTRIBUICAO { get; set; }
		public string COD_GRUPO_CONTRIBUICAO { get; set; }
	}
}