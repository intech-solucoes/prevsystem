using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class GrupoUsuarioDAO : BaseDAO<GrupoUsuarioEntidade>
	{
		public virtual List<GrupoUsuarioEntidade> BuscarPorIndAtivo(string @IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT * FROM WEB_GRUPO_USUARIO  WHERE IND_ATIVO = @IND_ATIVO", new { @IND_ATIVO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT * FROM WEB_GRUPO_USUARIO WHERE IND_ATIVO=:IND_ATIVO", new { @IND_ATIVO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<GrupoUsuarioEntidade> Pesquisar(string NOM_GRUPO_USUARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT *  FROM WEB_GRUPO_USUARIO  WHERE (NOM_GRUPO_USUARIO LIKE '%' +@NOM_GRUPO_USUARIO + '%' OR @NOM_GRUPO_USUARIO IS NULL)  ORDER BY OID_GRUPO_USUARIO", new { NOM_GRUPO_USUARIO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT * FROM WEB_GRUPO_USUARIO WHERE (NOM_GRUPO_USUARIO LIKE '%' || :NOM_GRUPO_USUARIO || '%' OR :NOM_GRUPO_USUARIO IS NULL ) ORDER BY OID_GRUPO_USUARIO", new { NOM_GRUPO_USUARIO }).ToList();
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
