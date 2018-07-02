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
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT       	EE_ENTIDADE.NOME_ENTID,      	CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE CS_FUNCIONARIO.COD_ENTID = @COD_ENTID", new { COD_ENTID });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.COD_ENTID=:COD_ENTID", new { COD_ENTID });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual FuncionarioEntidade BuscarPorCpf(string CPF)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT TOP 1  EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE EE_ENTIDADE.CPF_CGC = @CPF", new { CPF });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE EE_ENTIDADE.CPF_CGC=:CPF AND ROWNUM <= 1 ", new { CPF });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual FuncionarioEntidade BuscarPorMatricula(string NUM_MATRICULA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT       	EE_ENTIDADE.NOME_ENTID,      	CS_FUNCIONARIO.*  FROM CS_FUNCIONARIO  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  WHERE CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA", new { NUM_MATRICULA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<FuncionarioEntidade>("SELECT EE_ENTIDADE.NOME_ENTID, CS_FUNCIONARIO.* FROM CS_FUNCIONARIO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID WHERE CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA", new { NUM_MATRICULA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<FuncionarioEntidade> BuscarTodos()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FuncionarioEntidade>("SELECT * FROM CS_FUNCIONARIO", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
