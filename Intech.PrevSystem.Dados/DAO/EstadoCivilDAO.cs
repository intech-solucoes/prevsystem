#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{
    public abstract class EstadoCivilDAO : BaseDAO<EstadoCivilEntidade>
    {
		public virtual EstadoCivilEntidade BuscarPorCodigo(string CD_ESTADO_CIVIL)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<EstadoCivilEntidade>("SELECT *  FROM CS_ESTADO_CIVIL WHERE CD_ESTADO_CIVIL = @CD_ESTADO_CIVIL", new { CD_ESTADO_CIVIL });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<EstadoCivilEntidade>("SELECT * FROM CS_ESTADO_CIVIL WHERE CD_ESTADO_CIVIL=:CD_ESTADO_CIVIL", new { CD_ESTADO_CIVIL });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
