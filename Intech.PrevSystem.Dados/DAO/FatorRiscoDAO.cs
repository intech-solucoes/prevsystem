using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FatorRiscoDAO : BaseDAO<FatorRiscoEntidade>
	{
		public virtual FatorRiscoEntidade BuscarPorFundacaoPlano(string CD_FUNDACAO, string CD_PLANO, int IDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatorRiscoEntidade>("SELECT TOP 1 *  FROM WEB_FATOR_RISCO  WHERE CD_FUNDACAO = @CD_FUNDACAO  	AND CD_PLANO = @CD_PLANO  	AND @IDADE BETWEEN NUM_FAIXA_INI AND NUM_FAIXA_FIM", new { CD_FUNDACAO, CD_PLANO, IDADE });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FatorRiscoEntidade>("SELECT * FROM WEB_FATOR_RISCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND :IDADE BETWEEN NUM_FAIXA_INI AND NUM_FAIXA_FIM AND ROWNUM <= 1 ", new { CD_FUNDACAO, CD_PLANO, IDADE });
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
