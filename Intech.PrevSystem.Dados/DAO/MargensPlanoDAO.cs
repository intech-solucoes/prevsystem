using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class MargensPlanoDAO : BaseDAO<MargensPlanoEntidade>
	{
		public virtual MargensPlanoEntidade BuscarPorFundacaoEmpresaPlanoModalNaturEmVigencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, decimal CD_MODAL, decimal CD_NATUR, DateTime DT_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensPlanoEntidade>("SELECT TOP 1 *  FROM CE_MARGENS_PLANO  WHERE (CD_FUNDACAO = @CD_FUNDACAO)    AND (CD_EMPRESA = @CD_EMPRESA)    AND (CD_PLANO = @CD_PLANO)    AND (CD_MODAL = @CD_MODAL)    AND (CD_NATUR = @CD_NATUR)    AND (DT_VIGENCIA <= @DT_VIGENCIA)  ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_MODAL, CD_NATUR, DT_VIGENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensPlanoEntidade>("SELECT * FROM CE_MARGENS_PLANO WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (CD_PLANO=:CD_PLANO) AND (CD_MODAL=:CD_MODAL) AND (CD_NATUR=:CD_NATUR) AND (DT_VIGENCIA<=:DT_VIGENCIA) AND ROWNUM <= 1  ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_MODAL, CD_NATUR, DT_VIGENCIA });
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
