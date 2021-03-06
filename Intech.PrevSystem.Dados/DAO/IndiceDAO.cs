﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class IndiceDAO : BaseDAO<IndiceEntidade>
	{
		public virtual IndiceEntidade BuscarPorCodigo(string COD_IND)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<IndiceEntidade>("SELECT *  FROM TB_INDICE  WHERE COD_IND = @COD_IND", new { COD_IND });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<IndiceEntidade>("SELECT * FROM TB_INDICE WHERE COD_IND=:COD_IND", new { COD_IND });
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
