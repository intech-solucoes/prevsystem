using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("TB_HEADER_INFO_REND")]
	public class HeaderInfoRendEntidade
	{
		[Key]
		public decimal OID_HEADER_INFO_REND { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CPF { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string DESC_NATUREZA { get; set; }
		public decimal ANO_EXERCICIO { get; set; }
		public decimal ANO_CALENDARIO { get; set; }
		public DateTime DATA_GERACAO { get; set; }
		public string ORIGEM { get; set; }
		public string IND_RETENCAO { get; set; }
		[Write(false)] public string NOME { get; set; }
		[Write(false)] public string NOM_EMPRESA { get; set; }
		[Write(false)] public string CNPJ_EMPRESA { get; set; }
		[Write(false)] public List<InfoRendGrupoEntidade> Grupos { get; set; }
	}
}
