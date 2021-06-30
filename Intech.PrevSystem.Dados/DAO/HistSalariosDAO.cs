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
	public abstract class HistSalariosDAO : BaseDAO<HistSalariosEntidade>
	{
		public HistSalariosDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<HistSalariosEntidade> BuscarPorInscricaoFundacaoPlanoPeriodo(string NUM_INSCRICAO, string CD_FUNDACAO, string CD_PLANO, DateTime DT_TERM_VALIDADE)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<HistSalariosEntidade>("SELECT * FROM   AM_HIST_SALARIOS WHERE  ( NUM_INSCRICAO = @NUM_INSCRICAO )        AND ( CD_FUNDACAO = @CD_FUNDACAO )        AND ( CD_PLANO = @CD_PLANO )        AND ( CD_TIPO_CONTRIBUICAO IN ( '14', '17' ) )        AND ( DT_TERM_VALIDADE <= @DT_TERM_VALIDADE OR DT_TERM_VALIDADE IS NULL )", new { NUM_INSCRICAO, CD_FUNDACAO, CD_PLANO, DT_TERM_VALIDADE }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<HistSalariosEntidade>("SELECT * FROM AM_HIST_SALARIOS WHERE (NUM_INSCRICAO=:NUM_INSCRICAO) AND (CD_FUNDACAO=:CD_FUNDACAO) AND (CD_PLANO=:CD_PLANO) AND (CD_TIPO_CONTRIBUICAO IN ('14', '17')) AND (DT_TERM_VALIDADE<=:DT_TERM_VALIDADE OR DT_TERM_VALIDADE IS NULL )", new { NUM_INSCRICAO, CD_FUNDACAO, CD_PLANO, DT_TERM_VALIDADE }, Transaction).ToList();
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