using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PrazosDisponiveisDAO : BaseDAO<PrazosDisponiveisEntidade>
	{
		public virtual List<PrazosDisponiveisEntidade> BuscarPorNatureza(decimal CD_NATUR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT *  FROM CE_PRAZOS_DISPONIVEIS  WHERE CD_NATUR = @CD_NATUR", new { CD_NATUR }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR=:CD_NATUR", new { CD_NATUR }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<PrazosDisponiveisEntidade> BuscarPorNaturezaPrazo(decimal CD_NATUR, decimal PRAZO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT *  FROM CE_PRAZOS_DISPONIVEIS  WHERE CD_NATUR = @CD_NATUR    AND PRAZO = @PRAZO", new { CD_NATUR, PRAZO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PrazosDisponiveisEntidade>("SELECT * FROM CE_PRAZOS_DISPONIVEIS WHERE CD_NATUR=:CD_NATUR AND PRAZO=:PRAZO", new { CD_NATUR, PRAZO }).ToList();
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
