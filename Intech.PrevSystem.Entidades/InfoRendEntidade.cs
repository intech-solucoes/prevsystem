using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_INFO_REND")]
	public class InfoRendEntidade
	{
		[Key]
		public decimal OID_INFO_REND { get; set; }
		public decimal OID_HEADER_INFO_REND { get; set; }
		public string COD_LINHA { get; set; }
		public string TXT_QUADRO { get; set; }
		public decimal? VAL_LINHA { get; set; }
		public string ORIGEM { get; set; }
		[Write(false)] public string DES_INFO_REND { get; set; }
		[Write(false)] public string COD_GRUPO { get; set; }
		[Write(false)] public string DES_GRUPO { get; set; }
	}
}
