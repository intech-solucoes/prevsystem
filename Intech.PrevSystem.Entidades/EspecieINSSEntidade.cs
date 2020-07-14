using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("GB_ESPECIE_INSS")]
	public class EspecieINSSEntidade
	{
		public string CD_ESPECIE_INSS { get; set; }
		public string DS_ESPECIE_INSS { get; set; }
	}
}
