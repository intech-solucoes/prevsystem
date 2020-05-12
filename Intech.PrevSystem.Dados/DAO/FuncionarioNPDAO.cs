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
    public abstract class FuncionarioNPDAO : BaseDAO<FuncionarioNPEntidade>
    {
        
		public virtual FuncionarioNPEntidade BuscarPorFundacaoCpf(string CD_FUNDACAO, string CPF_CGC)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT *  FROM CS_FUNCIONARIO_NP  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CPF_CGC = @CPF_CGC", new { CD_FUNDACAO, CPF_CGC });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT * FROM CS_FUNCIONARIO_NP WHERE CD_FUNDACAO=:CD_FUNDACAO AND CPF_CGC=:CPF_CGC", new { CD_FUNDACAO, CPF_CGC });
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
