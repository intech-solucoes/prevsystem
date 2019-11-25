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
    public abstract class ProtocoloDAO : BaseDAO<ProtocoloEntidade>
    {
        
		public virtual ProtocoloEntidade BuscarPorFuncionalidade(decimal OID_FUNCIONALIDADE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT *  FROM WEB_PROTOCOLO  WHERE OID_FUNCIONALIDADE = @OID_FUNCIONALIDADE", new { OID_FUNCIONALIDADE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ProtocoloEntidade>("SELECT * FROM WEB_PROTOCOLO WHERE OID_FUNCIONALIDADE=:OID_FUNCIONALIDADE", new { OID_FUNCIONALIDADE });
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
