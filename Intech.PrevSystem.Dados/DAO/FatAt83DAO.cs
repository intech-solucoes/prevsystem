using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class FatAt83DAO : BaseDAO<FatAt83Entidade>
	{
		public virtual List<FatAt83Entidade> BuscarPorIdade(int IDADE_APOSENTADORIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FatAt83Entidade>("SELECT *  FROM GB_FAT_AT83  WHERE IDADE >= @IDADE_APOSENTADORIA  ORDER BY IDADE", new { IDADE_APOSENTADORIA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FatAt83Entidade>("SELECT * FROM GB_FAT_AT83 WHERE IDADE>=:IDADE_APOSENTADORIA ORDER BY IDADE", new { IDADE_APOSENTADORIA }).ToList();
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
