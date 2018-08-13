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
    public abstract class FuncionarioDAO : BaseDAO<FuncionarioEntidade>
    {
        
		public virtual FuncionarioEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT       	EE_ENTIDADE.NOME_ENTID,      	CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE CS_FUNCIONARIO.COD_ENTID = @COD_ENTID", new { COD_ENTID });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.COD_ENTID=:COD_ENTID", new { COD_ENTID });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID,     CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE EE_ENTIDADE.CPF_CGC = @CPF  ORDER BY DT_ADMISSAO DESC", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE EE_ENTIDADE.CPF_CGC=:CPF ORDER BY DT_ADMISSAO DESC", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual FuncionarioEntidade BuscarPorMatricula(string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT       	EE_ENTIDADE.NOME_ENTID,      	CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA", new { NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA", new { NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<FuncionarioEntidade> BuscarTodos()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
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
