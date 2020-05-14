using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class LGPDConsentimentoDAO : BaseDAO<LGPDConsentimentoEntidade>
	{
		public virtual List<LGPDConsentimentoEntidade> BuscarPorCPF(string CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT *  FROM WEB_LGPD_CONSENTIMENTO  WHERE COD_CPF = @CPF", new { CPF }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF", new { CPF }).ToList();
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
