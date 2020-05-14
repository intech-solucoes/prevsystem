using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class NoticiaSabesprevDAO : BaseDAO<NoticiaSabesprevEntidade>
	{
		public virtual NoticiaSabesprevEntidade BuscarPorId(decimal ID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<NoticiaSabesprevEntidade>("SELECT *  FROM VW_APP_INSTITUCIONAL_NOTICIA  WHERE INSTITUCIONAL_ID = @ID", new { ID });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<NoticiaSabesprevEntidade>("SELECT * FROM VW_APP_INSTITUCIONAL_NOTICIA WHERE INSTITUCIONAL_ID=:ID", new { ID });
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
