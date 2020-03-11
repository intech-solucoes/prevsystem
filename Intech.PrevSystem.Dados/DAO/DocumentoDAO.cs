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
    public abstract class DocumentoDAO : BaseDAO<DocumentoEntidade>
    {
        
		public virtual IEnumerable<DocumentoEntidade> BuscarPorPasta(decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *  FROM WEB_DOCUMENTO  WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)", new { OID_DOCUMENTO_PASTA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO WHERE (OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )", new { OID_DOCUMENTO_PASTA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoEntidade> BuscarPorPastaJoinTbPlano(decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *   FROM WEB_DOCUMENTO D LEFT JOIN WEB_DOCUMENTO_PLANO DP   ON D.OID_DOCUMENTO = DP.OID_DOCUMENTO   LEFT JOIN TB_PLANOS P   ON DP.CD_PLANO = P.CD_PLANO   WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)", new { OID_DOCUMENTO_PASTA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO  D  LEFT JOIN WEB_DOCUMENTO_PLANO   DP  ON D.OID_DOCUMENTO=DP.OID_DOCUMENTO LEFT JOIN TB_PLANOS   P  ON DP.CD_PLANO=P.CD_PLANO WHERE (OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )", new { OID_DOCUMENTO_PASTA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoEntidade> BuscarPorPastaPlano(decimal? OID_DOCUMENTO_PASTA, string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *   FROM WEB_DOCUMENTO D LEFT JOIN WEB_DOCUMENTO_PLANO DP   ON D.OID_DOCUMENTO = DP.OID_DOCUMENTO   LEFT JOIN TB_PLANOS P   ON DP.CD_PLANO = P.CD_PLANO   WHERE ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))     AND ((P.CD_PLANO = @CD_PLANO  OR DP.CD_PLANO IS NULL)     OR (@CD_PLANO IS NULL AND P.CD_PLANO IS NULL))", new { OID_DOCUMENTO_PASTA, CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO  D  LEFT JOIN WEB_DOCUMENTO_PLANO   DP  ON D.OID_DOCUMENTO=DP.OID_DOCUMENTO LEFT JOIN TB_PLANOS   P  ON DP.CD_PLANO=P.CD_PLANO WHERE ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )) AND ((P.CD_PLANO=:CD_PLANO OR DP.CD_PLANO IS NULL ) OR (:CD_PLANO IS NULL  AND P.CD_PLANO IS NULL ))", new { OID_DOCUMENTO_PASTA, CD_PLANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DocumentoEntidade> BuscarPorPlanoPasta(string CD_PLANO, decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.*  FROM WEB_DOCUMENTO  WHERE OID_DOCUMENTO NOT IN (SELECT OID_DOCUMENTO FROM  WEB_DOCUMENTO_PLANO WHERE CD_PLANO <> @CD_PLANO)    AND ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))", new { CD_PLANO, OID_DOCUMENTO_PASTA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT WEB_DOCUMENTO.* FROM WEB_DOCUMENTO WHERE OID_DOCUMENTO NOT  IN (SELECT OID_DOCUMENTO FROM WEB_DOCUMENTO_PLANO WHERE CD_PLANO<>:CD_PLANO) AND ((OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL ))", new { CD_PLANO, OID_DOCUMENTO_PASTA });
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
