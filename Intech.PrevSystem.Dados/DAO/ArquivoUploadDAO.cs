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
	public abstract class ArquivoUploadDAO : BaseDAO<ArquivoUploadEntidade>
	{
		public ArquivoUploadDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<ArquivoUploadEntidade> Buscar()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD", new {  }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD", new {  }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ArquivoUploadEntidade BuscarPorCodigo(long OID_ARQUIVO_UPLOAD)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ArquivoUploadEntidade>("SELECT *  FROM TBG_ARQUIVO_UPLOAD WHERE OID_ARQUIVO_UPLOAD = @OID_ARQUIVO_UPLOAD", new { OID_ARQUIVO_UPLOAD }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE OID_ARQUIVO_UPLOAD=:OID_ARQUIVO_UPLOAD", new { OID_ARQUIVO_UPLOAD }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ArquivoUploadEntidade> BuscarPorNome(string NOM_ARQUIVO_ORIGINAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE     NOM_ARQUIVO_ORIGINAL = @NOM_ARQUIVO_ORIGINAL", new { NOM_ARQUIVO_ORIGINAL }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE NOM_ARQUIVO_ORIGINAL=:NOM_ARQUIVO_ORIGINAL", new { NOM_ARQUIVO_ORIGINAL }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<ArquivoUploadEntidade> BuscarPorNomeLocal(string NOM_ARQUIVO_LOCAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE     NOM_ARQUIVO_LOCAL = @NOM_ARQUIVO_LOCAL", new { NOM_ARQUIVO_LOCAL }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE NOM_ARQUIVO_LOCAL=:NOM_ARQUIVO_LOCAL", new { NOM_ARQUIVO_LOCAL }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual ArquivoUploadEntidade BuscarPorOid(decimal OID_ARQUIVO_UPLOAD)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE OID_ARQUIVO_UPLOAD = @OID_ARQUIVO_UPLOAD", new { OID_ARQUIVO_UPLOAD }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<ArquivoUploadEntidade>("SELECT * FROM TBG_ARQUIVO_UPLOAD WHERE OID_ARQUIVO_UPLOAD=:OID_ARQUIVO_UPLOAD", new { OID_ARQUIVO_UPLOAD }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual long Insert(DateTime DTA_UPLOAD, decimal IND_STATUS, string NOM_ARQUIVO_LOCAL, string NOM_ARQUIVO_ORIGINAL, string NOM_DIRETORIO_LOCAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO TBG_ARQUIVO_UPLOAD(DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL) VALUES(     @DTA_UPLOAD,      @IND_STATUS,      @NOM_ARQUIVO_LOCAL,      @NOM_ARQUIVO_ORIGINAL,      @NOM_DIRETORIO_LOCAL )", new { DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO TBG_ARQUIVO_UPLOAD (OID_ARQUIVO_UPLOAD,DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL) VALUES (S_TBG_ARQUIVO_UPLOAD.NEXTVAL,:DTA_UPLOAD, :IND_STATUS, :NOM_ARQUIVO_LOCAL, :NOM_ARQUIVO_ORIGINAL, :NOM_DIRETORIO_LOCAL) RETURNING OID_ARQUIVO_UPLOAD INTO :PK", new { DTA_UPLOAD, IND_STATUS, NOM_ARQUIVO_LOCAL, NOM_ARQUIVO_ORIGINAL, NOM_DIRETORIO_LOCAL }, Transaction);
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