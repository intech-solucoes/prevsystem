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
    public abstract class PlanoDAO : BaseDAO<PlanoEntidade>
    {
        
		public virtual IEnumerable<PlanoEntidade> BuscarPlanoPorInscricao(string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT P.*      FROM GB_PROCESSOS_BENEFICIO PB  	    JOIN TB_PLANOS P ON PB.CD_PLANO = P.CD_PLANO  		    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT P.* FROM GB_PROCESSOS_BENEFICIO  PB   JOIN TB_PLANOS   P  ON PB.CD_PLANO=P.CD_PLANO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual PlanoEntidade BuscarPorCodigo(string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoEntidade>("SELECT *  FROM TB_PLANOS  WHERE CD_PLANO = @CD_PLANO", new { CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoEntidade>("SELECT * FROM TB_PLANOS WHERE CD_PLANO=:CD_PLANO", new { CD_PLANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoEntidade> BuscarPorEmpresa(string CD_EMPRESA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT   	ENT_EMP.NOME_ENTID AS NOME_EMPRESA,  	TB_EMPRESA_PLANOS.CD_EMPRESA,  	TB_EMPRESA_PLANOS.CD_PLANO,  	TB_PLANOS.DS_PLANO  FROM TB_EMPRESA EMP  INNER JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID  INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_EMPRESA = EMP.CD_EMPRESA  INNER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = TB_EMPRESA_PLANOS.CD_PLANO  WHERE EMP.CD_EMPRESA = @CD_EMPRESA", new { CD_EMPRESA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT ENT_EMP.NOME_ENTID AS NOME_EMPRESA, TB_EMPRESA_PLANOS.CD_EMPRESA, TB_EMPRESA_PLANOS.CD_PLANO, TB_PLANOS.DS_PLANO FROM TB_EMPRESA  EMP  INNER  JOIN EE_ENTIDADE   ENT_EMP  ON ENT_EMP.COD_ENTID=EMP.COD_ENTID INNER  JOIN TB_EMPRESA_PLANOS  ON TB_EMPRESA_PLANOS.CD_EMPRESA=EMP.CD_EMPRESA INNER  JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=TB_EMPRESA_PLANOS.CD_PLANO WHERE EMP.CD_EMPRESA=:CD_EMPRESA", new { CD_EMPRESA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoEntidade> BuscarTodos()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT *  FROM TB_PLANOS", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT * FROM TB_PLANOS", new {  });
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
