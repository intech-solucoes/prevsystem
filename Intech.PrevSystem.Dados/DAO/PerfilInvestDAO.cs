using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PerfilInvestDAO : BaseDAO<PerfilInvestEntidade>
	{
		public virtual PerfilInvestEntidade BuscarPorCodigo(string CD_PERFIL_INVEST)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PerfilInvestEntidade>("SELECT *  FROM TB_PERFIL_INVEST  WHERE CD_PERFIL_INVEST = @CD_PERFIL_INVEST", new { CD_PERFIL_INVEST });
				else if (AppSettings.IS_ORACLE_PROVIDER)
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
