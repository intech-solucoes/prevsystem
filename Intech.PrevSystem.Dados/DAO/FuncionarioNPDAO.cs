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
	public abstract class FuncionarioNPDAO : BaseDAO<FuncionarioNPEntidade>
	{
		public FuncionarioNPDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<FuncionarioNPEntidade> BuscarPorCpf(string CPF_CGC)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioNPEntidade>("SELECT *  FROM CS_FUNCIONARIO_NP  WHERE CPF_CGC = @CPF_CGC", new { CPF_CGC }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioNPEntidade>("SELECT * FROM CS_FUNCIONARIO_NP WHERE CPF_CGC=:CPF_CGC", new { CPF_CGC }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

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
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<FuncionarioNPEntidade> BuscarPorMatricula(string NUM_MATRICULA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioNPEntidade>("SELECT *  FROM CS_FUNCIONARIO_NP  WHERE NUM_MATRICULA = @NUM_MATRICULA", new { NUM_MATRICULA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioNPEntidade>("SELECT * FROM CS_FUNCIONARIO_NP WHERE NUM_MATRICULA=:NUM_MATRICULA", new { NUM_MATRICULA }).ToList();
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
