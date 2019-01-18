using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_RUBRICA")]
    public class RubricaEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string CD_RUBRICA { get; set; }
		public string DS_RUBRICA { get; set; }
		public string SRC { get; set; }
		public string DEBITO_CREDITO { get; set; }
		public string MARGEM_CONSIG { get; set; }
		public string SRC_EMP { get; set; }
		public string SRC_PREV { get; set; }
		public DateTime DT_INIC_VIGENCIA { get; set; }
		public string SRC_ATUARIAL { get; set; }
		public string CONCESSAO_BENEF { get; set; }
		public string CD_CATEG_RUBRICA { get; set; }
		public string INCIDE_REAJUSTE { get; set; }
		public string RUB_CEDIDO { get; set; }
		public string INCIDE_13 { get; set; }
		public string COD_IND_CONCESSAO { get; set; }
		public string SAL_LIQ_EMPRESTIMO { get; set; }
		public string RUB_FERIAS { get; set; }
		public string CD_PLANO { get; set; }
		public string CK_MEDIA_SAL_EMPRESTIMO { get; set; }
		public string RUB_COBR_SIAPE { get; set; }
        
    }
}
