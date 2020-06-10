using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class AdesaoContribDAO : BaseDAO<AdesaoContribEntidade>
	{
		public virtual AdesaoContribEntidade BuscarPorOidAdesaoPlano(decimal OID_ADESAO_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoContribEntidade>("SELECT *  FROM WEB_ADESAO_CONTRIB  WHERE OID_ADESAO_PLANO = @OID_ADESAO_PLANO", new { OID_ADESAO_PLANO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoContribEntidade>("SELECT * FROM WEB_ADESAO_CONTRIB WHERE OID_ADESAO_PLANO=:OID_ADESAO_PLANO", new { OID_ADESAO_PLANO });
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
