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
    public abstract class GrauParentescoDAO : BaseDAO<GrauParentescoEntidade>
    {
        
		public virtual IEnumerable<GrauParentescoEntidade> BuscarOrderAlfabetica()
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT *   FROM TB_GRAU_PARENTESCO  ORDER BY DS_GRAU_PARENTESCO", new {  });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO ORDER BY DS_GRAU_PARENTESCO", new {  });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual GrauParentescoEntidade BuscarPorCodigo(string CD_GRAU_PARENTESCO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT *   FROM TB_GRAU_PARENTESCO  WHERE CD_GRAU_PARENTESCO = @CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO WHERE CD_GRAU_PARENTESCO=:CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<GrauParentescoEntidade> BuscarPorCodigosOrderAlfabetica(string LISTA_CD_GRAU_PARENTESCO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT *   FROM TB_GRAU_PARENTESCO  WHERE CD_GRAU_PARENTESCO IN (@LISTA_CD_GRAU_PARENTESCO)  ORDER BY DS_GRAU_PARENTESCO", new { LISTA_CD_GRAU_PARENTESCO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO WHERE CD_GRAU_PARENTESCO IN (:LISTA_CD_GRAU_PARENTESCO) ORDER BY DS_GRAU_PARENTESCO", new { LISTA_CD_GRAU_PARENTESCO });
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
