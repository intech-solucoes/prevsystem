using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class MargensDAO : BaseDAO<MargensEntidade>
	{
		public virtual MargensEntidade BuscarPorFundacaoEmpresaEmVigencia(string CD_FUNDACAO, string CD_EMPRESA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT TOP 1 *  FROM CE_MARGENS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND DT_VIGENCIA = (SELECT MAX(MAR.DT_VIGENCIA)                         FROM CE_MARGENS MAR                         WHERE MAR.CD_FUNDACAO = CE_MARGENS.CD_FUNDACAO                           AND MAR.CD_EMPRESA = CE_MARGENS.CD_EMPRESA                           AND MAR.CD_MODAL = CE_MARGENS.CD_MODAL                           AND MAR.CD_NATUR = CE_MARGENS.CD_NATUR)", new { CD_FUNDACAO, CD_EMPRESA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT * FROM CE_MARGENS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND DT_VIGENCIA=(SELECT MAX(MAR.DT_VIGENCIA) FROM CE_MARGENS  MAR  WHERE MAR.CD_FUNDACAO=CE_MARGENS.CD_FUNDACAO AND MAR.CD_EMPRESA=CE_MARGENS.CD_EMPRESA AND MAR.CD_MODAL=CE_MARGENS.CD_MODAL AND MAR.CD_NATUR=CE_MARGENS.CD_NATUR) AND ROWNUM <= 1 ", new { CD_FUNDACAO, CD_EMPRESA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual MargensEntidade BuscarPorFundacaoEmpresaModalidadeNaturezaEmVigencia(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR, DateTime DT_VIGENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT TOP 1 *  FROM CE_MARGENS  WHERE (CD_FUNDACAO = @CD_FUNDACAO)    AND (CD_MODAL = @CD_MODAL)    AND (CD_NATUR = @CD_NATUR)    AND (CD_EMPRESA = @CD_EMPRESA)    AND (DT_VIGENCIA <= @DT_VIGENCIA)  ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, DT_VIGENCIA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensEntidade>("SELECT * FROM CE_MARGENS WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_MODAL=:CD_MODAL) AND (CD_NATUR=:CD_NATUR) AND (CD_EMPRESA=:CD_EMPRESA) AND (DT_VIGENCIA<=:DT_VIGENCIA) AND ROWNUM <= 1  ORDER BY DT_VIGENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR, DT_VIGENCIA });
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
