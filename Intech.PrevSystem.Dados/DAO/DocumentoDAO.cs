using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DocumentoDAO : BaseDAO<DocumentoEntidade>
	{
		public virtual DocumentoEntidade BuscarPorOid(decimal OID_DOCUMENTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DocumentoEntidade>("SELECT *  FROM WEB_DOCUMENTO  WHERE OID_DOCUMENTO = @OID_DOCUMENTO", new { OID_DOCUMENTO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO WHERE OID_DOCUMENTO=:OID_DOCUMENTO", new { OID_DOCUMENTO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DocumentoEntidade> BuscarPorPasta(decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *  FROM WEB_DOCUMENTO  WHERE ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))", new { OID_DOCUMENTO_PASTA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO WHERE ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL ))", new { OID_DOCUMENTO_PASTA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DocumentoEntidade> BuscarPorPastaJoinTbPlano(decimal? OID_DOCUMENTO_PASTA, string ORDER_CRITERIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT D.OID_DOCUMENTO, D.OID_ARQUIVO_UPLOAD, D.OID_DOCUMENTO_PASTA, D.TXT_TITULO, D.IND_ATIVO, D.DTA_INCLUSAO, P.DS_PLANO, P.CD_PLANO   FROM WEB_DOCUMENTO D LEFT JOIN WEB_DOCUMENTO_PLANO DP   ON D.OID_DOCUMENTO = DP.OID_DOCUMENTO   LEFT JOIN TB_PLANOS P   ON DP.CD_PLANO = P.CD_PLANO   WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)  ORDER BY  CASE     WHEN @ORDER_CRITERIA = 'nome' THEN D.TXT_TITULO  END,  CASE  	WHEN @ORDER_CRITERIA = 'data' THEN D.DTA_INCLUSAO  END", new { OID_DOCUMENTO_PASTA, ORDER_CRITERIA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT D.OID_DOCUMENTO, D.OID_ARQUIVO_UPLOAD, D.OID_DOCUMENTO_PASTA, D.TXT_TITULO, D.IND_ATIVO, D.DTA_INCLUSAO, P.DS_PLANO, P.CD_PLANO FROM WEB_DOCUMENTO  D  LEFT JOIN WEB_DOCUMENTO_PLANO   DP  ON D.OID_DOCUMENTO=DP.OID_DOCUMENTO LEFT JOIN TB_PLANOS   P  ON DP.CD_PLANO=P.CD_PLANO WHERE (OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL ) ORDER BY CASE  WHEN :ORDER_CRITERIA='NOME' THEN D.TXT_TITULO END , CASE  WHEN :ORDER_CRITERIA='DATA' THEN D.DTA_INCLUSAO END ", new { OID_DOCUMENTO_PASTA, ORDER_CRITERIA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DocumentoEntidade> BuscarPorPastaPlano(decimal? OID_DOCUMENTO_PASTA, string CD_PLANO, string ORDER_CRITERIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *   FROM WEB_DOCUMENTO D LEFT JOIN WEB_DOCUMENTO_PLANO DP   ON D.OID_DOCUMENTO = DP.OID_DOCUMENTO   LEFT JOIN TB_PLANOS P   ON DP.CD_PLANO = P.CD_PLANO   WHERE ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))     AND ((P.CD_PLANO = @CD_PLANO  OR DP.CD_PLANO IS NULL)     OR (@CD_PLANO IS NULL AND P.CD_PLANO IS NULL))     ORDER BY   CASE     WHEN @ORDER_CRITERIA = 'nome' THEN D.TXT_TITULO  END,  CASE  	WHEN @ORDER_CRITERIA = 'data' THEN D.DTA_INCLUSAO  END", new { OID_DOCUMENTO_PASTA, CD_PLANO, ORDER_CRITERIA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO  D  LEFT JOIN WEB_DOCUMENTO_PLANO   DP  ON D.OID_DOCUMENTO=DP.OID_DOCUMENTO LEFT JOIN TB_PLANOS   P  ON DP.CD_PLANO=P.CD_PLANO WHERE ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )) AND ((P.CD_PLANO=:CD_PLANO OR DP.CD_PLANO IS NULL ) OR (:CD_PLANO IS NULL  AND P.CD_PLANO IS NULL )) ORDER BY CASE  WHEN :ORDER_CRITERIA='NOME' THEN D.TXT_TITULO END , CASE  WHEN :ORDER_CRITERIA='DATA' THEN D.DTA_INCLUSAO END ", new { OID_DOCUMENTO_PASTA, CD_PLANO, ORDER_CRITERIA }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DocumentoEntidade> BuscarPorPlanoPasta(string CD_PLANO, decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.*  FROM WEB_DOCUMENTO  WHERE OID_DOCUMENTO NOT IN (SELECT OID_DOCUMENTO FROM  WEB_DOCUMENTO_PLANO WHERE CD_PLANO <> @CD_PLANO)    AND ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))", new { CD_PLANO, OID_DOCUMENTO_PASTA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.* FROM WEB_DOCUMENTO WHERE OID_DOCUMENTO NOT  IN (SELECT OID_DOCUMENTO FROM WEB_DOCUMENTO_PLANO WHERE CD_PLANO<>:CD_PLANO) AND ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL ))", new { CD_PLANO, OID_DOCUMENTO_PASTA }).ToList();
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
