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
    public abstract class BancoAgDAO : BaseDAO<BancoAgEntidade>
    {
        
		public virtual BancoAgEntidade BuscarPorCodBancoCodAgencia(string COD_BANCO, string COD_AGENC)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<BancoAgEntidade>("SELECT * FROM  TB_BANCO_AG WHERE COD_BANCO = @COD_BANCO   AND COD_AGENC = @COD_AGENC", new { COD_BANCO, COD_AGENC });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<BancoAgEntidade>("SELECT * FROM TB_BANCO_AG WHERE COD_BANCO=:COD_BANCO AND COD_AGENC=:COD_AGENC", new { COD_BANCO, COD_AGENC });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
