using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class EspecieINSSDAO : BaseDAO<EspecieINSSEntidade>
	{
		public virtual List<EspecieINSSEntidade> Buscar()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<EspecieINSSEntidade>("SELECT * FROM GB_ESPECIE_INSS", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<EspecieINSSEntidade>("SELECT * FROM GB_ESPECIE_INSS", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual EspecieINSSEntidade BuscarPorCdEspecieINSS(string CD_ESPECIE_INSS)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<EspecieINSSEntidade>("SELECT * FROM GB_ESPECIE_INSS WHERE CD_ESPECIE_INSS = @CD_ESPECIE_INSS", new { CD_ESPECIE_INSS });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<EspecieINSSEntidade>("SELECT * FROM GB_ESPECIE_INSS WHERE CD_ESPECIE_INSS=:CD_ESPECIE_INSS", new { CD_ESPECIE_INSS });
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
