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
    public abstract class DirfDAO : BaseDAO<DirfEntidade>
    {
        
		public virtual IEnumerable<DirfEntidade> Buscar()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DirfEntidade>("SELECT *   FROM TB_DIRF", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DirfEntidade>("SELECT * FROM TB_DIRF", new {  });
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
