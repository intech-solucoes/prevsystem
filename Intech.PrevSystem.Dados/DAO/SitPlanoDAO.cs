using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class SitPlanoDAO : BaseDAO<SitPlanoEntidade>
	{
		public virtual SitPlanoEntidade BuscarPorCdSituacao(string CD_SIT_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SitPlanoEntidade>("SELECT *  FROM TB_SIT_PLANO  WHERE CD_SIT_PLANO = @CD_SIT_PLANO", new { CD_SIT_PLANO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO WHERE CD_SIT_PLANO=:CD_SIT_PLANO", new { CD_SIT_PLANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<SitPlanoEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<SitPlanoEntidade>("SELECT *  FROM TB_SIT_PLANO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO", new {  }).ToList();
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
