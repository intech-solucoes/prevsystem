#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class FundoContribDAO : BaseDAO<FundoContribEntidade>
    {
        
		public virtual IEnumerable<FundoContribEntidade> BuscarPorFundacaoPlanoFundo(string CD_FUNDACAO, string CD_PLANO, string CD_FUNDO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FundoContribEntidade>("SELECT * FROM TB_FUNDO_CONTRIB WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND CD_FUNDO = @CD_FUNDO", new { CD_FUNDACAO, CD_PLANO, CD_FUNDO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FundoContribEntidade>("SELECT * FROM TB_FUNDO_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_FUNDO=:CD_FUNDO", new { CD_FUNDACAO, CD_PLANO, CD_FUNDO });
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
