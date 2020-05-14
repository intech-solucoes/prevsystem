using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class SegUsuarioDAO : BaseDAO<SegUsuarioEntidade>
	{
		public virtual SegUsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SegUsuarioEntidade>("SELECT *  FROM SEG_USUARIO  WHERE NOM_LOGIN = @NOM_LOGIN    AND PWD_USUARIO = @PWD_USUARIO", new { NOM_LOGIN, PWD_USUARIO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SegUsuarioEntidade>("SELECT * FROM SEG_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN AND PWD_USUARIO=:PWD_USUARIO", new { NOM_LOGIN, PWD_USUARIO });
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
