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
    public abstract class FatAtuMetrusG1DAO : BaseDAO<FatAtuMetrusG1Entidade>
    {
        
		public virtual FatAtuMetrusG1Entidade BuscarPorTipoIdade(string TIPO, int IDADE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatAtuMetrusG1Entidade>("SELECT * FROM GB_FAT_ATU_METRUS_G1  WHERE IDADE = @IDADE    AND TIPO = @TIPO", new { TIPO, IDADE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatAtuMetrusG1Entidade>("SELECT * FROM GB_FAT_ATU_METRUS_G1 WHERE IDADE=:IDADE AND TIPO=:TIPO", new { TIPO, IDADE });
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
