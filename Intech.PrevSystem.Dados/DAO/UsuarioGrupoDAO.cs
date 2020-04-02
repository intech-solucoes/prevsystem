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
        
		public virtual IEnumerable<UsuarioGrupoEntidade> BuscarFuncionarioPorOidUsuarioGrupo(decimal @OID_GRUPO_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT *  FROM   VW_FUNC_PLANO_DADOS FPD  JOIN WEB_USUARIO U ON FPD.CPF_CGC = U.NOM_LOGIN  JOIN WEB_USUARIO_GRUPO UG ON UG.OID_USUARIO = U.OID_USUARIO  WHERE UG.OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT * FROM VW_FUNC_PLANO_DADOS  FPD   JOIN WEB_USUARIO   U  ON FPD.CPF_CGC=U.NOM_LOGIN  JOIN WEB_USUARIO_GRUPO   UG  ON UG.OID_USUARIO=U.OID_USUARIO WHERE UG.OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<UsuarioGrupoEntidade> BuscarFuncionarioPorOidUsuarioGrupoDistinct(decimal @OID_GRUPO_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT    FPD.CPF_CGC, FPD.NOME_ENTID, UG.OID_USUARIO_GRUPO  FROM   VW_FUNC_PLANO_DADOS FPD  JOIN WEB_USUARIO U ON FPD.CPF_CGC = U.NOM_LOGIN  JOIN WEB_USUARIO_GRUPO UG ON UG.OID_USUARIO = U.OID_USUARIO  WHERE UG.OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT FPD.CPF_CGC, FPD.NOME_ENTID, UG.OID_USUARIO_GRUPO FROM VW_FUNC_PLANO_DADOS  FPD   JOIN WEB_USUARIO   U  ON FPD.CPF_CGC=U.NOM_LOGIN  JOIN WEB_USUARIO_GRUPO   UG  ON UG.OID_USUARIO=U.OID_USUARIO WHERE UG.OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<UsuarioGrupoEntidade> BuscarPorOidGrupoUsuario(decimal @OID_GRUPO_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT * FROM WEB_USUARIO_GRUPO  WHERE OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT * FROM WEB_USUARIO_GRUPO WHERE OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO", new { @OID_GRUPO_USUARIO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<UsuarioGrupoEntidade> BuscarPorOidGrupoUsuarioOidUsuario(decimal OID_GRUPO_USUARIO, decimal OID_USUARIO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT * FROM WEB_USUARIO_GRUPO  WHERE OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO AND OID_USUARIO = @OID_USUARIO", new { OID_GRUPO_USUARIO, OID_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT * FROM WEB_USUARIO_GRUPO WHERE OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO AND OID_USUARIO=:OID_USUARIO", new { OID_GRUPO_USUARIO, OID_USUARIO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<UsuarioGrupoEntidade> BuscarPorPesquisa(string CPF, string NOME)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT *  FROM   VW_FUNC_PLANO_DADOS FPD  JOIN WEB_USUARIO U ON FPD.CPF_CGC = U.NOM_LOGIN  WHERE (CPF_CGC = @CPF OR @CPF IS NULL)    AND (NOME_ENTID LIKE '%' + @NOME + '%' OR @NOME IS NULL)", new { CPF, NOME });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<UsuarioGrupoEntidade>("SELECT DISTINCT * FROM VW_FUNC_PLANO_DADOS  FPD   JOIN WEB_USUARIO   U  ON FPD.CPF_CGC=U.NOM_LOGIN WHERE (CPF_CGC=:CPF OR :CPF IS NULL ) AND (NOME_ENTID LIKE '%' || :NOME || '%' OR :NOME IS NULL )", new { CPF, NOME });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

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
