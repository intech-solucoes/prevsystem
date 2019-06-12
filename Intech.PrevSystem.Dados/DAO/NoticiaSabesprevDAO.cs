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
    public abstract class NoticiaSabesprevDAO : BaseDAO<NoticiaSabesprevEntidade>
    {
        
		public virtual NoticiaSabesprevEntidade BuscarPorId(decimal ID)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<NoticiaSabesprevEntidade>("SELECT *  FROM VW_APP_INSTITUCIONAL_NOTICIA  WHERE ID = @ID", new { ID });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<NoticiaSabesprevEntidade>("SELECT * FROM VW_APP_INSTITUCIONAL_NOTICIA WHERE ID=:ID", new { ID });
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
