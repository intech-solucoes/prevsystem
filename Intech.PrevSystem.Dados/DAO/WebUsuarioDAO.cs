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
    public abstract class WebUsuarioDAO : BaseDAO<WebUsuarioEntidade>
    {
        
		public virtual WebUsuarioEntidade AtualizarPrimeiroAcesso(string NOM_LOGIN)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebUsuarioEntidade>("UPDATE WEB_USUARIO SET IND_PRIMEIRO_ACESSO = 'N' WHERE NOM_LOGIN = @NOM_LOGIN", new { NOM_LOGIN });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebUsuarioEntidade>("UPDATE WEB_USUARIO SET IND_PRIMEIRO_ACESSO='N' WHERE NOM_LOGIN=:NOM_LOGIN", new { NOM_LOGIN });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual WebUsuarioEntidade BuscarPrimeiroAcesso(string NOM_LOGIN)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebUsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN = @NOM_LOGIN", new { NOM_LOGIN });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebUsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN", new { NOM_LOGIN });
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
