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
    public abstract class PerfilSitPlanoDAO : BaseDAO<PerfilSitPlanoEntidade>
    {
        
		public virtual IEnumerable<PerfilSitPlanoEntidade> BuscarPorFundacaoSitPlano(string CD_FUNDACAO, string CD_SIT_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PerfilSitPlanoEntidade>("SELECT *  FROM TB_PERFIL_SIT_PLANO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_SIT_PLANO = @CD_SIT_PLANO", new { CD_FUNDACAO, CD_SIT_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PerfilSitPlanoEntidade>("SELECT * FROM TB_PERFIL_SIT_PLANO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_SIT_PLANO=:CD_SIT_PLANO", new { CD_FUNDACAO, CD_SIT_PLANO });
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
