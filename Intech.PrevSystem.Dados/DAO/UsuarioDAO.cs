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
    public abstract class UsuarioDAO : BaseDAO<UsuarioEntidade>
    {
		public virtual UsuarioEntidade BuscarPorCpf(string NOM_LOGIN)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN = @NOM_LOGIN", new { NOM_LOGIN });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN", new { NOM_LOGIN });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual UsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN = @NOM_LOGIN   AND PWD_USUARIO = @PWD_USUARIO", new { NOM_LOGIN, PWD_USUARIO });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN AND PWD_USUARIO=:PWD_USUARIO", new { NOM_LOGIN, PWD_USUARIO });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
