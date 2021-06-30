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
	public abstract class DocumentoPlanoDAO : BaseDAO<DocumentoPlanoEntidade>
	{
		public DocumentoPlanoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual void DeletarPorOidDocumento(decimal OID_DOCUMENTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PLANO WHERE OID_DOCUMENTO = @OID_DOCUMENTO", new { OID_DOCUMENTO }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_DOCUMENTO_PLANO WHERE OID_DOCUMENTO=:OID_DOCUMENTO", new { OID_DOCUMENTO }, Transaction);
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