using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

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
		public string NOME { get; set; }
		public string NOM_EMPRESA { get; set; }
		public string CNPJ_EMPRESA { get; set; }
		public List<InfoRendGrupoEntidade> Grupos { get; set; }
        
    }
}
