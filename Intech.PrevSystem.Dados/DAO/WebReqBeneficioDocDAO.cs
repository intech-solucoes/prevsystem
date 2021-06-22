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
	public abstract class WebReqBeneficioDocDAO : BaseDAO<WebReqBeneficioDocEntidade>
	{
		public WebReqBeneficioDocDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual long Insert(decimal OID_REQ_BENEFICIO, decimal OID_DOC_EXIGIDO, string TXT_NOME_FISICO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_REQ_BENEFICIO_DOC(  	OID_REQ_BENEFICIO,  	OID_DOC_EXIGIDO,  	TXT_NOME_FISICO  )  VALUES(  	@OID_REQ_BENEFICIO,  	@OID_DOC_EXIGIDO,  	@TXT_NOME_FISICO  )", new { OID_REQ_BENEFICIO, OID_DOC_EXIGIDO, TXT_NOME_FISICO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_REQ_BENEFICIO_DOC (OID_REQ_BENEFICIO_DOC,OID_REQ_BENEFICIO, OID_DOC_EXIGIDO, TXT_NOME_FISICO) VALUES (S_WEB_REQ_BENEFICIO_DOC.NEXTVAL,:OID_REQ_BENEFICIO, :OID_DOC_EXIGIDO, :TXT_NOME_FISICO)", new { OID_REQ_BENEFICIO, OID_DOC_EXIGIDO, TXT_NOME_FISICO });
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
