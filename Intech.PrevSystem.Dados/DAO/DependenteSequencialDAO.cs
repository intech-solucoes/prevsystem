using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DependenteSequencialDAO : BaseDAO<DependenteSequencialEntidade>
	{
		public virtual DependenteSequencialEntidade ObterUltimoSequencial(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DependenteSequencialEntidade>("SELECT MAX(NUM_SEQ_DEP) AS NUM_SEQ_DEP   FROM CS_DEPENDENTE  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DependenteSequencialEntidade>("SELECT MAX(NUM_SEQ_DEP) AS NUM_SEQ_DEP FROM CS_DEPENDENTE WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
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
