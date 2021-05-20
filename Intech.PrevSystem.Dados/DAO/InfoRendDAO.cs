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
	public abstract class InfoRendDAO : BaseDAO<InfoRendEntidade>
	{
		public InfoRendDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<InfoRendEntidade> BuscarPorOidHeader(decimal OID_HEADER_INFO_REND)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<InfoRendEntidade>("SELECT * FROM TB_INFO_REND WHERE OID_HEADER_INFO_REND = @OID_HEADER_INFO_REND", new { OID_HEADER_INFO_REND }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<InfoRendEntidade>("SELECT * FROM TB_INFO_REND WHERE OID_HEADER_INFO_REND=:OID_HEADER_INFO_REND", new { OID_HEADER_INFO_REND }, Transaction).ToList();
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