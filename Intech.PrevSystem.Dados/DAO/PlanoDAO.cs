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
        
		public virtual IEnumerable<PlanoEntidade> BuscarPorEmpresa(string CD_EMPRESA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<PlanoEntidade>("SELECT  	ENT_EMP.NOME_ENTID AS NOME_EMPRESA, 	TB_EMPRESA_PLANOS.CD_EMPRESA, 	TB_EMPRESA_PLANOS.CD_PLANO, 	TB_PLANOS.DS_PLANO FROM TB_EMPRESA EMP INNER JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_EMPRESA = EMP.CD_EMPRESA INNER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = TB_EMPRESA_PLANOS.CD_PLANO WHERE EMP.CD_EMPRESA = @CD_EMPRESA", new { CD_EMPRESA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<PlanoEntidade>("SELECT ENT_EMP.NOME_ENTID AS NOME_EMPRESA, TB_EMPRESA_PLANOS.CD_EMPRESA, TB_EMPRESA_PLANOS.CD_PLANO, TB_PLANOS.DS_PLANO FROM TB_EMPRESA  EMP  INNER  JOIN EE_ENTIDADE   ENT_EMP  ON ENT_EMP.COD_ENTID=EMP.COD_ENTID INNER  JOIN TB_EMPRESA_PLANOS  ON TB_EMPRESA_PLANOS.CD_EMPRESA=EMP.CD_EMPRESA INNER  JOIN TB_PLANOS  ON TB_PLANOS.CD_PLANO=TB_EMPRESA_PLANOS.CD_PLANO WHERE EMP.CD_EMPRESA=:CD_EMPRESA", new { CD_EMPRESA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<PlanoEntidade> BuscarTodos()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<PlanoEntidade>("SELECT * FROM TB_PLANOS", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<PlanoEntidade>("SELECT * FROM TB_PLANOS", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
