using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class MargensCalculadasDAO : BaseDAO<MargensCalculadasEntidade>
	{
		public MargensCalculadasDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual void ApagarUltima(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, decimal NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM CE_MARGENS_CALCULADAS  WHERE DATA_REF = (SELECT MAX(DATA_REF)                      FROM CE_MARGENS_CALCULADAS                     WHERE ( CD_FUNDACAO = @CD_FUNDACAO )                      AND ( CD_EMPRESA = @CD_EMPRESA )                      AND ( NUM_MATRICULA = @NUM_MATRICULA )                      AND ( NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL ))", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM CE_MARGENS_CALCULADAS WHERE DATA_REF=(SELECT MAX(DATA_REF) FROM CE_MARGENS_CALCULADAS WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (NUM_MATRICULA=:NUM_MATRICULA) AND (NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL))", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual MargensCalculadasEntidade BuscarPorFundacaoEmpresaOrigemMatriculaGrupo(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_ORIGEM, string NUM_MATRICULA, decimal NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensCalculadasEntidade>("SELECT TOP 1 * FROM   VMP_MARGENS_CALCULADAS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_ORIGEM = @CD_ORIGEM   AND NUM_MATRICULA = @NUM_MATRICULA   AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL ORDER BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_ORIGEM, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensCalculadasEntidade>("SELECT * FROM VMP_MARGENS_CALCULADAS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_ORIGEM=:CD_ORIGEM AND NUM_MATRICULA=:NUM_MATRICULA AND NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL AND ROWNUM <= 1  ORDER BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_ORIGEM, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<MargensCalculadasEntidade> BuscarUltimasSeis(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, decimal NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<MargensCalculadasEntidade>("SELECT TOP 6 CE_MARGENS_CALCULADAS.* FROM   CE_MARGENS_CALCULADAS WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_EMPRESA = @CD_EMPRESA )        AND ( NUM_MATRICULA = @NUM_MATRICULA )        AND ( NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL ) ORDER  BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<MargensCalculadasEntidade>("SELECT CE_MARGENS_CALCULADAS.* FROM CE_MARGENS_CALCULADAS WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (NUM_MATRICULA=:NUM_MATRICULA) AND (NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL) AND ROWNUM <= 6  ORDER BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, NUM_SEQ_GR_FAMIL }, Transaction).ToList();
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