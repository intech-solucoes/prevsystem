using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class CalendarioPagamentoDAO : BaseDAO<CalendarioPagamentoEntidade>
	{
		public virtual List<CalendarioPagamentoEntidade> BuscarPorPlano(string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<CalendarioPagamentoEntidade>("SELECT *  FROM WEB_CALENDARIO_PGT  WHERE CD_PLANO = @CD_PLANO", new { CD_PLANO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<CalendarioPagamentoEntidade>("SELECT * FROM WEB_CALENDARIO_PGT WHERE CD_PLANO=:CD_PLANO", new { CD_PLANO }).ToList();
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
