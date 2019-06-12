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
    public abstract class PerfilInvestDAO : BaseDAO<PerfilInvestEntidade>
    {
        
		public virtual PerfilInvestEntidade BuscarPorCodigo(string CD_PERFIL_INVEST)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PerfilInvestEntidade>("SELECT *  FROM TB_PERFIL_INVEST  WHERE CD_PERFIL_INVEST = @CD_PERFIL_INVEST", new { CD_PERFIL_INVEST });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PerfilInvestEntidade>("SELECT * FROM TB_PERFIL_INVEST WHERE CD_PERFIL_INVEST=:CD_PERFIL_INVEST", new { CD_PERFIL_INVEST });
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
