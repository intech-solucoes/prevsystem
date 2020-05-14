using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class CategoriaDAO : BaseDAO<CategoriaEntidade>
	{
		public virtual CategoriaEntidade BuscarPorCdCategoria(string CD_CATEGORIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<CategoriaEntidade>("SELECT *  FROM TB_CATEGORIA  WHERE CD_CATEGORIA = @CD_CATEGORIA", new { CD_CATEGORIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<CategoriaEntidade>("SELECT * FROM TB_CATEGORIA WHERE CD_CATEGORIA=:CD_CATEGORIA", new { CD_CATEGORIA });
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
