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
	public abstract class RubricaDescontoDAO : BaseDAO<RubricaDescontoEntidade>
	{
		public RubricaDescontoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<RubricaDescontoEntidade> BuscarPorFundacaoEmpresaModalidadeNatureza(string CD_FUNDACAO, string CD_EMPRESA, decimal CD_MODAL, decimal CD_NATUR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricaDescontoEntidade>("SELECT * FROM   CE_RUBRICA_DESCONTO WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_EMPRESA = @CD_EMPRESA )        AND ( CD_MODAL = @CD_MODAL )        AND ( CD_NATUR = @CD_NATUR ) ORDER  BY SEQ_RUBRICA", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricaDescontoEntidade>("SELECT * FROM CE_RUBRICA_DESCONTO WHERE (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_EMPRESA=:CD_EMPRESA) AND (CD_MODAL=:CD_MODAL) AND (CD_NATUR=:CD_NATUR) ORDER BY SEQ_RUBRICA", new { CD_FUNDACAO, CD_EMPRESA, CD_MODAL, CD_NATUR }, Transaction).ToList();
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