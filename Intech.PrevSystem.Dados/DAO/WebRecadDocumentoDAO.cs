using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebRecadDocumentoDAO : BaseDAO<WebRecadDocumentoEntidade>
	{
		public virtual long Insert( decimal OID_RECAD_DADOS,  string TXT_TITULO,  string TXT_NOME_FISICO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DOCUMENTO(  	OID_RECAD_DADOS,      TXT_TITULO,      TXT_NOME_FISICO  )  VALUES(      @OID_RECAD_DADOS,      @TXT_TITULO,      @TXT_NOME_FISICO  )", new { OID_RECAD_DADOS, TXT_TITULO, TXT_NOME_FISICO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DOCUMENTO (OID_RECAD_DOCUMENTO,OID_RECAD_DADOS, TXT_TITULO, TXT_NOME_FISICO) VALUES (S_WEB_RECAD_DOCUMENTO.NEXTVAL,:OID_RECAD_DADOS, :TXT_TITULO, :TXT_NOME_FISICO) RETURNING OID_RECAD_DOCUMENTO INTO :PK", new { OID_RECAD_DADOS, TXT_TITULO, TXT_NOME_FISICO });
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
