#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class LGPDConsentimentoDAO : BaseDAO<LGPDConsentimentoEntidade>
    {
        
		public virtual LGPDConsentimentoEntidade BuscarPorCPF(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<LGPDConsentimentoEntidade>("SELECT *  FROM WEB_LGPD_CONSENTIMENTO  WHERE COD_CPF = @CPF", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

    }
}
