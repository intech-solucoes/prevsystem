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
