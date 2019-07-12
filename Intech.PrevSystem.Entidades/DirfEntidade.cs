using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_DIRF")]
    public class DirfEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_SISTEMA { get; set; }
		public string CPF_RESPONSAVEL { get; set; }
		public string NATUREZA_DECLARANTE { get; set; }
		public string NOME_RESPONSAVEL { get; set; }
		public string DDD_RESPONSAVEL { get; set; }
		public string FONE_RESPONSAVEL { get; set; }
		public string RAMAL_RESPONSAVEL { get; set; }
		public string FAX_RESPONSAVEL { get; set; }
		public string EMAIL_RESPONSAVEL { get; set; }
		public string CGC_ENTREGADOR { get; set; }
		public string CRC { get; set; }
		public string UF_RESPONSAVEL { get; set; }
		public string DIRF_DPREV { get; set; }
		public string PRESIDENTE { get; set; }
		public string SOC_OSTENS { get; set; }
		public string DECL_DEP_JUD { get; set; }
		public string IND_ADM { get; set; }
		public string PAG_RESID_EXT { get; set; }
		public string PL_SAUDE_COLET { get; set; }
		public string DECL_SIT_ESP { get; set; }
		public DateTime? DT_EVENTO { get; set; }
        
    }
}
