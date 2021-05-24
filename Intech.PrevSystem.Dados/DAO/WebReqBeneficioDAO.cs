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
	public abstract class WebReqBeneficioDAO : BaseDAO<WebReqBeneficioEntidade>
	{
		public WebReqBeneficioDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual WebReqBeneficioEntidade BuscarPorFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebReqBeneficioEntidade>("SELECT  *  FROM WEB_REQ_BENEFICIO  WHERE CD_FUNDACAO = @CD_FUNDACAO  AND NUM_INSCRICAO = @NUM_INSCRICAO  AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebReqBeneficioEntidade>("SELECT * FROM WEB_REQ_BENEFICIO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
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
