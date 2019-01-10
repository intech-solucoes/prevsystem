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
    public abstract class PrazosDisponiveisDAO : BaseDAO<PrazosDisponiveisEntidade>
    {
        
		public virtual IEnumerable<PrazosDisponiveisEntidade> BuscarPorNatureza(decimal CD_NATUR)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR = @CD_NATUR", new { CD_NATUR });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR=:CD_NATUR", new { CD_NATUR });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PrazosDisponiveisEntidade> BuscarPorNaturezaPrazo(decimal CD_NATUR, decimal PRAZO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR = @CD_NATUR   AND PRAZO = @PRAZO", new { CD_NATUR, PRAZO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR=:CD_NATUR AND PRAZO=:PRAZO", new { CD_NATUR, PRAZO });
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
