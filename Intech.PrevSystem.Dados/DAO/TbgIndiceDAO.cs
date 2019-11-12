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
    public abstract class TbgIndiceDAO : BaseDAO<TbgIndiceEntidade>
    {
        
		public virtual TbgIndiceEntidade BuscarPorCodIndice(string COD_INDICE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<TbgIndiceEntidade>("SELECT *  FROM TBG_INDICE  WHERE COD_INDICE = @COD_INDICE", new { COD_INDICE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<TbgIndiceEntidade>("SELECT * FROM TBG_INDICE WHERE COD_INDICE=:COD_INDICE", new { COD_INDICE });
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
