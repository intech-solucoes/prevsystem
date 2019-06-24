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
    public abstract class EmpresaDAO : BaseDAO<EmpresaEntidade>
    {
        
		public virtual EmpresaEntidade BuscarPorCodigo(string CD_EMPRESA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<EmpresaEntidade>("SELECT TB_EMPRESA.*,      EE_ENTIDADE.NOME_ENTID,      EE_ENTIDADE.CPF_CGC  FROM TB_EMPRESA  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = TB_EMPRESA.COD_ENTID  WHERE TB_EMPRESA.CD_EMPRESA = @CD_EMPRESA", new { CD_EMPRESA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<EmpresaEntidade>("SELECT TB_EMPRESA.*, EE_ENTIDADE.NOME_ENTID, EE_ENTIDADE.CPF_CGC FROM TB_EMPRESA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=TB_EMPRESA.COD_ENTID WHERE TB_EMPRESA.CD_EMPRESA=:CD_EMPRESA", new { CD_EMPRESA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<EmpresaEntidade> BuscarPorFundacao(string CD_FUNDACAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<EmpresaEntidade>("SELECT TB_EMPRESA.*,      EE_ENTIDADE.NOME_ENTID,      EE_ENTIDADE.CPF_CGC  FROM TB_EMPRESA  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = TB_EMPRESA.COD_ENTID  WHERE TB_EMPRESA.CD_FUNDACAO = @CD_FUNDACAO", new { CD_FUNDACAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<EmpresaEntidade>("SELECT TB_EMPRESA.*, EE_ENTIDADE.NOME_ENTID, EE_ENTIDADE.CPF_CGC FROM TB_EMPRESA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=TB_EMPRESA.COD_ENTID WHERE TB_EMPRESA.CD_FUNDACAO=:CD_FUNDACAO", new { CD_FUNDACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<EmpresaEntidade> BuscarTodas()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<EmpresaEntidade>("SELECT TB_EMPRESA.*,      EE_ENTIDADE.NOME_ENTID,      EE_ENTIDADE.CPF_CGC  FROM TB_EMPRESA  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = TB_EMPRESA.COD_ENTID", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<EmpresaEntidade>("SELECT TB_EMPRESA.*, EE_ENTIDADE.NOME_ENTID, EE_ENTIDADE.CPF_CGC FROM TB_EMPRESA INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=TB_EMPRESA.COD_ENTID", new {  });
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
