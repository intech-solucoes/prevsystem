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
    public abstract class EmpregadorDAO : BaseDAO<EmpregadorEntidade>
    {
        
		public virtual EmpregadorEntidade BuscarPorCdEmpregador(int CD_EMPREGADOR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<EmpregadorEntidade>("SELECT *  FROM CS_EMPREGADOR WHERE CD_EMPREGADOR = @CD_EMPREGADOR", new { CD_EMPREGADOR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<EmpregadorEntidade>("SELECT * FROM CS_EMPREGADOR WHERE CD_EMPREGADOR=:CD_EMPREGADOR", new { CD_EMPREGADOR });
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
