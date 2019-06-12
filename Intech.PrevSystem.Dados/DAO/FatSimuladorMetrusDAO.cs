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
    public abstract class FatSimuladorMetrusDAO : BaseDAO<FatSimuladorMetrusEntidade>
    {
        
		public virtual FatSimuladorMetrusEntidade BuscarPorAno(decimal ANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatSimuladorMetrusEntidade>("SELECT *  FROM GB_FAT_SIMULADOR_METRUS  WHERE ANO = @ANO", new { ANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatSimuladorMetrusEntidade>("SELECT * FROM GB_FAT_SIMULADOR_METRUS WHERE ANO=:ANO", new { ANO });
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
