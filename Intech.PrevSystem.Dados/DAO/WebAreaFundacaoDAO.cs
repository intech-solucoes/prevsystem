using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebAreaFundacaoDAO : BaseDAO<WebAreaFundacaoEntidade>
	{
		public virtual List<WebAreaFundacaoEntidade> BuscarPorOidAreaFundacao(decimal @OID_AREA_FUNDACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT *    FROM WEB_AREA_FUNDACAO WAF        JOIN WEB_ASSUNTO WA ON WAF.OID_AREA_FUNDACAO = WA.OID_AREA_FUNDACAO  WHERE WAF.OID_AREA_FUNDACAO = @OID_AREA_FUNDACAO", new { @OID_AREA_FUNDACAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT * FROM WEB_AREA_FUNDACAO  WAF   JOIN WEB_ASSUNTO   WA  ON WAF.OID_AREA_FUNDACAO=WA.OID_AREA_FUNDACAO WHERE WAF.OID_AREA_FUNDACAO=:OID_AREA_FUNDACAO", new { @OID_AREA_FUNDACAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<WebAreaFundacaoEntidade> BuscarPorOidAssunto(string @OID_ASSUNTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT *    FROM WEB_AREA_FUNDACAO WAF        JOIN WEB_ASSUNTO WA ON WAF.OID_AREA_FUNDACAO = WA.OID_AREA_FUNDACAO   WHERE OID_ASSUNTO = @OID_ASSUNTO", new { @OID_ASSUNTO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT * FROM WEB_AREA_FUNDACAO  WAF   JOIN WEB_ASSUNTO   WA  ON WAF.OID_AREA_FUNDACAO=WA.OID_AREA_FUNDACAO WHERE OID_ASSUNTO=:OID_ASSUNTO", new { @OID_ASSUNTO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<WebAreaFundacaoEntidade> BuscarPorOrdemAlfabetica()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT *  FROM WEB_AREA_FUNDACAO WAF  ORDER BY DES_AREA_FUNDACAO ASC", new {  }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT * FROM WEB_AREA_FUNDACAO  WAF  ORDER BY DES_AREA_FUNDACAO ASC", new {  }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<WebAreaFundacaoEntidade> Pesquisar(string DES_AREA_FUNDACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT *  FROM WEB_AREA_FUNDACAO  WHERE (DES_AREA_FUNDACAO LIKE '%' +@DES_AREA_FUNDACAO + '%' OR @DES_AREA_FUNDACAO IS NULL)  ORDER BY OID_AREA_FUNDACAO", new { DES_AREA_FUNDACAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebAreaFundacaoEntidade>("SELECT * FROM WEB_AREA_FUNDACAO WHERE (DES_AREA_FUNDACAO LIKE '%' || :DES_AREA_FUNDACAO || '%' OR :DES_AREA_FUNDACAO IS NULL ) ORDER BY OID_AREA_FUNDACAO", new { DES_AREA_FUNDACAO }).ToList();
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
