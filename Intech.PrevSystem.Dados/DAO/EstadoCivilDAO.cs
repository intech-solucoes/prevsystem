using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class EstadoCivilDAO : BaseDAO<EstadoCivilEntidade>
	{
		public virtual EstadoCivilEntidade BuscarPorCodigo(string CD_ESTADO_CIVIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<EstadoCivilEntidade>("SELECT *   FROM CS_ESTADO_CIVIL  WHERE CD_ESTADO_CIVIL = @CD_ESTADO_CIVIL", new { CD_ESTADO_CIVIL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<EstadoCivilEntidade>("SELECT * FROM CS_ESTADO_CIVIL WHERE CD_ESTADO_CIVIL=:CD_ESTADO_CIVIL", new { CD_ESTADO_CIVIL });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<EstadoCivilEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<EstadoCivilEntidade>("SELECT *   FROM CS_ESTADO_CIVIL  WHERE CD_ESTADO_CIVIL > 0  ORDER BY DS_ESTADO_CIVIL", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<EstadoCivilEntidade>("SELECT * FROM CS_ESTADO_CIVIL WHERE CD_ESTADO_CIVIL>0 ORDER BY DS_ESTADO_CIVIL", new {  }).ToList();
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
