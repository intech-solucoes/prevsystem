using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PercContribuicaoDAO : BaseDAO<PercContribuicaoEntidade>
	{
		public virtual PercContribuicaoEntidade BuscarPorFundacaoPlanoTipoContribuicao(string CD_FUNDACAO, string CD_PLANO, string CD_TIPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PercContribuicaoEntidade>("SELECT *  FROM WEB_PERC_CONTRIBUICAO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_PLANO = @CD_PLANO    AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PercContribuicaoEntidade>("SELECT * FROM WEB_PERC_CONTRIBUICAO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO });
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
