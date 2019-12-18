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
    public abstract class InfoRendDAO : BaseDAO<InfoRendEntidade>
    {
        
		public virtual IEnumerable<InfoRendEntidade> BuscarPorOidHeader(decimal OID_HEADER_INFO_REND)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<InfoRendEntidade>("SELECT *  FROM TB_INFO_REND  WHERE OID_HEADER_INFO_REND = @OID_HEADER_INFO_REND", new { OID_HEADER_INFO_REND });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<InfoRendEntidade>("SELECT * FROM TB_INFO_REND WHERE OID_HEADER_INFO_REND=:OID_HEADER_INFO_REND", new { OID_HEADER_INFO_REND });
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
