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
	public abstract class FuncionalidadeDAO : BaseDAO<FuncionalidadeEntidade>
	{
		public FuncionalidadeDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FuncionalidadeEntidade> BuscarPorIndAtivo(string IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionalidadeEntidade>("SELECT *    FROM WEB_FUNCIONALIDADE WHERE IND_ATIVO = @IND_ATIVO ORDER BY DES_FUNCIONALIDADE", new { IND_ATIVO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionalidadeEntidade>("SELECT * FROM WEB_FUNCIONALIDADE WHERE IND_ATIVO=:IND_ATIVO ORDER BY DES_FUNCIONALIDADE", new { IND_ATIVO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual FuncionalidadeEntidade BuscarPorNumFuncionalidade(decimal NUM_FUNCIONALIDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionalidadeEntidade>("SELECT *    FROM WEB_FUNCIONALIDADE WHERE NUM_FUNCIONALIDADE = @NUM_FUNCIONALIDADE", new { NUM_FUNCIONALIDADE }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionalidadeEntidade>("SELECT * FROM WEB_FUNCIONALIDADE WHERE NUM_FUNCIONALIDADE=:NUM_FUNCIONALIDADE", new { NUM_FUNCIONALIDADE }, Transaction);
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