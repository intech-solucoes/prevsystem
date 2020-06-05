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
    public abstract class FuncionarioDAO : BaseDAO<FuncionarioEntidade>
    {
        
		public virtual FuncionarioEntidade BuscarNomePorCdFundacaoCdEmpresaNumMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE.NOME_ENTID FROM CS_FUNCIONARIO FN 	INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID WHERE FN.CD_FUNDACAO = @CD_FUNDACAO     AND FN.CD_EMPRESA = @CD_EMPRESA   AND FN.NUM_MATRICULA = @NUM_MATRICULA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE.NOME_ENTID FROM CS_FUNCIONARIO  FN  INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID WHERE FN.CD_FUNDACAO=:CD_FUNDACAO AND FN.CD_EMPRESA=:CD_EMPRESA AND FN.NUM_MATRICULA=:NUM_MATRICULA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT  	EE_ENTIDADE.NOME_ENTID,       	TB_LOTACAO.DS_LOTACAO,  	TB_CARGO.DS_CARGO,  	CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   LEFT JOIN TB_LOTACAO ON TB_LOTACAO.CD_LOTACAO = CS_FUNCIONARIO.CD_LOTACAO                      AND TB_LOTACAO.CD_EMPRESA = CS_FUNCIONARIO.CD_EMPRESA  LEFT JOIN TB_CARGO ON TB_CARGO.CD_CARGO = CS_FUNCIONARIO.CD_CARGO                    AND TB_CARGO.CD_EMPRESA = CS_FUNCIONARIO.CD_EMPRESA  WHERE CS_FUNCIONARIO.COD_ENTID = @COD_ENTID  ORDER BY CS_FUNCIONARIO.DT_ADMISSAO DESC", new { COD_ENTID });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, TB_LOTACAO.DS_LOTACAO, TB_CARGO.DS_CARGO, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID LEFT JOIN TB_LOTACAO  ON TB_LOTACAO.CD_LOTACAO=CS_FUNCIONARIO.CD_LOTACAO AND TB_LOTACAO.CD_EMPRESA=CS_FUNCIONARIO.CD_EMPRESA LEFT JOIN TB_CARGO  ON TB_CARGO.CD_CARGO=CS_FUNCIONARIO.CD_CARGO AND TB_CARGO.CD_EMPRESA=CS_FUNCIONARIO.CD_EMPRESA WHERE CS_FUNCIONARIO.COD_ENTID=:COD_ENTID ORDER BY CS_FUNCIONARIO.DT_ADMISSAO DESC", new { COD_ENTID });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID,      CS_PLANOS_VINC.CD_SIT_PLANO,      CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   INNER JOIN CS_PLANOS_VINC ON CS_PLANOS_VINC.CD_FUNDACAO = CS_FUNCIONARIO.CD_FUNDACAO                           AND CS_PLANOS_VINC.NUM_INSCRICAO = CS_FUNCIONARIO.NUM_INSCRICAO  INNER JOIN TB_SIT_PLANO ON TB_SIT_PLANO.CD_SIT_PLANO = CS_PLANOS_VINC.CD_SIT_PLANO  WHERE EE_ENTIDADE.CPF_CGC = @CPF   ORDER BY DT_ADMISSAO DESC", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_PLANOS_VINC.CD_SIT_PLANO, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID INNER  JOIN CS_PLANOS_VINC  ON CS_PLANOS_VINC.CD_FUNDACAO=CS_FUNCIONARIO.CD_FUNDACAO AND CS_PLANOS_VINC.NUM_INSCRICAO=CS_FUNCIONARIO.NUM_INSCRICAO INNER  JOIN TB_SIT_PLANO  ON TB_SIT_PLANO.CD_SIT_PLANO=CS_PLANOS_VINC.CD_SIT_PLANO WHERE EE_ENTIDADE.CPF_CGC=:CPF ORDER BY DT_ADMISSAO DESC", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioEntidade BuscarPorInscricao(string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT        	EE_ENTIDADE.NOME_ENTID,       	CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   WHERE CS_FUNCIONARIO.NUM_INSCRICAO = @NUM_INSCRICAO", new { NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.NUM_INSCRICAO=:NUM_INSCRICAO", new { NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioEntidade BuscarPorMatricula(string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT        	EE_ENTIDADE.NOME_ENTID,       	CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   WHERE CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA", new { NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA", new { NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioEntidade BuscarPorMatriculaEmpresa(string NUM_MATRICULA, string CD_EMPRESA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT        	EE_ENTIDADE.NOME_ENTID,       	CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   WHERE CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA  AND CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA", new { NUM_MATRICULA, CD_EMPRESA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA AND CS_FUNCIONARIO.CD_EMPRESA=:CD_EMPRESA", new { NUM_MATRICULA, CD_EMPRESA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarPorPesquisa(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_SIT_PLANO, string NUM_MATRICULA, string NOME)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT DISTINCT *  FROM   VW_FUNC_PLANO_DADOS  WHERE (CD_FUNDACAO = @CD_FUNDACAO OR @CD_FUNDACAO IS NULL)    AND (CD_EMPRESA = @CD_EMPRESA OR @CD_EMPRESA IS NULL)    AND (CD_PLANO = @CD_PLANO OR @CD_PLANO IS NULL)    AND (CD_SIT_PLANO = @CD_SIT_PLANO OR @CD_SIT_PLANO IS NULL)    AND (NUM_MATRICULA LIKE '%' + @NUM_MATRICULA + '%' OR @NUM_MATRICULA IS NULL)     AND (NOME_ENTID LIKE '%' + @NOME + '%' OR @NOME IS NULL)", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, NUM_MATRICULA, NOME });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT DISTINCT * FROM VW_FUNC_PLANO_DADOS WHERE (CD_FUNDACAO=:CD_FUNDACAO OR :CD_FUNDACAO IS NULL ) AND (CD_EMPRESA=:CD_EMPRESA OR :CD_EMPRESA IS NULL ) AND (CD_PLANO=:CD_PLANO OR :CD_PLANO IS NULL ) AND (CD_SIT_PLANO=:CD_SIT_PLANO OR :CD_SIT_PLANO IS NULL ) AND (NUM_MATRICULA LIKE '%' || :NUM_MATRICULA || '%' OR :NUM_MATRICULA IS NULL ) AND (NOME_ENTID LIKE '%' || :NOME || '%' OR :NOME IS NULL )", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, NUM_MATRICULA, NOME });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarPorPesquisaNotDesligado(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_SIT_PLANO, string NUM_MATRICULA, string NOME)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT DISTINCT *  FROM   VW_FUNC_PLANO_DADOS  WHERE (CD_FUNDACAO = @CD_FUNDACAO OR @CD_FUNDACAO IS NULL)    AND (CD_EMPRESA = @CD_EMPRESA OR @CD_EMPRESA IS NULL)    AND (CD_PLANO = @CD_PLANO OR @CD_PLANO IS NULL)    AND (CD_SIT_PLANO = @CD_SIT_PLANO OR @CD_SIT_PLANO IS NULL)    AND (NUM_MATRICULA LIKE '%' + @NUM_MATRICULA + '%' OR @NUM_MATRICULA IS NULL)     AND (NOME_ENTID LIKE '%' + @NOME + '%' OR @NOME IS NULL)    AND (CD_SIT_PLANO NOT IN ('21', '31', '26'))", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, NUM_MATRICULA, NOME });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, NUM_MATRICULA, NOME });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarPrimeiroPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID,      CS_FUNCIONARIO.*   FROM CS_FUNCIONARIO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID   INNER JOIN CS_PLANOS_VINC ON CS_PLANOS_VINC.CD_FUNDACAO = CS_FUNCIONARIO.CD_FUNDACAO                           AND CS_PLANOS_VINC.NUM_INSCRICAO = CS_FUNCIONARIO.NUM_INSCRICAO  INNER JOIN TB_SIT_PLANO ON TB_SIT_PLANO.CD_SIT_PLANO = CS_PLANOS_VINC.CD_SIT_PLANO  WHERE EE_ENTIDADE.CPF_CGC = @CPF   ORDER BY DT_ADMISSAO DESC", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID INNER  JOIN CS_PLANOS_VINC  ON CS_PLANOS_VINC.CD_FUNDACAO=CS_FUNCIONARIO.CD_FUNDACAO AND CS_PLANOS_VINC.NUM_INSCRICAO=CS_FUNCIONARIO.NUM_INSCRICAO INNER  JOIN TB_SIT_PLANO  ON TB_SIT_PLANO.CD_SIT_PLANO=CS_PLANOS_VINC.CD_SIT_PLANO WHERE EE_ENTIDADE.CPF_CGC=:CPF ORDER BY DT_ADMISSAO DESC", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarTodos()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
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
