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
    public abstract class SitContratoDAO : BaseDAO<SitContratoEntidade>
    {
        
		public virtual IEnumerable<SitContratoEntidade> Buscar()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<SitContratoEntidade>("SELECT * FROM CE_SITUACAO_CONTRATO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<SitContratoEntidade>("SELECT * FROM CE_SITUACAO_CONTRATO", new {  });
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
