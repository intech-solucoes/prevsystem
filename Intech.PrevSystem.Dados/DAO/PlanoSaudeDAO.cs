using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PlanoSaudeDAO : BaseDAO<PlanoSaudeEntidade>
	{
		public virtual List<PlanoSaudeEntidade> BuscarDatasPorMatricula(string NUM_MATRICULA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT DISTINCT ANO_CALENDARIO  FROM TB_DIRF_PSAUDE  WHERE NUM_MATRICULA = @NUM_MATRICULA  ORDER BY ANO_CALENDARIO DESC", new { NUM_MATRICULA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT DISTINCT ANO_CALENDARIO FROM TB_DIRF_PSAUDE WHERE NUM_MATRICULA=:NUM_MATRICULA ORDER BY ANO_CALENDARIO DESC", new { NUM_MATRICULA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<PlanoSaudeEntidade> BuscarPorMatricula(string NUM_MATRICULA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT *  FROM TB_DIRF_PSAUDE  WHERE NUM_MATRICULA = @NUM_MATRICULA  ORDER BY ANO_CALENDARIO DESC", new { NUM_MATRICULA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT * FROM TB_DIRF_PSAUDE WHERE NUM_MATRICULA=:NUM_MATRICULA ORDER BY ANO_CALENDARIO DESC", new { NUM_MATRICULA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<PlanoSaudeEntidade> BuscarPorMatriculaAnoCalendario(string NUM_MATRICULA, decimal ANO_CALENDARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT *  FROM TB_DIRF_PSAUDE  WHERE NUM_MATRICULA = @NUM_MATRICULA    AND ANO_CALENDARIO = @ANO_CALENDARIO", new { NUM_MATRICULA, ANO_CALENDARIO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoSaudeEntidade>("SELECT * FROM TB_DIRF_PSAUDE WHERE NUM_MATRICULA=:NUM_MATRICULA AND ANO_CALENDARIO=:ANO_CALENDARIO", new { NUM_MATRICULA, ANO_CALENDARIO }).ToList();
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
