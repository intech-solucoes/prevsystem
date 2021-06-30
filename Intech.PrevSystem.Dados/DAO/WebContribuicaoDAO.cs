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
	public abstract class WebContribuicaoDAO : BaseDAO<WebContribuicaoEntidade>
	{
		public WebContribuicaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<WebContribuicaoEntidade> BuscarPorFundacaoPlanoCodigo(string CD_FUNDACAO, string CD_PLANO, string COD_GRUPO_CONTRIBUICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebContribuicaoEntidade>("SELECT * FROM   WEB_CONTRIBUICAO WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_PLANO = @CD_PLANO )        AND ( COD_GRUPO_CONTRIBUICAO = @COD_GRUPO_CONTRIBUICAO )", new { CD_FUNDACAO, CD_PLANO, COD_GRUPO_CONTRIBUICAO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebContribuicaoEntidade>("SELECT * FROM WEB_CONTRIBUICAO WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_PLANO=:CD_PLANO) AND (COD_GRUPO_CONTRIBUICAO=:COD_GRUPO_CONTRIBUICAO)", new { CD_FUNDACAO, CD_PLANO, COD_GRUPO_CONTRIBUICAO }, Transaction).ToList();
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