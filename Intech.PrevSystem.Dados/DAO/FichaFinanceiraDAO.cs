#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class FichaFinanceiraDAO : BaseDAO<FichaFinanceiraEntidade>
    {
        
		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarPlanoUmDoisPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT CC_FICHA_FINANCEIRA.* FROM CC_FICHA_FINANCEIRA INNER JOIN TB_TIPO_CONTRIBUICAO ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO = CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO WHERE (CC_FICHA_FINANCEIRA.CD_FUNDACAO = @CD_FUNDACAO)   AND (CC_FICHA_FINANCEIRA.NUM_INSCRICAO = @NUM_INSCRICAO)   AND (CC_FICHA_FINANCEIRA.CD_PLANO IN ('0001', '0002'))   AND (TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG = 'S')", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT CC_FICHA_FINANCEIRA.* FROM CC_FICHA_FINANCEIRA INNER  JOIN TB_TIPO_CONTRIBUICAO  ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO=CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO WHERE (CC_FICHA_FINANCEIRA.CD_FUNDACAO=:CD_FUNDACAO) AND (CC_FICHA_FINANCEIRA.NUM_INSCRICAO=:NUM_INSCRICAO) AND (CC_FICHA_FINANCEIRA.CD_PLANO IN ('0001', '0002')) AND (TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG='S')", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT TC.DS_TIPO_CONTRIBUICAO,        TC.CALC_MARGEM_CONSIG,        FI.*  FROM CC_FICHA_FINANCEIRA FI INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO WHERE FI.CD_FUNDACAO = @CD_FUNDACAO   AND FI.CD_PLANO = @CD_PLANO   AND FI.NUM_INSCRICAO = @NUM_INSCRICAO ORDER BY FI.ANO_REF DESC,           FI.MES_REF DESC,          FI.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT TC.DS_TIPO_CONTRIBUICAO, TC.CALC_MARGEM_CONSIG, FI.* FROM CC_FICHA_FINANCEIRA  FI  INNER  JOIN TB_TIPO_CONTRIBUICAO   TC  ON TC.CD_TIPO_CONTRIBUICAO=FI.CD_TIPO_CONTRIBUICAO WHERE FI.CD_FUNDACAO=:CD_FUNDACAO AND FI.CD_PLANO=:CD_PLANO AND FI.NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY FI.ANO_REF DESC, FI.MES_REF DESC, FI.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarResumoAnosPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *  FROM CC_FICHA_FINANCEIRA FI WHERE FI.CD_FUNDACAO = @CD_FUNDACAO   AND FI.CD_PLANO = @CD_PLANO   AND FI.NUM_INSCRICAO = @NUM_INSCRICAO ORDER BY FI.ANO_REF DESC", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT * FROM CC_FICHA_FINANCEIRA  FI  WHERE FI.CD_FUNDACAO=:CD_FUNDACAO AND FI.CD_PLANO=:CD_PLANO AND FI.NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY FI.ANO_REF DESC", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarResumoMesesPorFundacaoPlanoInscricaoAno(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *  FROM CC_FICHA_FINANCEIRA FI WHERE FI.CD_FUNDACAO = @CD_FUNDACAO   AND FI.CD_PLANO = @CD_PLANO   AND FI.NUM_INSCRICAO = @NUM_INSCRICAO   AND FI.ANO_REF = @ANO_REF ORDER BY FI.MES_REF", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT * FROM CC_FICHA_FINANCEIRA  FI  WHERE FI.CD_FUNDACAO=:CD_FUNDACAO AND FI.CD_PLANO=:CD_PLANO AND FI.NUM_INSCRICAO=:NUM_INSCRICAO AND FI.ANO_REF=:ANO_REF ORDER BY FI.MES_REF", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarTiposPorFundacaoPlanoInscricaoAnoMes(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO, string ANO_REF, string MES_REF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *  FROM CC_FICHA_FINANCEIRA FI INNER JOIN TB_TIPO_CONTRIBUICAO TC ON  TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO WHERE FI.CD_FUNDACAO = @CD_FUNDACAO   AND FI.CD_PLANO = @CD_PLANO   AND FI.NUM_INSCRICAO = @NUM_INSCRICAO   AND FI.ANO_REF = @ANO_REF   AND FI.MES_REF = @MES_REF ORDER BY TC.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF, MES_REF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT * FROM CC_FICHA_FINANCEIRA  FI  INNER  JOIN TB_TIPO_CONTRIBUICAO   TC  ON TC.CD_TIPO_CONTRIBUICAO=FI.CD_TIPO_CONTRIBUICAO WHERE FI.CD_FUNDACAO=:CD_FUNDACAO AND FI.CD_PLANO=:CD_PLANO AND FI.NUM_INSCRICAO=:NUM_INSCRICAO AND FI.ANO_REF=:ANO_REF AND FI.MES_REF=:MES_REF ORDER BY TC.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF, MES_REF });
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
