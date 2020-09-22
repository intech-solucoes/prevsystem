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
    public abstract class RegraNaturezaDAO : BaseDAO<RegraNaturezaEntidade>
    {
        
		public virtual RegraNaturezaEntidade BuscarPorQtdReformas(int QUANTIDADE)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RegraNaturezaEntidade>("SELECT *  FROM CE_REGRA_NATUREZA  WHERE QTD_REFORMAS = @QUANTIDADE    AND DT_INI_VIGENCIA = (SELECT MAX(DT_INI_VIGENCIA) FROM CE_REGRA_NATUREZA WHERE QTD_REFORMAS = @QUANTIDADE)  ORDER BY DT_INI_VIGENCIA DESC", new { QUANTIDADE });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RegraNaturezaEntidade>("SELECT * FROM CE_REGRA_NATUREZA WHERE QTD_REFORMAS=:QUANTIDADE AND DT_INI_VIGENCIA=(SELECT MAX(DT_INI_VIGENCIA) FROM CE_REGRA_NATUREZA WHERE QTD_REFORMAS=:QUANTIDADE) ORDER BY DT_INI_VIGENCIA DESC", new { QUANTIDADE });
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
