using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class GrauParentescoDAO : BaseDAO<GrauParentescoEntidade>
	{
		public virtual GrauParentescoEntidade BuscarPorCodigo(string CD_GRAU_PARENTESCO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT *  FROM TB_GRAU_PARENTESCO  WHERE CD_GRAU_PARENTESCO = @CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<GrauParentescoEntidade>("SELECT * FROM TB_GRAU_PARENTESCO WHERE CD_GRAU_PARENTESCO=:CD_GRAU_PARENTESCO", new { CD_GRAU_PARENTESCO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<GrauParentescoEntidade> ObterTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT CD_GRAU_PARENTESCO, DS_GRAU_PARENTESCO  FROM TB_GRAU_PARENTESCO  ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrauParentescoEntidade>("SELECT CD_GRAU_PARENTESCO, DS_GRAU_PARENTESCO FROM TB_GRAU_PARENTESCO ORDER BY DS_GRAU_PARENTESCO", new {  }).ToList();
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
