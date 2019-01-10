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
    public abstract class PerfilInvestIndiceDAO : BaseDAO<PerfilInvestIndiceEntidade>
    {
        
		public virtual PerfilInvestIndiceEntidade BuscarPorFundacaoEmpresaPlanoPerfilInvest(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_PERFIL_INVEST)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PerfilInvestIndiceEntidade>("SELECT * FROM TB_PERFIL_INVEST_INDICE WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_PLANO = @CD_PLANO   AND CD_PERFIL_INVEST = @CD_PERFIL_INVEST", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_PERFIL_INVEST });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PerfilInvestIndiceEntidade>("SELECT * FROM TB_PERFIL_INVEST_INDICE WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO AND CD_PERFIL_INVEST=:CD_PERFIL_INVEST", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_PERFIL_INVEST });
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
