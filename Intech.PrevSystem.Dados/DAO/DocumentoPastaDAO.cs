using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DocumentoPastaDAO : BaseDAO<DocumentoPastaEntidade>
	{
		public DocumentoPastaDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual DocumentoPastaEntidade BuscarPorOid(decimal OID_DOCUMENTO_PASTA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA", new { OID_DOCUMENTO_PASTA }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA", new { OID_DOCUMENTO_PASTA }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<DocumentoPastaEntidade> BuscarPorOidPastaPaiComNomePastaPai(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.*, WGU.*, WDP2.NOM_PASTA AS 'NOM_PASTA_PAI'  FROM WEB_DOCUMENTO_PASTA WDP LEFT JOIN WEB_GRUPO_USUARIO WGU  ON WDP.OID_GRUPO_USUARIO = WGU.OID_GRUPO_USUARIO   JOIN WEB_DOCUMENTO_PASTA WDP2   ON WDP2.OID_DOCUMENTO_PASTA = WDP.OID_DOCUMENTO_PASTA_PAI", new { OID_DOCUMENTO_PASTA_PAI }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.*, WGU.*, WDP2.NOM_PASTA AS NOM_PASTA_PAI FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_GRUPO_USUARIO   WGU  ON WDP.OID_GRUPO_USUARIO=WGU.OID_GRUPO_USUARIO  JOIN WEB_DOCUMENTO_PASTA   WDP2  ON WDP2.OID_DOCUMENTO_PASTA=WDP.OID_DOCUMENTO_PASTA_PAI", new { OID_DOCUMENTO_PASTA_PAI }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<DocumentoPastaEntidade> BuscarPorOidPastaPaiJoinWebGrupoUsuario(decimal? OID_DOCUMENTO_PASTA_PAI, string ORDER_CRITERIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WDP LEFT JOIN WEB_GRUPO_USUARIO WGU ON WDP.OID_GRUPO_USUARIO = WGU.OID_GRUPO_USUARIO WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)    OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL) ORDER BY CASE    WHEN @ORDER_CRITERIA = 'nome' THEN WDP.NOM_PASTA END, CASE    WHEN @ORDER_CRITERIA = 'data' THEN WDP.DTA_INCLUSAO END", new { OID_DOCUMENTO_PASTA_PAI, ORDER_CRITERIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_GRUPO_USUARIO   WGU  ON WDP.OID_GRUPO_USUARIO=WGU.OID_GRUPO_USUARIO WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL ) ORDER BY CASE  WHEN :ORDER_CRITERIA='NOME' THEN WDP.NOM_PASTA END , CASE  WHEN :ORDER_CRITERIA='DATA' THEN WDP.DTA_INCLUSAO END ", new { OID_DOCUMENTO_PASTA_PAI, ORDER_CRITERIA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<DocumentoPastaEntidade> BuscarPorPastaPai(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)     OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)", new { OID_DOCUMENTO_PASTA_PAI }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL )", new { OID_DOCUMENTO_PASTA_PAI }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<DocumentoPastaEntidade> BuscarPorWebUsuario(string NOM_LOGIN, decimal? OID_DOCUMENTO_PASTA_PAI, string ORDER_CRITERIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.OID_DOCUMENTO_PASTA, WDP.OID_DOCUMENTO_PASTA_PAI, WDP.NOM_PASTA, WDP.OID_GRUPO_USUARIO, WDP.DTA_INCLUSAO FROM WEB_DOCUMENTO_PASTA WDP  LEFT JOIN WEB_USUARIO_GRUPO WUG ON WDP.OID_GRUPO_USUARIO = WUG.OID_GRUPO_USUARIO  LEFT JOIN WEB_USUARIO U ON U.OID_USUARIO = WUG.OID_USUARIO WHERE (NOM_LOGIN = @NOM_LOGIN OR NOM_LOGIN IS NULL) AND ((OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)  OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL))", new { NOM_LOGIN, OID_DOCUMENTO_PASTA_PAI, ORDER_CRITERIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoPastaEntidade>("SELECT WDP.OID_DOCUMENTO_PASTA, WDP.OID_DOCUMENTO_PASTA_PAI, WDP.NOM_PASTA, WDP.OID_GRUPO_USUARIO, WDP.DTA_INCLUSAO FROM WEB_DOCUMENTO_PASTA  WDP  LEFT JOIN WEB_USUARIO_GRUPO   WUG  ON WDP.OID_GRUPO_USUARIO=WUG.OID_GRUPO_USUARIO LEFT JOIN WEB_USUARIO   U  ON U.OID_USUARIO=WUG.OID_USUARIO WHERE (NOM_LOGIN=:NOM_LOGIN OR NOM_LOGIN IS NULL ) AND ((OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL ))", new { NOM_LOGIN, OID_DOCUMENTO_PASTA_PAI, ORDER_CRITERIA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void DeletarPorOidGrupoUsuario(decimal OID_GRUPO_USUARIO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PASTA WHERE (OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PASTA WHERE (OID_GRUPO_USUARIO=:OID_GRUPO_USUARIO)", new { OID_GRUPO_USUARIO }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}