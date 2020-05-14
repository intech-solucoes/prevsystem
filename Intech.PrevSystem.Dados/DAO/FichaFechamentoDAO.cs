using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FichaFechamentoDAO : BaseDAO<FichaFechamentoEntidade>
	{
		public virtual DateTime BuscarDataPrimeiraContrib(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DateTime>("SELECT MIN(DT_FECHAMENTO)  FROM CC_FICHA_FECHAMENTO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DateTime>("SELECT MIN(DT_FECHAMENTO) FROM CC_FICHA_FECHAMENTO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual DateTime BuscarDataUltimaContrib(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DateTime>("SELECT MAX(DT_FECHAMENTO)  FROM CC_FICHA_FECHAMENTO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_PLANO = @CD_PLANO    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DateTime>("SELECT MAX(DT_FECHAMENTO) FROM CC_FICHA_FECHAMENTO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoEntidade> BuscarPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT *  FROM CC_FICHA_FECHAMENTO FF  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO  FF  WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoEntidade> BuscarRelatorioPorFundacaoEmpresaPlanoInscricaoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string DT_INICIO, string DT_FIM)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT FF.*  FROM CC_FICHA_FECHAMENTO FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND ('' + FF.ANO_REF + FF.MES_REF BETWEEN @DT_INICIO AND @DT_FIM)  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT FF.* FROM CC_FICHA_FECHAMENTO  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND ('' || FF.ANO_REF || FF.MES_REF BETWEEN :DT_INICIO AND :DT_FIM) ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FichaFechamentoEntidade BuscarUltimaPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoEntidade>("SELECT *  FROM CC_FICHA_FECHAMENTO FF  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.ANO_REF = (SELECT MAX(FF1.ANO_REF)  				    FROM CC_FICHA_FECHAMENTO FF1  				    WHERE FF1.CD_FUNDACAO = FF.CD_FUNDACAO  				    AND FF1.CD_PLANO = FF.CD_PLANO  				    AND FF1.NUM_INSCRICAO = FF.NUM_INSCRICAO)    AND FF.MES_REF = (SELECT MAX(FF1.MES_REF)  				    FROM CC_FICHA_FECHAMENTO FF1  				    WHERE FF1.CD_FUNDACAO = FF.CD_FUNDACAO  				    AND FF1.CD_PLANO = FF.CD_PLANO  				    AND FF1.NUM_INSCRICAO = FF.NUM_INSCRICAO                      AND FF1.ANO_REF = FF.ANO_REF)  ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO  FF  WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.ANO_REF=(SELECT MAX(FF1.ANO_REF) FROM CC_FICHA_FECHAMENTO  FF1  WHERE FF1.CD_FUNDACAO=FF.CD_FUNDACAO AND FF1.CD_PLANO=FF.CD_PLANO AND FF1.NUM_INSCRICAO=FF.NUM_INSCRICAO) AND FF.MES_REF=(SELECT MAX(FF1.MES_REF) FROM CC_FICHA_FECHAMENTO  FF1  WHERE FF1.CD_FUNDACAO=FF.CD_FUNDACAO AND FF1.CD_PLANO=FF.CD_PLANO AND FF1.NUM_INSCRICAO=FF.NUM_INSCRICAO AND FF1.ANO_REF=FF.ANO_REF) ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
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
