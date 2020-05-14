using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_GRUPO_USUARIO")]
	public class GrupoUsuarioEntidade
	{
		[Key]
		public decimal OID_GRUPO_USUARIO { get; set; }
		public string NOM_GRUPO_USUARIO { get; set; }
		public string IND_ADMINISTRADOR { get; set; }
		public string IND_ATIVO { get; set; }
	}
}
