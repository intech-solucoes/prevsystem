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
    public abstract class FeriadoDAO : BaseDAO<FeriadoEntidade>
    {
		public virtual IEnumerable<DateTime> BuscarDatas()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<DateTime>("SELECT DT_FERIADO FROM TB_FERIADO", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<DateTime>("SELECT DT_FERIADO FROM TB_FERIADO", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
