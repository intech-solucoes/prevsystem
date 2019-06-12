using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("TB_PERFIL_SIT_PLANO")]
    public class PerfilSitPlanoEntidade
    {
		public string CD_FUNDACAO { get; set; }
		public decimal CD_PERFIL_INVEST { get; set; }
		public string CD_SIT_PLANO { get; set; }
        
    }
}
