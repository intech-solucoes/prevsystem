using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class GrupoNaturezaDAO : BaseDAO<GrupoNaturezaEntidade>
	{
		public virtual List<GrupoNaturezaEntidade> BuscarPorModalidade(string CD_MODAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrupoNaturezaEntidade>("SELECT *  FROM CE_GRUPO_NATUREZA  WHERE CD_MODAL = @CD_MODAL", new { CD_MODAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrupoNaturezaEntidade>("SELECT * FROM CE_GRUPO_NATUREZA WHERE CD_MODAL=:CD_MODAL", new { CD_MODAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<GrupoNaturezaEntidade> BuscarTodos()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrupoNaturezaEntidade>("SELECT *  FROM CE_GRUPO_NATUREZA", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrupoNaturezaEntidade>("SELECT * FROM CE_GRUPO_NATUREZA", new {  }).ToList();
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
