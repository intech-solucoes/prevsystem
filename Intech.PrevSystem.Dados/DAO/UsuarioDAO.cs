using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class UsuarioDAO : BaseDAO<UsuarioEntidade>
	{
		public virtual void AtualizarSenhaPrimeiroAcesso(decimal OID_USUARIO, string PWD_USUARIO, string IND_PRIMEIRO_ACESSO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE WEB_USUARIO   SET PWD_USUARIO = @PWD_USUARIO, IND_PRIMEIRO_ACESSO = @IND_PRIMEIRO_ACESSO  WHERE OID_USUARIO = @OID_USUARIO", new { OID_USUARIO, PWD_USUARIO, IND_PRIMEIRO_ACESSO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE WEB_USUARIO SET PWD_USUARIO=:PWD_USUARIO, IND_PRIMEIRO_ACESSO=:IND_PRIMEIRO_ACESSO WHERE OID_USUARIO=:OID_USUARIO", new { OID_USUARIO, PWD_USUARIO, IND_PRIMEIRO_ACESSO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual UsuarioEntidade BuscarPorCpf(string NOM_LOGIN)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT TOP 1 *  FROM WEB_USUARIO  WHERE NOM_LOGIN = @NOM_LOGIN", new { NOM_LOGIN });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN AND ROWNUM <= 1 ", new { NOM_LOGIN });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual UsuarioEntidade BuscarPorLogin(string NOM_LOGIN, string PWD_USUARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT TOP 1 *  FROM WEB_USUARIO  WHERE NOM_LOGIN = @NOM_LOGIN    AND PWD_USUARIO = @PWD_USUARIO", new { NOM_LOGIN, PWD_USUARIO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN AND PWD_USUARIO=:PWD_USUARIO AND ROWNUM <= 1 ", new { NOM_LOGIN, PWD_USUARIO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual UsuarioEntidade BuscarPrimeiroAcesso(string NOM_LOGIN)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN = @NOM_LOGIN", new { NOM_LOGIN });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<UsuarioEntidade>("SELECT * FROM WEB_USUARIO WHERE NOM_LOGIN=:NOM_LOGIN", new { NOM_LOGIN });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual void Insert(string NOM_LOGIN, string PWD_USUARIO, string IND_BLOQUEADO, decimal NUM_TENTATIVA, string DES_LOTACAO, string IND_ADMINISTRADOR, string IND_ATIVO, string NOM_USUARIO_CRIACAO, DateTime? DTA_CRIACAO, string NOM_USUARIO_ATUALIZACAO, DateTime? DTA_ATUALIZACAO, string CD_EMPRESA, string IND_PRIMEIRO_ACESSO, decimal? SEQ_RECEBEDOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_USUARIO (      NOM_LOGIN,      PWD_USUARIO,      IND_BLOQUEADO,      NUM_TENTATIVA,      DES_LOTACAO,      IND_ADMINISTRADOR,      IND_ATIVO,      NOM_USUARIO_CRIACAO,      DTA_CRIACAO,      NOM_USUARIO_ATUALIZACAO,      DTA_ATUALIZACAO,      CD_EMPRESA,      SEQ_RECEBEDOR,      IND_PRIMEIRO_ACESSO  ) VALUES (      @NOM_LOGIN,      @PWD_USUARIO,      @IND_BLOQUEADO,      @NUM_TENTATIVA,      @DES_LOTACAO,      @IND_ADMINISTRADOR,      @IND_ATIVO,      @NOM_USUARIO_CRIACAO,      @DTA_CRIACAO,      @NOM_USUARIO_ATUALIZACAO,      @DTA_ATUALIZACAO,      @CD_EMPRESA,      @SEQ_RECEBEDOR,      @IND_PRIMEIRO_ACESSO  )", new { NOM_LOGIN, PWD_USUARIO, IND_BLOQUEADO, NUM_TENTATIVA, DES_LOTACAO, IND_ADMINISTRADOR, IND_ATIVO, NOM_USUARIO_CRIACAO, DTA_CRIACAO, NOM_USUARIO_ATUALIZACAO, DTA_ATUALIZACAO, CD_EMPRESA, IND_PRIMEIRO_ACESSO, SEQ_RECEBEDOR });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_USUARIO (      OID_USUARIO,      NOM_LOGIN,      PWD_USUARIO,      IND_BLOQUEADO,      NUM_TENTATIVA,      DES_LOTACAO,      IND_ADMINISTRADOR,      IND_ATIVO,      NOM_USUARIO_CRIACAO,      DTA_CRIACAO,      NOM_USUARIO_ATUALIZACAO,      DTA_ATUALIZACAO,      CD_EMPRESA,      SEQ_RECEBEDOR,      IND_PRIMEIRO_ACESSO  ) VALUES (      S_WEB_USUARIO.NEXTVAL,      :NOM_LOGIN,      :PWD_USUARIO,      :IND_BLOQUEADO,      :NUM_TENTATIVA,      :DES_LOTACAO,      :IND_ADMINISTRADOR,      :IND_ATIVO,      :NOM_USUARIO_CRIACAO,      :DTA_CRIACAO,      :NOM_USUARIO_ATUALIZACAO,      :DTA_ATUALIZACAO,      :CD_EMPRESA,      :SEQ_RECEBEDOR,      :IND_PRIMEIRO_ACESSO  )", new { NOM_LOGIN, PWD_USUARIO, IND_BLOQUEADO, NUM_TENTATIVA, DES_LOTACAO, IND_ADMINISTRADOR, IND_ATIVO, NOM_USUARIO_CRIACAO, DTA_CRIACAO, NOM_USUARIO_ATUALIZACAO, DTA_ATUALIZACAO, CD_EMPRESA, IND_PRIMEIRO_ACESSO, SEQ_RECEBEDOR });
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
