using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class RelIRRFDAO : BaseDAO<RelIRRFEntidade>
	{
		public virtual List<DateTime> BuscarAnosPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DateTime>("SELECT DT_REF   FROM CE_REL_IRRF  WHERE NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_FUNDACAO = @CD_FUNDACAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DateTime>("SELECT DT_REF FROM CE_REL_IRRF WHERE NUM_INSCRICAO=:NUM_INSCRICAO AND CD_FUNDACAO=:CD_FUNDACAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual RelIRRFEntidade BuscarPorFundacaoInscricaoReferencia(string CD_FUNDACAO, string NUM_INSCRICAO, DateTime DT_REF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RelIRRFEntidade>("SELECT *   FROM CE_REL_IRRF  WHERE NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_FUNDACAO = @CD_FUNDACAO    AND DT_REF = @DT_REF", new { CD_FUNDACAO, NUM_INSCRICAO, DT_REF });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RelIRRFEntidade>("SELECT * FROM CE_REL_IRRF WHERE NUM_INSCRICAO=:NUM_INSCRICAO AND CD_FUNDACAO=:CD_FUNDACAO AND DT_REF=:DT_REF", new { CD_FUNDACAO, NUM_INSCRICAO, DT_REF });
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
