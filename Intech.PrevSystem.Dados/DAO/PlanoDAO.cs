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
	public abstract class PlanoDAO : BaseDAO<PlanoEntidade>
	{
		public PlanoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<PlanoEntidade> BuscarPlanoPorInscricao(string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT P.*     FROM GB_PROCESSOS_BENEFICIO PB 	    JOIN TB_PLANOS P ON PB.CD_PLANO = P.CD_PLANO 		    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { NUM_INSCRICAO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT P.* FROM GB_PROCESSOS_BENEFICIO  PB   JOIN TB_PLANOS   P  ON PB.CD_PLANO=P.CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { NUM_INSCRICAO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual PlanoEntidade BuscarPorCodigo(string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoEntidade>("SELECT * FROM TB_PLANOS WHERE CD_PLANO = @CD_PLANO", new { CD_PLANO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoEntidade>("SELECT * FROM TB_PLANOS WHERE CD_PLANO=:CD_PLANO", new { CD_PLANO }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PlanoEntidade> BuscarPorEmpresa(string CD_EMPRESA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT  	ENT_EMP.NOME_ENTID AS NOME_EMPRESA, 	TB_EMPRESA_PLANOS.CD_EMPRESA, 	TB_EMPRESA_PLANOS.CD_PLANO, 	TB_PLANOS.DS_PLANO FROM TB_EMPRESA EMP INNER JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_EMPRESA = EMP.CD_EMPRESA INNER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = TB_EMPRESA_PLANOS.CD_PLANO WHERE EMP.CD_EMPRESA = @CD_EMPRESA", new { CD_EMPRESA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT ENT_EMP.NOME_ENTID AS NOME_EMPRESA, TB_EMPRESA_PLANOS.CD_EMPRESA, TB_EMPRESA_PLANOS.CD_PLANO, TB_PLANOS.DS_PLANO FROM TB_EMPRESA  EMP  INNER  JOIN EE_ENTIDADE   ENT_EMP  ON ENT_EMP.COD_ENTID=EMP.COD_ENTID INNER  JOIN TB_EMPRESA_PLANOS  ON TB_EMPRESA_PLANOS.CD_EMPRESA=EMP.CD_EMPRESA INNER  JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=TB_EMPRESA_PLANOS.CD_PLANO WHERE EMP.CD_EMPRESA=:CD_EMPRESA", new { CD_EMPRESA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PlanoEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT * FROM TB_PLANOS", new {  }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT * FROM TB_PLANOS", new {  }, Transaction).ToList();
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