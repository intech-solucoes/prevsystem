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
    public abstract class TaxaEvolPerfilDAO : BaseDAO<TaxaEvolPerfilEntidade>
    {
        
		public virtual IEnumerable<TaxaEvolPerfilEntidade> BuscarPorFundacaoPerfil(string CD_FUNDACAO, decimal CD_PERFIL_INVEST)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TaxaEvolPerfilEntidade>("SELECT * FROM CS_TAXA_EVOL_PERFIL  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_PERFIL_INVEST = @CD_PERFIL_INVEST", new { CD_FUNDACAO, CD_PERFIL_INVEST });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TaxaEvolPerfilEntidade>("SELECT * FROM CS_TAXA_EVOL_PERFIL WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PERFIL_INVEST=:CD_PERFIL_INVEST", new { CD_FUNDACAO, CD_PERFIL_INVEST });
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
