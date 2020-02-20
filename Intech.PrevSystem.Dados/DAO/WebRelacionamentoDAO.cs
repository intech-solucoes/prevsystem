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
    public abstract class WebRelacionamentoDAO : BaseDAO<WebRelacionamentoEntidade>
    {
        
		public virtual IEnumerable<WebRelacionamentoEntidade> BuscarPorOidAssunto(decimal @OID_ASSUNTO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRelacionamentoEntidade>("SELECT *     FROM WEB_RELACIONAMENTO WR         JOIN WEB_ASSUNTO WA ON WR.OID_ASSUNTO = WA.OID_ASSUNTO  WHERE WR.OID_ASSUNTO = @OID_ASSUNTO", new { @OID_ASSUNTO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRelacionamentoEntidade>("SELECT * FROM WEB_RELACIONAMENTO  WR   JOIN WEB_ASSUNTO   WA  ON WR.OID_ASSUNTO=WA.OID_ASSUNTO WHERE WR.OID_ASSUNTO=:OID_ASSUNTO", new { @OID_ASSUNTO });
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
