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
    public abstract class UsuarioGrupoDAO : BaseDAO<UsuarioGrupoEntidade>
    {
        
		public virtual void DeletarPorOidGrupoUsuario(decimal OID_GRUPO_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_USUARIO_GRUPO  WHERE (OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_USUARIO_GRUPO WHERE (OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO });
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
