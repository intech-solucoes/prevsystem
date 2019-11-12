using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_ADESAO_DEPENDENTE")]
    public class AdesaoDependenteEntidade
    {
		[Key]
		public decimal OID_ADESAO_DEPENDENTE { get; set; }
		public decimal OID_ADESAO { get; set; }
		public string NOM_DEPENDENTE { get; set; }
		public string COD_GRAU_PARENTESCO { get; set; }
		public string DES_GRAU_PARENTESCO { get; set; }
		public DateTime DTA_NASCIMENTO { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_CPF { get; set; }
		public decimal? COD_PERC_RATEIO { get; set; }
		public string IND_PENSAO { get; set; }
        
    }
}
