using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class ArquivoUploadDAO : BaseDAO<ArquivoUploadEntidade>
	{
		public virtual long Insert(DateTime DTA_UPLOAD, decimal IND_STATUS, string NOM_ARQUIVO_LOCAL, string NOM_ARQUIVO_ORIGINAL, string NOM_DIRETORIO_LOCAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO TBG_ARQUIVO_UPLOAD(DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL)  VALUES(      @DTA_UPLOAD,       @IND_STATUS,       @NOM_ARQUIVO_LOCAL,       @NOM_ARQUIVO_ORIGINAL,       @NOM_DIRETORIO_LOCAL  )", new { DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO TBG_ARQUIVO_UPLOAD (OID_ARQUIVO_UPLOAD,DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL) VALUES (S_TBG_ARQUIVO_UPLOAD.NEXTVAL,:DTA_UPLOAD, :IND_STATUS, :NOM_ARQUIVO_LOCAL, :NOM_ARQUIVO_ORIGINAL, :NOM_DIRETORIO_LOCAL) RETURNING OID_ARQUIVO_UPLOAD INTO :PK", new { DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL });
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
