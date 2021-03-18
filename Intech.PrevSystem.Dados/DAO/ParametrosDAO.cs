using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class ParametrosDAO : BaseDAO<ParametrosEntidade>
	{
		public ParametrosDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual ParametrosEntidade Buscar()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ParametrosEntidade>("SELECT * FROM CE_PARAMETROS", new {  }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ParametrosEntidade>("SELECT * FROM CE_PARAMETROS", new {  }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}