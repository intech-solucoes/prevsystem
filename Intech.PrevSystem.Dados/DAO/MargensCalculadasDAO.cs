using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class MargensCalculadasDAO : BaseDAO<MargensCalculadasEntidade>
	{
		public virtual MargensCalculadasEntidade BuscarPorFundacaoEmpresaOrigemMatriculaGrupo(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_ORIGEM, string NUM_MATRICULA, decimal NUM_SEQ_GR_FAMIL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensCalculadasEntidade>("SELECT TOP 1 *  FROM   VMP_MARGENS_CALCULADAS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND CD_ORIGEM = @CD_ORIGEM    AND NUM_MATRICULA = @NUM_MATRICULA    AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL  ORDER BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_ORIGEM, NUM_MATRICULA, NUM_SEQ_GR_FAMIL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<MargensCalculadasEntidade>("SELECT * FROM VMP_MARGENS_CALCULADAS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_ORIGEM=:CD_ORIGEM AND NUM_MATRICULA=:NUM_MATRICULA AND NUM_SEQ_GR_FAMIL=:NUM_SEQ_GR_FAMIL AND ROWNUM <= 1  ORDER BY DATA_REF DESC", new { CD_FUNDACAO, CD_EMPRESA, CD_ORIGEM, NUM_MATRICULA, NUM_SEQ_GR_FAMIL });
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
