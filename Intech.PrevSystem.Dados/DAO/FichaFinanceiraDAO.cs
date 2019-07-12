﻿#region Usings
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
        
		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarDatasInformePorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT DISTINCT FF.ANO_REF  FROM CC_FICHA_FINANCEIRA FF  	INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = FF.CD_FUNDACAO   			AND FN.NUM_INSCRICAO = FF.NUM_INSCRICAO  	INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO  WHERE TC.CK_COMPOE_IR_AM = 'S'    AND FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO  GROUP BY FF.ANO_REF  ORDER BY FF.ANO_REF DESC", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT DISTINCT FF.ANO_REF FROM CC_FICHA_FINANCEIRA  FF  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=FF.CD_FUNDACAO AND FN.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_TIPO_CONTRIBUICAO   TC  ON TC.CD_TIPO_CONTRIBUICAO=FF.CD_TIPO_CONTRIBUICAO WHERE TC.CK_COMPOE_IR_AM='S' AND FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO GROUP BY FF.ANO_REF ORDER BY FF.ANO_REF DESC", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarInformePorFundacaoInscricaoAno(string CD_FUNDACAO, string NUM_INSCRICAO, string ANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT FF.ANO_REF,         FF.MES_REF,  	   SUM(FF.CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE  FROM CC_FICHA_FINANCEIRA FF  	INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = FF.CD_FUNDACAO   			AND FN.NUM_INSCRICAO = FF.NUM_INSCRICAO  	INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO  WHERE TC.CK_COMPOE_IR_AM = 'S'    AND FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.ANO_REF = @ANO  GROUP BY FF.ANO_REF,           FF.MES_REF  ORDER BY FF.ANO_REF,           FF.MES_REF;", new { CD_FUNDACAO, NUM_INSCRICAO, ANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT FF.ANO_REF, FF.MES_REF, SUM(FF.CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE FROM CC_FICHA_FINANCEIRA  FF  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=FF.CD_FUNDACAO AND FN.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_TIPO_CONTRIBUICAO   TC  ON TC.CD_TIPO_CONTRIBUICAO=FF.CD_TIPO_CONTRIBUICAO WHERE TC.CK_COMPOE_IR_AM='S' AND FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.ANO_REF=:ANO GROUP BY FF.ANO_REF, FF.MES_REF ORDER BY FF.ANO_REF, FF.MES_REF", new { CD_FUNDACAO, NUM_INSCRICAO, ANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarPlanoUmDoisPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT CC_FICHA_FINANCEIRA.*  FROM CC_FICHA_FINANCEIRA  INNER JOIN TB_TIPO_CONTRIBUICAO ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO = CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO  WHERE (CC_FICHA_FINANCEIRA.CD_FUNDACAO = @CD_FUNDACAO)    AND (CC_FICHA_FINANCEIRA.NUM_INSCRICAO = @NUM_INSCRICAO)    AND (CC_FICHA_FINANCEIRA.CD_PLANO IN ('0001', '0002'))    AND (TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG = 'S')", new { CD_FUNDACAO, NUM_INSCRICAO });
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
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT TC.DS_TIPO_CONTRIBUICAO,         TC.CALC_MARGEM_CONSIG,         FI.*   FROM CC_FICHA_FINANCEIRA FI  INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO  WHERE FI.CD_FUNDACAO = @CD_FUNDACAO    AND FI.CD_PLANO = @CD_PLANO    AND FI.NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY FI.ANO_REF DESC,            FI.MES_REF DESC,           FI.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
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
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *   FROM CC_FICHA_FINANCEIRA FI  WHERE FI.CD_FUNDACAO = @CD_FUNDACAO    AND FI.CD_PLANO = @CD_PLANO    AND FI.NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY FI.ANO_REF DESC", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
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

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarResumoCusteio(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT FF.ANO_REF,         FF.MES_REF,          TC.COD_AGRUPADOR_WEB,  	   CASE   			WHEN TC.COD_AGRUPADOR_WEB = 'ADMPA' THEN 'Adm. Participante'  			WHEN TC.COD_AGRUPADOR_WEB = 'ADMPT' THEN 'Adm. Patrocinadora'  			WHEN TC.COD_AGRUPADOR_WEB = 'RIPA' THEN 'Risco Participante'  			WHEN TC.COD_AGRUPADOR_WEB = 'RIPT' THEN 'Risco Patrocinadora'  			else 'Falta Agrupador WEB'  		end as DS_AGRUPADOR_WEB,         SUM(FF.CONTRIB_EMPRESA + FF.CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE   FROM CC_FICHA_FINANCEIRA FF      INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.CD_PLANO = @CD_PLANO    AND TC.COD_AGRUPADOR_WEB IN ('ADMPA', 'ADMPT', 'RIPA', 'RIPT')    AND (FF.ANO_REF * 12 + FF.MES_REF) = (SELECT MAX(FF2.ANO_REF * 12 + FF2.MES_REF)                                            FROM CC_FICHA_FINANCEIRA FF2                                            WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO                                             AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO                                             AND FF2.CD_PLANO = FF.CD_PLANO)          GROUP BY FF.ANO_REF,           FF.MES_REF,            TC.COD_AGRUPADOR_WEB", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
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
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *   FROM CC_FICHA_FINANCEIRA FI  WHERE FI.CD_FUNDACAO = @CD_FUNDACAO    AND FI.CD_PLANO = @CD_PLANO    AND FI.NUM_INSCRICAO = @NUM_INSCRICAO    AND FI.ANO_REF = @ANO_REF  ORDER BY FI.MES_REF", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF });
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
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT *   FROM CC_FICHA_FINANCEIRA FI  INNER JOIN TB_TIPO_CONTRIBUICAO TC ON  TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO  WHERE FI.CD_FUNDACAO = @CD_FUNDACAO    AND FI.CD_PLANO = @CD_PLANO    AND FI.NUM_INSCRICAO = @NUM_INSCRICAO    AND FI.ANO_REF = @ANO_REF    AND FI.MES_REF = @MES_REF  ORDER BY TC.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, ANO_REF, MES_REF });
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

		public virtual IEnumerable<FichaFinanceiraEntidade> BuscarUltimaPorFundacaoPlanoInscricao(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT TB_TIPO_CONTRIBUICAO.DS_TIPO_CONTRIBUICAO,         TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG,         TB_TIPO_CONTRIBUICAO.COMPOE_SALDO_BENEFICIO,         CC_FICHA_FINANCEIRA.*   FROM CC_FICHA_FINANCEIRA  INNER JOIN TB_TIPO_CONTRIBUICAO ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO = CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO  WHERE CC_FICHA_FINANCEIRA.CD_FUNDACAO = @CD_FUNDACAO    AND CC_FICHA_FINANCEIRA.CD_PLANO = @CD_PLANO    AND CC_FICHA_FINANCEIRA.NUM_INSCRICAO = @NUM_INSCRICAO    AND CC_FICHA_FINANCEIRA.SRC > 0    AND CC_FICHA_FINANCEIRA.ANO_REF = (SELECT MAX(FF1.ANO_REF)  				                     FROM CC_FICHA_FINANCEIRA FF1  				                     WHERE FF1.CD_FUNDACAO = @CD_FUNDACAO  				                       AND FF1.CD_PLANO = @CD_PLANO  									   AND FF1.SRC > 0  				                       AND FF1.NUM_INSCRICAO = @NUM_INSCRICAO)    AND CC_FICHA_FINANCEIRA.MES_REF = (SELECT MAX(FF1.MES_REF)  				                     FROM CC_FICHA_FINANCEIRA FF1  				                     WHERE FF1.CD_FUNDACAO = @CD_FUNDACAO  				                       AND FF1.CD_PLANO = @CD_PLANO  				                       AND FF1.NUM_INSCRICAO = @NUM_INSCRICAO  									   AND FF1.SRC > 0                                         AND FF1.ANO_REF = CC_FICHA_FINANCEIRA.ANO_REF)  ORDER BY CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFinanceiraEntidade>("SELECT TB_TIPO_CONTRIBUICAO.DS_TIPO_CONTRIBUICAO, TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG, TB_TIPO_CONTRIBUICAO.COMPOE_SALDO_BENEFICIO, CC_FICHA_FINANCEIRA.* FROM CC_FICHA_FINANCEIRA INNER  JOIN TB_TIPO_CONTRIBUICAO  ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO=CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO WHERE CC_FICHA_FINANCEIRA.CD_FUNDACAO=:CD_FUNDACAO AND CC_FICHA_FINANCEIRA.CD_PLANO=:CD_PLANO AND CC_FICHA_FINANCEIRA.NUM_INSCRICAO=:NUM_INSCRICAO AND CC_FICHA_FINANCEIRA.SRC>0 AND CC_FICHA_FINANCEIRA.ANO_REF=(SELECT MAX(FF1.ANO_REF) FROM CC_FICHA_FINANCEIRA  FF1  WHERE FF1.CD_FUNDACAO=:CD_FUNDACAO AND FF1.CD_PLANO=:CD_PLANO AND FF1.SRC>0 AND FF1.NUM_INSCRICAO=:NUM_INSCRICAO) AND CC_FICHA_FINANCEIRA.MES_REF=(SELECT MAX(FF1.MES_REF) FROM CC_FICHA_FINANCEIRA  FF1  WHERE FF1.CD_FUNDACAO=:CD_FUNDACAO AND FF1.CD_PLANO=:CD_PLANO AND FF1.NUM_INSCRICAO=:NUM_INSCRICAO AND FF1.SRC>0 AND FF1.ANO_REF=CC_FICHA_FINANCEIRA.ANO_REF) ORDER BY CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
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
