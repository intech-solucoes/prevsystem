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
	public abstract class UFDAO : BaseDAO<UFEntidade>
	{
		public UFDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual UFEntidade BuscarPorCdUF(string UF_ENTID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UFEntidade>("SELECT * FROM TB_UNID_FED WHERE CD_UNID_FED = @UF_ENTID", new { UF_ENTID });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UFEntidade>("SELECT * FROM TB_UNID_FED WHERE CD_UNID_FED=:UF_ENTID", new { UF_ENTID });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<UFEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UFEntidade>("SELECT * FROM TB_UNID_FED", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UFEntidade>("SELECT * FROM TB_UNID_FED", new {  }).ToList();
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
