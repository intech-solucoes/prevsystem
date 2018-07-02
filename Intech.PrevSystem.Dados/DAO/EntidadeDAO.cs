#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{
    public abstract class EntidadeDAO : BaseDAO<EntidadeEntidade>
    {
		public virtual EntidadeEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<EntidadeEntidade>("SELECT * FROM EE_ENTIDADE WHERE COD_ENTID = @COD_ENTID", new { COD_ENTID });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<EntidadeEntidade>("SELECT * FROM EE_ENTIDADE WHERE COD_ENTID=:COD_ENTID", new { COD_ENTID });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
