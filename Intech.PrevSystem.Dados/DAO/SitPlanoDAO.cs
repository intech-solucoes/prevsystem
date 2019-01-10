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
    public abstract class SitPlanoDAO : BaseDAO<SitPlanoEntidade>
    {
        
		public virtual SitPlanoEntidade BuscarPorCdSituacao(string CD_SIT_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO WHERE CD_SIT_PLANO = @CD_SIT_PLANO", new { CD_SIT_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO WHERE CD_SIT_PLANO=:CD_SIT_PLANO", new { CD_SIT_PLANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<SitPlanoEntidade> BuscarTodos()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO", new {  });
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
