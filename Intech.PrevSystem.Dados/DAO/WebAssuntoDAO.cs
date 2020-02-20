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
    public abstract class WebAssuntoDAO : BaseDAO<WebAssuntoEntidade>
    {
        
		public virtual IEnumerable<WebAssuntoEntidade> BuscarPorIndAtivo(string IND_ATIVO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT * FROM WEB_ASSUNTO   WHERE IND_ATIVO = @IND_ATIVO", new { IND_ATIVO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT * FROM WEB_ASSUNTO WHERE IND_ATIVO=:IND_ATIVO", new { IND_ATIVO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<WebAssuntoEntidade> Pesquisar(string TXT_ASSUNTO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT *  FROM WEB_ASSUNTO WA JOIN WEB_AREA_FUNDACAO WAF  ON WA.OID_AREA_FUNDACAO = WAF.OID_AREA_FUNDACAO  WHERE (TXT_ASSUNTO LIKE '%' +@TXT_ASSUNTO + '%' OR @TXT_ASSUNTO IS NULL)  ORDER BY WA.OID_ASSUNTO", new { TXT_ASSUNTO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT * FROM WEB_ASSUNTO  WA   JOIN WEB_AREA_FUNDACAO   WAF  ON WA.OID_AREA_FUNDACAO=WAF.OID_AREA_FUNDACAO WHERE (TXT_ASSUNTO LIKE '%' || :TXT_ASSUNTO || '%' OR :TXT_ASSUNTO IS NULL ) ORDER BY WA.OID_ASSUNTO", new { TXT_ASSUNTO });
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
