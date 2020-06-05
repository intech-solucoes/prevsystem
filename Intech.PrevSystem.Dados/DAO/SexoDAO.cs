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
    public abstract class SexoDAO : BaseDAO<SexoEntidade>
    {
        
		public virtual SexoEntidade BuscarPorCodigo(string CD_SEXO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<SexoEntidade>("SELECT *   FROM TB_SEXO  WHERE CD_SEXO = @CD_SEXO", new { CD_SEXO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<SexoEntidade>("SELECT * FROM TB_SEXO WHERE CD_SEXO=:CD_SEXO", new { CD_SEXO });
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
