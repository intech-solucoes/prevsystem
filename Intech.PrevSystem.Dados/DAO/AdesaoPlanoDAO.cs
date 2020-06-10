using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class AdesaoPlanoDAO : BaseDAO<AdesaoPlanoEntidade>
	{
		public virtual AdesaoPlanoEntidade BuscarPorOidAdesao(decimal OID_ADESAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoPlanoEntidade>("SELECT *  FROM WEB_ADESAO_PLANO  WHERE OID_ADESAO = @OID_ADESAO", new { OID_ADESAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoPlanoEntidade>("SELECT * FROM WEB_ADESAO_PLANO WHERE OID_ADESAO=:OID_ADESAO", new { OID_ADESAO });
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
