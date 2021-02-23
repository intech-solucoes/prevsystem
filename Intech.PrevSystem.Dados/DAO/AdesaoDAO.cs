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
	public abstract class AdesaoDAO : BaseDAO<AdesaoEntidade>
	{
		public AdesaoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual AdesaoEntidade BuscarPorCpf(string COD_CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoEntidade>("SELECT * FROM WEB_ADESAO WHERE COD_CPF = @COD_CPF", new { COD_CPF });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<AdesaoEntidade>("SELECT * FROM WEB_ADESAO WHERE COD_CPF=:COD_CPF", new { COD_CPF });
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
