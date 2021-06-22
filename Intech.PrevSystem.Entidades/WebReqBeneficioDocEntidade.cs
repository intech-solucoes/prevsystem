using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_REQ_BENEFICIO_DOC")]
	public class WebReqBeneficioDocEntidade
	{
		[Key]
		public decimal OID_REQ_BENEFICIO_DOC { get; set; }
		public decimal OID_REQ_BENEFICIO { get; set; }
		public decimal OID_DOC_EXIGIDO { get; set; }
		public string TXT_NOME_FISICO { get; set; }
	}
}
