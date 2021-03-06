﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FichaFechamentoPrevesDAO : BaseDAO<FichaFechamentoPrevesEntidade>
	{
		public FichaFechamentoPrevesDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FichaFechamentoPrevesEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoTipo(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string TIPO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO_PREVES FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.IND_ANALITICO_SINTETICO = @TIPO  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF,           FF.ANO_COMP,           FF.MES_COMP,           FF.NUM_SEQ,           FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.IND_ANALITICO_SINTETICO=:TIPO ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF, FF.ANO_COMP, FF.MES_COMP, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoPrevesEntidade> BuscarRelatorioPorFundacaoEmpresaPlanoInscricaoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string DT_INICIO, string DT_FIM)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO_PREVES FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND ('' + FF.ANO_REF + FF.MES_REF BETWEEN @DT_INICIO AND @DT_FIM)    AND FF.IND_ANALITICO_SINTETICO = 'S'  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF,           FF.ANO_COMP,           FF.MES_COMP,           FF.NUM_SEQ,           FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND ('' || FF.ANO_REF || FF.MES_REF BETWEEN :DT_INICIO AND :DT_FIM) AND FF.IND_ANALITICO_SINTETICO='S' ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF, FF.ANO_COMP, FF.MES_COMP, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoPrevesEntidade> BuscarResumoAnosPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO_PREVES FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.IND_ANALITICO_SINTETICO = 'S'  ORDER BY FF.ANO_REF,           FF.ANO_COMP", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.IND_ANALITICO_SINTETICO='S' ORDER BY FF.ANO_REF, FF.ANO_COMP", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoPrevesEntidade> BuscarResumoDetalhesPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string ANO, string MES, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO_PREVES FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND ('' + FF.ANO_REF + FF.MES_REF = '' + @ANO + @MES)    AND FF.IND_ANALITICO_SINTETICO = 'S'  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF,           FF.ANO_COMP,           FF.MES_COMP,           FF.NUM_SEQ,           FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO, MES, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND ('' || FF.ANO_REF || FF.MES_REF='' || :ANO || :MES) AND FF.IND_ANALITICO_SINTETICO='S' ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF, FF.ANO_COMP, FF.MES_COMP, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO, MES, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FichaFechamentoPrevesEntidade> BuscarResumoMesesPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string ANO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO_PREVES FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.ANO_REF = @ANO    AND FF.IND_ANALITICO_SINTETICO = 'S'  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF,           FF.ANO_COMP,           FF.MES_COMP,           FF.NUM_SEQ,           FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.ANO_REF=:ANO AND FF.IND_ANALITICO_SINTETICO='S' ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF, FF.ANO_COMP, FF.MES_COMP, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, ANO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual decimal BuscarTotalAposentadoriaComplementar(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string TIPO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<decimal>("SELECT SUM(FF.VL_LIQUIDO)  FROM   CC_FICHA_FECHAMENTO_PREVES FF          INNER JOIN CS_FUNCIONARIO FUNC                  ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO          INNER JOIN TB_LOTACAO LO                  ON LO.CD_LOTACAO = FUNC.CD_LOTACAO                     AND LO.CD_EMPRESA = FUNC.CD_EMPRESA   WHERE  FF.CD_FUNDACAO = @CD_FUNDACAO         AND FF.CD_EMPRESA = @CD_EMPRESA         AND FF.CD_PLANO = @CD_PLANO         AND FF.NUM_INSCRICAO = @NUM_INSCRICAO         AND FF.IND_ANALITICO_SINTETICO = @TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<decimal>("SELECT SUM(FF.VL_LIQUIDO) FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.IND_ANALITICO_SINTETICO=:TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual FichaFechamentoPrevesEntidade BuscarUltimaPorFundacaoEmpresaPlanoInscricaoTipoPartic(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string TIPO, string IND_PARTIC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoPrevesEntidade>("SELECT TOP 1 FF.*,                LO.DS_LOTACAO   FROM   CC_FICHA_FECHAMENTO_PREVES FF          INNER JOIN CS_FUNCIONARIO FUNC                  ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO          INNER JOIN TB_LOTACAO LO                  ON LO.CD_LOTACAO = FUNC.CD_LOTACAO                     AND LO.CD_EMPRESA = FUNC.CD_EMPRESA   WHERE  FF.CD_FUNDACAO = @CD_FUNDACAO         AND FF.CD_EMPRESA = @CD_EMPRESA         AND FF.CD_PLANO = @CD_PLANO         AND FF.NUM_INSCRICAO = @NUM_INSCRICAO         AND FF.IND_ANALITICO_SINTETICO = @TIPO         AND IND_PARTIC = @IND_PARTIC  	   AND IND_TIPO = 'CN'  ORDER  BY FF.CD_FUNDACAO,             FF.CD_EMPRESA,             FF.NUM_INSCRICAO,             FF.ANO_REF DESC,             FF.MES_REF DESC,             FF.ANO_COMP DESC,             FF.MES_COMP DESC,             FF.NUM_SEQ,             FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO, IND_PARTIC });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.IND_ANALITICO_SINTETICO=:TIPO AND IND_PARTIC=:IND_PARTIC AND IND_TIPO='CN' AND ROWNUM <= 1  ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF DESC, FF.MES_REF DESC, FF.ANO_COMP DESC, FF.MES_COMP DESC, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO, IND_PARTIC });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual FichaFechamentoPrevesEntidade BuscarValoresPortados(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string TIPO, string IND_PARTIC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoPrevesEntidade>("SELECT TOP 1 FF.*,                LO.DS_LOTACAO   FROM   CC_FICHA_FECHAMENTO_PREVES FF          INNER JOIN CS_FUNCIONARIO FUNC                  ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO          INNER JOIN TB_LOTACAO LO                  ON LO.CD_LOTACAO = FUNC.CD_LOTACAO                     AND LO.CD_EMPRESA = FUNC.CD_EMPRESA   WHERE  FF.CD_FUNDACAO = @CD_FUNDACAO         AND FF.CD_EMPRESA = @CD_EMPRESA         AND FF.CD_PLANO = @CD_PLANO         AND FF.NUM_INSCRICAO = @NUM_INSCRICAO         AND FF.IND_ANALITICO_SINTETICO = @TIPO         AND IND_PARTIC = @IND_PARTIC  	   AND IND_TIPO = 'PE'  ORDER  BY FF.CD_FUNDACAO,             FF.CD_EMPRESA,             FF.NUM_INSCRICAO,             FF.ANO_REF DESC,             FF.MES_REF DESC,             FF.ANO_COMP DESC,             FF.MES_COMP DESC,             FF.NUM_SEQ,             FF.IND_TIPO;", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO, IND_PARTIC });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.IND_ANALITICO_SINTETICO=:TIPO AND IND_PARTIC=:IND_PARTIC AND IND_TIPO='PE' AND ROWNUM <= 1  ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF DESC, FF.MES_REF DESC, FF.ANO_COMP DESC, FF.MES_COMP DESC, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, TIPO, IND_PARTIC });
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
