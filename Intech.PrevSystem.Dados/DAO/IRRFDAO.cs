using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class IRRFDAO : BaseDAO<IRRFEntidade>
	{
		public virtual IRRFEntidade BuscarPorReferencia(DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT *  FROM TB_IRRF  WHERE DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA)                           FROM TB_IRRF                          WHERE DT_REFERENCIA <= @DT_REFERENCIA)", new { DT_REFERENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT * FROM TB_IRRF WHERE DT_REFERENCIA=(SELECT MAX(DT_REFERENCIA) FROM TB_IRRF WHERE DT_REFERENCIA<=:DT_REFERENCIA)", new { DT_REFERENCIA });
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
