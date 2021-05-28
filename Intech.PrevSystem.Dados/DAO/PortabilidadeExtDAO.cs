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
	public abstract class PortabilidadeExtDAO : BaseDAO<PortabilidadeExtEntidade>
	{
		public PortabilidadeExtDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<PortabilidadeExtEntidade> BuscarPorFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PortabilidadeExtEntidade>("SELECT * FROM   CC_PORTABILIDADE_EXT WHERE  CD_FUNDACAO = @CD_FUNDACAO        AND NUM_INSCRICAO = @NUM_INSCRICAO        AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PortabilidadeExtEntidade>("SELECT * FROM CC_PORTABILIDADE_EXT WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }, Transaction).ToList();
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