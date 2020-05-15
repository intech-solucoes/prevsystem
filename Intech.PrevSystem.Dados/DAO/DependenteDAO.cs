using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DependenteDAO : BaseDAO<DependenteEntidade>
	{
		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_PLANO = @CD_PLANO  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricaoSeqDep(string CD_FUNDACAO, string NUM_INSCRICAO, string NUM_SEQ_DEP)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND NUM_SEQ_DEP = @NUM_SEQ_DEP  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_DEP=:NUM_SEQ_DEP ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP }).ToList();
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
