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
    public abstract class TbgIndiceValDAO : BaseDAO<TbgIndiceValEntidade>
    {
        
		public virtual IEnumerable<TbgIndiceValEntidade> BuscarPorCodIndice(string COD_INDICE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT *  FROM TBG_INDICE_VAL  INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE  WHERE TBG_INDICE.COD_INDICE = @COD_INDICE  ORDER BY DTA_INDICE DESC", new { COD_INDICE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT * FROM TBG_INDICE_VAL INNER  JOIN TBG_INDICE  ON TBG_INDICE.OID_INDICE=TBG_INDICE_VAL.OID_INDICE WHERE TBG_INDICE.COD_INDICE=:COD_INDICE ORDER BY DTA_INDICE DESC", new { COD_INDICE });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<TbgIndiceValEntidade> BuscarPorCodIndiceData(string COD_INDICE, DateTime DTA_INDICE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT *  FROM TBG_INDICE_VAL  INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE  WHERE TBG_INDICE.COD_INDICE = @COD_INDICE    AND DTA_INDICE = (SELECT MAX(DTA_INDICE)                      FROM TBG_INDICE_VAL                       INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE                      WHERE TBG_INDICE.COD_INDICE = @COD_INDICE                        AND DTA_INDICE <= @DTA_INDICE)  ORDER BY DTA_INDICE DESC", new { COD_INDICE, DTA_INDICE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT * FROM TBG_INDICE_VAL INNER  JOIN TBG_INDICE  ON TBG_INDICE.OID_INDICE=TBG_INDICE_VAL.OID_INDICE WHERE TBG_INDICE.COD_INDICE=:COD_INDICE AND DTA_INDICE=(SELECT MAX(DTA_INDICE) FROM TBG_INDICE_VAL INNER  JOIN TBG_INDICE  ON TBG_INDICE.OID_INDICE=TBG_INDICE_VAL.OID_INDICE WHERE TBG_INDICE.COD_INDICE=:COD_INDICE AND DTA_INDICE<=:DTA_INDICE) ORDER BY DTA_INDICE DESC", new { COD_INDICE, DTA_INDICE });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<TbgIndiceValEntidade> BuscarUltimoPorCodIndice(string COD_INDICE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT *  FROM TBG_INDICE_VAL  INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE  WHERE TBG_INDICE.COD_INDICE = @COD_INDICE    AND DTA_INDICE = (SELECT MAX(DTA_INDICE)                      FROM TBG_INDICE_VAL                       INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE                      WHERE TBG_INDICE.COD_INDICE = @COD_INDICE)  ORDER BY DTA_INDICE DESC", new { COD_INDICE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<TbgIndiceValEntidade>("SELECT * FROM TBG_INDICE_VAL INNER  JOIN TBG_INDICE  ON TBG_INDICE.OID_INDICE=TBG_INDICE_VAL.OID_INDICE WHERE TBG_INDICE.COD_INDICE=:COD_INDICE AND DTA_INDICE=(SELECT MAX(DTA_INDICE) FROM TBG_INDICE_VAL INNER  JOIN TBG_INDICE  ON TBG_INDICE.OID_INDICE=TBG_INDICE_VAL.OID_INDICE WHERE TBG_INDICE.COD_INDICE=:COD_INDICE) ORDER BY DTA_INDICE DESC", new { COD_INDICE });
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
