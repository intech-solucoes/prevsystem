﻿#region Usings
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
    public abstract class DocumentoPastaDAO : BaseDAO<DocumentoPastaEntidade>
    {
        
		public virtual IEnumerable<DocumentoPastaEntidade> BuscarPorOidPastaPaiComNomePastaPai(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.*, WGU.*, WDP2.NOM_PASTA AS 'NOM_PASTA_PAI'   FROM WEB_DOCUMENTO_PASTA WDP LEFT JOIN WEB_GRUPO_USUARIO WGU   ON WDP.OID_GRUPO_USUARIO = WGU.OID_GRUPO_USUARIO    JOIN WEB_DOCUMENTO_PASTA WDP2    ON WDP2.OID_DOCUMENTO_PASTA = WDP.OID_DOCUMENTO_PASTA_PAI", new { OID_DOCUMENTO_PASTA_PAI });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.*, WGU.*, WDP2.NOM_PASTA AS NOM_PASTA_PAI FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_GRUPO_USUARIO   WGU  ON WDP.OID_GRUPO_USUARIO=WGU.OID_GRUPO_USUARIO  JOIN WEB_DOCUMENTO_PASTA   WDP2  ON WDP2.OID_DOCUMENTO_PASTA=WDP.OID_DOCUMENTO_PASTA_PAI", new { OID_DOCUMENTO_PASTA_PAI });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoPastaEntidade> BuscarPorOidPastaPaiJoinWebGrupoUsuario(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT *  FROM WEB_DOCUMENTO_PASTA WDP LEFT JOIN WEB_GRUPO_USUARIO WGU  ON WDP.OID_GRUPO_USUARIO = WGU.OID_GRUPO_USUARIO  WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)     OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)", new { OID_DOCUMENTO_PASTA_PAI });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_GRUPO_USUARIO   WGU  ON WDP.OID_GRUPO_USUARIO=WGU.OID_GRUPO_USUARIO WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL )", new { OID_DOCUMENTO_PASTA_PAI });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoPastaEntidade> BuscarPorPastaPai(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT *  FROM WEB_DOCUMENTO_PASTA  WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)      OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)", new { OID_DOCUMENTO_PASTA_PAI });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL )", new { OID_DOCUMENTO_PASTA_PAI });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoPastaEntidade> BuscarPorWebUsuario(string NOM_LOGIN, decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.OID_DOCUMENTO_PASTA, WDP.OID_DOCUMENTO_PASTA_PAI, WDP.NOM_PASTA, WDP.OID_GRUPO_USUARIO   FROM WEB_DOCUMENTO_PASTA WDP   LEFT JOIN WEB_USUARIO_GRUPO WUG   ON WDP.OID_GRUPO_USUARIO = WUG.OID_GRUPO_USUARIO   LEFT JOIN WEB_USUARIO U ON U.OID_USUARIO = WUG.OID_USUARIO   WHERE (NOM_LOGIN = @NOM_LOGIN OR NOM_LOGIN IS NULL)     AND ((OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)     OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL))", new { NOM_LOGIN, OID_DOCUMENTO_PASTA_PAI });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.OID_DOCUMENTO_PASTA, WDP.OID_DOCUMENTO_PASTA_PAI, WDP.NOM_PASTA, WDP.OID_GRUPO_USUARIO FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_USUARIO_GRUPO   WUG  ON WDP.OID_GRUPO_USUARIO=WUG.OID_GRUPO_USUARIO LEFT JOIN WEB_USUARIO   U  ON U.OID_USUARIO=WUG.OID_USUARIO WHERE (NOM_LOGIN=:NOM_LOGIN OR NOM_LOGIN IS NULL ) AND ((OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL ))", new { NOM_LOGIN, OID_DOCUMENTO_PASTA_PAI });
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
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PASTA  WHERE (OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PASTA WHERE (OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO });
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
