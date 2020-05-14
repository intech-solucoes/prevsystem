using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FuncionarioNPDAO : BaseDAO<FuncionarioNPEntidade>
	{
		public virtual FuncionarioNPEntidade BuscarPorFundacaoCpf(string CD_FUNDACAO, string CPF_CGC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT *  FROM CS_FUNCIONARIO_NP  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CPF_CGC = @CPF_CGC", new { CD_FUNDACAO, CPF_CGC });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT * FROM CS_FUNCIONARIO_NP WHERE CD_FUNDACAO=:CD_FUNDACAO AND CPF_CGC=:CPF_CGC", new { CD_FUNDACAO, CPF_CGC });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioNPEntidade BuscarPorFundacaoEmpresaMatriculaCpfDataNascimento(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CPF_CGC, DateTime DT_NASCIMENTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT *  FROM CS_FUNCIONARIO_NP  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND CD_EMPRESA = @CD_EMPRESA    AND NUM_MATRICULA = @NUM_MATRICULA    AND CPF_CGC = @CPF_CGC    AND DT_NASCIMENTO = @DT_NASCIMENTO", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CPF_CGC, DT_NASCIMENTO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioNPEntidade>("SELECT * FROM CS_FUNCIONARIO_NP WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_EMPRESA=:CD_EMPRESA AND NUM_MATRICULA=:NUM_MATRICULA AND CPF_CGC=:CPF_CGC AND DT_NASCIMENTO=:DT_NASCIMENTO", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CPF_CGC, DT_NASCIMENTO });
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
