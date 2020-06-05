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
    public abstract class WebRecadCampanhaDAO : BaseDAO<WebRecadCampanhaEntidade>
    {
        
		public virtual WebRecadCampanhaEntidade BuscarPorCodigo(decimal OID_RECAD_CAMPANHA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadCampanhaEntidade>("SELECT *   FROM WEB_RECAD_CAMPANHA  WHERE OID_RECAD_CAMPANHA = @OID_RECAD_CAMPANHA", new { OID_RECAD_CAMPANHA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadCampanhaEntidade>("SELECT * FROM WEB_RECAD_CAMPANHA WHERE OID_RECAD_CAMPANHA=:OID_RECAD_CAMPANHA", new { OID_RECAD_CAMPANHA });
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
