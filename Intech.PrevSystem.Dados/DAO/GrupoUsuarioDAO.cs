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
    public abstract class GrupoUsuarioDAO : BaseDAO<GrupoUsuarioEntidade>
    {
        
		public virtual IEnumerable<GrupoUsuarioEntidade> Pesquisar(string NOM_GRUPO_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT *  FROM WEB_GRUPO_USUARIO  WHERE (NOM_GRUPO_USUARIO LIKE '%' +@NOM_GRUPO_USUARIO + '%' OR @NOM_GRUPO_USUARIO IS NULL)  ORDER BY OID_GRUPO_USUARIO", new { NOM_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<GrupoUsuarioEntidade>("SELECT * FROM WEB_GRUPO_USUARIO WHERE (NOM_GRUPO_USUARIO LIKE '%' || :NOM_GRUPO_USUARIO || '%' OR :NOM_GRUPO_USUARIO IS NULL ) ORDER BY OID_GRUPO_USUARIO", new { NOM_GRUPO_USUARIO });
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
