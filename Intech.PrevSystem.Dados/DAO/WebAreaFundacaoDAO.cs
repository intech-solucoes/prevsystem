﻿#region Usings
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
    public abstract class WebAreaFundacaoDAO : BaseDAO<WebAreaFundacaoEntidade>
    {
        
		public virtual IEnumerable<WebAreaFundacaoEntidade> BuscarPorOidAssunto(string @OID_ASSUNTO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT *    FROM WEB_AREA_FUNDACAO WAF        JOIN WEB_ASSUNTO WA ON WAF.OID_AREA_FUNDACAO = WA.OID_AREA_FUNDACAO   WHERE OID_ASSUNTO = @OID_ASSUNTO", new { @OID_ASSUNTO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT * FROM WEB_AREA_FUNDACAO  WAF   JOIN WEB_ASSUNTO   WA  ON WAF.OID_AREA_FUNDACAO=WA.OID_AREA_FUNDACAO WHERE OID_ASSUNTO=:OID_ASSUNTO", new { @OID_ASSUNTO });
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
