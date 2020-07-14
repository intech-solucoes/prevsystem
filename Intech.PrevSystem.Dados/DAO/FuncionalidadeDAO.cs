using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FuncionalidadeDAO : BaseDAO<FuncionalidadeEntidade>
	{
		public virtual List<FuncionalidadeEntidade> BuscarPorIndAtivo(string @IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FuncionalidadeEntidade>("SELECT *     FROM WEB_FUNCIONALIDADE  WHERE IND_ATIVO = @IND_ATIVO  ORDER BY DES_FUNCIONALIDADE", new { @IND_ATIVO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FuncionalidadeEntidade>("SELECT * FROM WEB_FUNCIONALIDADE WHERE IND_ATIVO=:IND_ATIVO ORDER BY DES_FUNCIONALIDADE", new { @IND_ATIVO }).ToList();
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
