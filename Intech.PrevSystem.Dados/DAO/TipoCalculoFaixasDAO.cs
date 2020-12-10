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
	public abstract class TipoCalculoFaixasDAO : BaseDAO<TipoCalculoFaixasEntidade>
	{
		public TipoCalculoFaixasDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<TipoCalculoFaixasEntidade> BuscarPorCdCalculo(int CD_CALCULO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TipoCalculoFaixasEntidade>("SELECT *  FROM   GB_TIPO_CALCULO_FAIXAS  WHERE  ( CD_CALCULO = @CD_CALCULO )         AND ( DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1                                FROM   GB_TIPO_CALCULO                                WHERE  ( CD_CALCULO = @CD_CALCULO )) )", new { CD_CALCULO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TipoCalculoFaixasEntidade>("SELECT * FROM GB_TIPO_CALCULO_FAIXAS WHERE (CD_CALCULO=:CD_CALCULO) AND (DT_REFERENCIA=(SELECT MAX(DT_REFERENCIA) AS EXPR1 FROM GB_TIPO_CALCULO WHERE (CD_CALCULO=:CD_CALCULO)))", new { CD_CALCULO }).ToList();
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
