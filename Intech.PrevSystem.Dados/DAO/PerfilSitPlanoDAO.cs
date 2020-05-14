using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class PerfilSitPlanoDAO : BaseDAO<PerfilSitPlanoEntidade>
	{
		public virtual List<PerfilSitPlanoEntidade> BuscarPorFundacaoSitPlano(string CD_FUNDACAO, string CD_SIT_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PerfilSitPlanoEntidade>("SELECT *  FROM TB_PERFIL_SIT_PLANO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_SIT_PLANO = @CD_SIT_PLANO", new { CD_FUNDACAO, CD_SIT_PLANO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PerfilSitPlanoEntidade>("SELECT * FROM TB_PERFIL_SIT_PLANO WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_SIT_PLANO=:CD_SIT_PLANO", new { CD_FUNDACAO, CD_SIT_PLANO }).ToList();
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
