using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebCapitalSeguradoDAO : BaseDAO<WebCapitalSeguradoEntidade>
	{
		public virtual List<WebCapitalSeguradoEntidade> BuscarPorCpf(string COD_CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebCapitalSeguradoEntidade>("SELECT * FROM WEB_CAPITAL_SEGURADO WHERE COD_CPF = @COD_CPF  ORDER BY ANO DESC", new { COD_CPF }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebCapitalSeguradoEntidade>("SELECT * FROM WEB_CAPITAL_SEGURADO WHERE COD_CPF=:COD_CPF  ORDER BY ANO DESC", new { COD_CPF }).ToList();
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
