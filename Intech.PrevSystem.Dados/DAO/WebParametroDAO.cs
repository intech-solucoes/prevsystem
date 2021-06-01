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
	public abstract class WebParametroDAO : BaseDAO<WebParametroEntidade>
	{
		public WebParametroDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<WebParametroEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebParametroEntidade>("SELECT * FROM WEB_PARAMETRO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebParametroEntidade>("SELECT * FROM WEB_PARAMETRO", new {  }).ToList();
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
