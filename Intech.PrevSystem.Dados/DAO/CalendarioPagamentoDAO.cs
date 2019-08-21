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
    public abstract class CalendarioPagamentoDAO : BaseDAO<CalendarioPagamentoEntidade>
    {
        
		public virtual IEnumerable<CalendarioPagamentoEntidade> BuscarPorPlano(string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<CalendarioPagamentoEntidade>("SELECT *  FROM WEB_CALENDARIO_PGT  WHERE CD_PLANO = @CD_PLANO", new { CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<CalendarioPagamentoEntidade>("SELECT * FROM WEB_CALENDARIO_PGT WHERE CD_PLANO=:CD_PLANO", new { CD_PLANO });
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
