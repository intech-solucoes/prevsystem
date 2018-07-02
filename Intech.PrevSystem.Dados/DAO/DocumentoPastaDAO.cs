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
    public abstract class DocumentoPastaDAO : BaseDAO<DocumentoPastaEntidade>
    {
		public virtual IEnumerable<DocumentoPastaEntidade> BuscarPorPasta(decimal? OID_DOCUMENTO_PASTA_PAI)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)     OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)", new { OID_DOCUMENTO_PASTA_PAI });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<DocumentoPastaEntidade>("SELECT * FROM WEB_DOCUMENTO_PASTA WHERE (OID_DOCUMENTO_PASTA_PAI=:OID_DOCUMENTO_PASTA_PAI) OR (:OID_DOCUMENTO_PASTA_PAI IS NULL  AND OID_DOCUMENTO_PASTA_PAI IS NULL )", new { OID_DOCUMENTO_PASTA_PAI });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
