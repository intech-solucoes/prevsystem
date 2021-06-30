using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Intech.PrevSystem.Entidades.Outros;
namespace Intech.PrevSystem.Entidades
{
	[Table("CS_EMPREGADOR")]
	public class EmpregadorEntidade
	{
		public int CD_EMPREGADOR { get; set; }
		public string CPF_CGC { get; set; }
		public string ENDERECO { get; set; }
		public string BAIRRO { get; set; }
		public string CIDADE { get; set; }
		public string UF { get; set; }
		public string CEP { get; set; }
		public string DS_EMPREGADOR { get; set; }
	}
}