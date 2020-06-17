using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PaisDAO : BaseDAO<PaisEntidade>
	{
		public virtual PaisEntidade BuscarPorCdPais(string CD_PAIS)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PaisEntidade>("SELECT * FROM TB_PAIS WHERE CD_PAIS = @CD_PAIS", new { CD_PAIS });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PaisEntidade>("SELECT * FROM TB_PAIS WHERE CD_PAIS=:CD_PAIS", new { CD_PAIS });
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
