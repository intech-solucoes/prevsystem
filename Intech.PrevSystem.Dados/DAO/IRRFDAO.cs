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
	public abstract class IRRFDAO : BaseDAO<IRRFEntidade>
	{
		public IRRFDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<IRRFEntidade> BuscarPorDataReferenciaTipo(DateTime DT_REFERENCIA, decimal TIPO_IRRF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IRRFEntidade>("SELECT * FROM   TB_IRRF WHERE ( DT_REFERENCIA <= @DT_REFERENCIA )   AND ( TIPO_IRRF = @TIPO_IRRF ) ORDER  BY DT_REFERENCIA DESC", new { DT_REFERENCIA, TIPO_IRRF }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IRRFEntidade>("SELECT * FROM TB_IRRF WHERE (DT_REFERENCIA<=:DT_REFERENCIA) AND (TIPO_IRRF=:TIPO_IRRF) ORDER BY DT_REFERENCIA DESC", new { DT_REFERENCIA, TIPO_IRRF }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual IRRFEntidade BuscarPorReferencia(DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT * FROM TB_IRRF WHERE DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA)                          FROM TB_IRRF                         WHERE DT_REFERENCIA <= @DT_REFERENCIA)", new { DT_REFERENCIA }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<IRRFEntidade>("SELECT * FROM TB_IRRF WHERE DT_REFERENCIA=(SELECT MAX(DT_REFERENCIA) FROM TB_IRRF WHERE DT_REFERENCIA<=:DT_REFERENCIA)", new { DT_REFERENCIA }, Transaction);
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