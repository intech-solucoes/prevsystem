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
    public abstract class TempoServicoDAO : BaseDAO<TempoServicoEntidade>
    {
        
		public virtual IEnumerable<TempoServicoEntidade> BuscarPorCodEntid(int COD_ENTID)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TempoServicoEntidade>("SELECT *  FROM CS_TEMPO_SERVICO WHERE COD_ENTID = @COD_ENTID   AND DT_INIC_ATIVIDADE IS NOT NULL", new { COD_ENTID });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TempoServicoEntidade>("SELECT * FROM CS_TEMPO_SERVICO WHERE COD_ENTID=:COD_ENTID AND DT_INIC_ATIVIDADE IS  NOT NULL ", new { COD_ENTID });
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
