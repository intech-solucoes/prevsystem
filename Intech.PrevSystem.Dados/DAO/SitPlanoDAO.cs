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
        
		public virtual IEnumerable<SitPlanoEntidade> BuscarTodos()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<SitPlanoEntidade>("SELECT * FROM TB_SIT_PLANO", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
