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
    public abstract class EmpresaPlanosDAO : BaseDAO<EmpresaPlanosEntidade>
    {
		public virtual EmpresaPlanosEntidade BuscarPorFundacaoEmpresaPlano(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<EmpresaPlanosEntidade>("SELECT *  FROM TB_EMPRESA_PLANOS WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_EMPRESA = @CD_EMPRESA   AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<EmpresaPlanosEntidade>("SELECT * FROM TB_EMPRESA_PLANOS WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
