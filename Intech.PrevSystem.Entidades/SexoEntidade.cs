using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("TB_SEXO")]
	public class SexoEntidade
	{
		public string CD_SEXO { get; set; }
		public string DS_SEXO { get; set; }
	}
}