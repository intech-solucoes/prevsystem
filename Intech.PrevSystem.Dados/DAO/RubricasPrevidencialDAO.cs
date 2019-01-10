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
    public abstract class RubricasPrevidencialDAO : BaseDAO<RubricasPrevidencialEntidade>
    {
        
		public virtual IEnumerable<RubricasPrevidencialEntidade> BuscarIncideLiquidoMargemConsig(string INCID_LIQUIDO, string INCID_MARGEM_CONSIG)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT * FROM GB_RUBRICAS_PREVIDENCIAL WHERE INCID_LIQUIDO = @INCID_LIQUIDO   AND INCID_MARGEM_CONSIG = @INCID_MARGEM_CONSIG", new { INCID_LIQUIDO, INCID_MARGEM_CONSIG });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RubricasPrevidencialEntidade>("SELECT * FROM GB_RUBRICAS_PREVIDENCIAL WHERE INCID_LIQUIDO=:INCID_LIQUIDO AND INCID_MARGEM_CONSIG=:INCID_MARGEM_CONSIG", new { INCID_LIQUIDO, INCID_MARGEM_CONSIG });
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
