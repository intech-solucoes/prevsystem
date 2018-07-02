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
    public abstract class IndiceValoresDAO : BaseDAO<IndiceValoresEntidade>
    {
		public virtual IEnumerable<IndiceValoresEntidade> BuscarPorCodigo(string COD_IND)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND = @COD_IND ORDER BY DT_IND DESC", new { COD_IND });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND=:COD_IND ORDER BY DT_IND DESC", new { COD_IND });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<IndiceValoresEntidade> BuscarUltimoPorCodigo(string COD_IND)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<IndiceValoresEntidade>("SELECT TOP 1 *  FROM TB_IND_VALORES  WHERE COD_IND = @COD_IND ORDER BY DT_IND DESC", new { COD_IND });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND=:COD_INDAND ROWNUM <= 1  ORDER BY DT_IND DESC", new { COD_IND });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
