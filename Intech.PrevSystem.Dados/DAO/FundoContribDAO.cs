using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FundoContribDAO : BaseDAO<FundoContribEntidade>
	{
		public virtual List<FundoContribEntidade> BuscarPorFundacaoPlanoFundo(string CD_FUNDACAO, string CD_PLANO, string CD_FUNDO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FundoContribEntidade>("SELECT *  FROM TB_FUNDO_CONTRIB  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_PLANO = @CD_PLANO    AND CD_FUNDO = @CD_FUNDO", new { CD_FUNDACAO, CD_PLANO, CD_FUNDO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FundoContribEntidade>("SELECT * FROM TB_FUNDO_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_FUNDO=:CD_FUNDO", new { CD_FUNDACAO, CD_PLANO, CD_FUNDO }).ToList();
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
