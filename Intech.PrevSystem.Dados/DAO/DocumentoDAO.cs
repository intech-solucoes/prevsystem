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
		public virtual List<DocumentoEntidade> BuscarPorPasta(decimal? OID_DOCUMENTO_PASTA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT *  FROM WEB_DOCUMENTO  WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)     OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)", new { OID_DOCUMENTO_PASTA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DocumentoEntidade>("SELECT * FROM WEB_DOCUMENTO WHERE (OID_DOCUMENTO_PASTA=:OID_DOCUMENTO_PASTA) OR (:OID_DOCUMENTO_PASTA IS NULL  AND OID_DOCUMENTO_PASTA IS NULL )", new { OID_DOCUMENTO_PASTA }).ToList();
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
