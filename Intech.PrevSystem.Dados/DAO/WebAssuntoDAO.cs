using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebAssuntoDAO : BaseDAO<WebAssuntoEntidade>
	{
		public WebAssuntoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<WebAssuntoEntidade> BuscarPorIndAtivo(string IND_ATIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT * FROM WEB_ASSUNTO  WHERE IND_ATIVO = @IND_ATIVO", new { IND_ATIVO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT * FROM WEB_ASSUNTO WHERE IND_ATIVO=:IND_ATIVO", new { IND_ATIVO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebAssuntoEntidade> Pesquisar(string TXT_ASSUNTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT WA.OID_ASSUNTO, WA.OID_AREA_FUNDACAO, WA.CD_FUNDACAO, WA.TXT_ASSUNTO, WA.IND_ATIVO, WAF.DES_AREA_FUNDACAO FROM WEB_ASSUNTO WA JOIN WEB_AREA_FUNDACAO WAF ON WA.OID_AREA_FUNDACAO = WAF.OID_AREA_FUNDACAO WHERE (TXT_ASSUNTO LIKE '%' +@TXT_ASSUNTO + '%' OR @TXT_ASSUNTO IS NULL) ORDER BY WA.OID_ASSUNTO", new { TXT_ASSUNTO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAssuntoEntidade>("SELECT WA.OID_ASSUNTO, WA.OID_AREA_FUNDACAO, WA.CD_FUNDACAO, WA.TXT_ASSUNTO, WA.IND_ATIVO, WAF.DES_AREA_FUNDACAO FROM WEB_ASSUNTO  WA   JOIN WEB_AREA_FUNDACAO   WAF  ON WA.OID_AREA_FUNDACAO=WAF.OID_AREA_FUNDACAO WHERE (TXT_ASSUNTO LIKE '%' || :TXT_ASSUNTO || '%' OR :TXT_ASSUNTO IS NULL ) ORDER BY WA.OID_ASSUNTO", new { TXT_ASSUNTO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}