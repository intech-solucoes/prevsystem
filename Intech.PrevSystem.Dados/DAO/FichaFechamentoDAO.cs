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
    public abstract class FichaFechamentoDAO : BaseDAO<FichaFechamentoEntidade>
    {
        
		public virtual IEnumerable<FichaFechamentoEntidade> BuscarPorFundacaoEmpresaPlanoInscricao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO FF  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO  FF  WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FichaFechamentoEntidade> BuscarRelatorioPorFundacaoEmpresaPlanoInscricaoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string DT_INICIO, string DT_FIM)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT FF.*,  	LO.DS_LOTACAO  FROM CC_FICHA_FECHAMENTO FF  INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO  INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO  						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND ('' + FF.ANO_REF + FF.MES_REF BETWEEN @DT_INICIO AND @DT_FIM)  ORDER BY FF.CD_FUNDACAO,           FF.CD_EMPRESA,           FF.NUM_INSCRICAO,           FF.ANO_REF,           FF.MES_REF", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FichaFechamentoEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND ('' || FF.ANO_REF || FF.MES_REF BETWEEN :DT_INICIO AND :DT_FIM) ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM });
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
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO FF  WHERE FF.CD_FUNDACAO = @CD_FUNDACAO    AND FF.CD_EMPRESA = @CD_EMPRESA    AND FF.CD_PLANO = @CD_PLANO    AND FF.NUM_INSCRICAO = @NUM_INSCRICAO    AND FF.DT_FECHAMENTO = (SELECT MAX(DT_FECHAMENTO) 							FROM CC_FICHA_FECHAMENTO FF  							WHERE FF.CD_FUNDACAO = @CD_FUNDACAO  								AND FF.CD_EMPRESA = @CD_EMPRESA  								AND FF.CD_PLANO = @CD_PLANO  								AND FF.NUM_INSCRICAO = @NUM_INSCRICAO)  ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FichaFechamentoEntidade>("SELECT * FROM CC_FICHA_FECHAMENTO  FF  WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND FF.DT_FECHAMENTO=(SELECT MAX(DT_FECHAMENTO) FROM CC_FICHA_FECHAMENTO  FF  WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO) ORDER BY FF.DT_FECHAMENTO DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO });
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
