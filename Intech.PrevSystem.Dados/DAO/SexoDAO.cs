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
	public abstract class SexoDAO : BaseDAO<SexoEntidade>
	{
		public SexoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual SexoEntidade BuscarPorCodigo(string CD_SEXO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SexoEntidade>("SELECT *  FROM TB_SEXO WHERE CD_SEXO = @CD_SEXO", new { CD_SEXO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SexoEntidade>("SELECT * FROM TB_SEXO WHERE CD_SEXO=:CD_SEXO", new { CD_SEXO }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<SexoEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<SexoEntidade>("SELECT * FROM TB_SEXO ORDER BY DS_SEXO", new {  }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<SexoEntidade>("SELECT * FROM TB_SEXO ORDER BY DS_SEXO", new {  }, Transaction).ToList();
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