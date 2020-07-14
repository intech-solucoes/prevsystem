using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class AdesaoDependenteDAO : BaseDAO<AdesaoDependenteEntidade>
	{
		public virtual List<AdesaoDependenteEntidade> BuscarPorOidAdesao(decimal OID_ADESAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<AdesaoDependenteEntidade>("SELECT *  FROM WEB_ADESAO_DEPENDENTE  WHERE OID_ADESAO = @OID_ADESAO", new { OID_ADESAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<AdesaoDependenteEntidade>("SELECT * FROM WEB_ADESAO_DEPENDENTE WHERE OID_ADESAO=:OID_ADESAO", new { OID_ADESAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual int ContarPorOidAdesao(decimal OID_ADESAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(*)  FROM WEB_ADESAO_DEPENDENTE  WHERE OID_ADESAO = @OID_ADESAO", new { OID_ADESAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(*) FROM WEB_ADESAO_DEPENDENTE WHERE OID_ADESAO=:OID_ADESAO", new { OID_ADESAO });
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
