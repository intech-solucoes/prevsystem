using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class CarenciasDisponiveisDAO : BaseDAO<CarenciasDisponiveisEntidade>
	{
		public CarenciasDisponiveisDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<CarenciasDisponiveisEntidade> BuscarPorNatureza(decimal CD_NATUR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<CarenciasDisponiveisEntidade>("SELECT * FROM CE_CARENCIAS_DISPONIVEIS WHERE CD_NATUR = @CD_NATUR   AND DISPONIVEL = 'S'", new { CD_NATUR }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<CarenciasDisponiveisEntidade>("SELECT * FROM CE_CARENCIAS_DISPONIVEIS WHERE CD_NATUR=:CD_NATUR AND DISPONIVEL='S'", new { CD_NATUR }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}