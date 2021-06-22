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
	public abstract class WebReqBeneficioDescDAO : BaseDAO<WebReqBeneficioDescEntidade>
	{
		public WebReqBeneficioDescDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual long Insert(decimal OID_REQ_BENEFICIO, decimal OID_DESC_AUTORIZADO, string IND_AUTORIZADO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_REQ_BENEFICIO_DESC(  	OID_REQ_BENEFICIO,  	OID_DESC_AUTORIZADO,  	IND_AUTORIZADO  )  VALUES(  	@OID_REQ_BENEFICIO,  	@OID_DESC_AUTORIZADO,  	@IND_AUTORIZADO  )", new { OID_REQ_BENEFICIO, OID_DESC_AUTORIZADO, IND_AUTORIZADO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_REQ_BENEFICIO_DESC (OID_REQ_BENEFICIO_DESC,OID_REQ_BENEFICIO, OID_DESC_AUTORIZADO, IND_AUTORIZADO) VALUES (S_WEB_REQ_BENEFICIO_DESC.NEXTVAL,:OID_REQ_BENEFICIO, :OID_DESC_AUTORIZADO, :IND_AUTORIZADO)", new { OID_REQ_BENEFICIO, OID_DESC_AUTORIZADO, IND_AUTORIZADO });
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
