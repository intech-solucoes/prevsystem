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
	public abstract class LGPDConsentimentoDAO : BaseDAO<LGPDConsentimentoEntidade>
	{
		public LGPDConsentimentoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<LGPDConsentimentoEntidade> BuscarPorCPF(string CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF = @CPF", new { CPF }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF", new { CPF }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<LGPDConsentimentoEntidade> BuscarPorCPFTextoOrigem(string CPF, string TXT_ORIGEM)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF = @CPF AND TXT_ORIGEM = @TXT_ORIGEM", new { CPF, TXT_ORIGEM }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF AND TXT_ORIGEM=:TXT_ORIGEM", new { CPF, TXT_ORIGEM }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<LGPDConsentimentoEntidade> BuscarPorCPFTextoOrigemDataExpiracao(string CPF, string TXT_ORIGEM, DateTime DataExpiracao)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF = @CPF AND TXT_ORIGEM = @TXT_ORIGEM AND DTA_CONSENTIMENTO >= @DataExpiracao", new { CPF, TXT_ORIGEM, DataExpiracao }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<LGPDConsentimentoEntidade>("SELECT * FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF AND TXT_ORIGEM=:TXT_ORIGEM AND DTA_CONSENTIMENTO>=:DATAEXPIRACAO", new { CPF, TXT_ORIGEM, DataExpiracao }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void Insert(string COD_IDENTIFICADOR, string CD_FUNDACAO, string COD_CPF, DateTime DTA_CONSENTIMENTO, string TXT_IPV4, string TXT_IPV6, string TXT_DISPOSITIVO, string TXT_ORIGEM)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_LGPD_CONSENTIMENTO  (      COD_IDENTIFICADOR     ,CD_FUNDACAO     ,COD_CPF     ,DTA_CONSENTIMENTO     ,TXT_IPV4     ,TXT_IPV6     ,TXT_DISPOSITIVO     ,TXT_ORIGEM ) VALUES (     @COD_IDENTIFICADOR,     @CD_FUNDACAO,     @COD_CPF,     @DTA_CONSENTIMENTO,     @TXT_IPV4,     @TXT_IPV6,     @TXT_DISPOSITIVO,     @TXT_ORIGEM )", new { COD_IDENTIFICADOR, CD_FUNDACAO, COD_CPF, DTA_CONSENTIMENTO, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO, TXT_ORIGEM }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_LGPD_CONSENTIMENTO  (      OID_LGPD_CONSENTIMENTO     ,COD_IDENTIFICADOR     ,CD_FUNDACAO     ,COD_CPF     ,DTA_CONSENTIMENTO     ,TXT_IPV4     ,TXT_IPV6     ,TXT_DISPOSITIVO     ,TXT_ORIGEM ) VALUES (     S_WEB_LGPD_CONSENTIMENTO.NEXTVAL,     :COD_IDENTIFICADOR,     :CD_FUNDACAO,     :COD_CPF,     :DTA_CONSENTIMENTO,     :TXT_IPV4,     :TXT_IPV6,     :TXT_DISPOSITIVO,     :TXT_ORIGEM )", new { COD_IDENTIFICADOR, CD_FUNDACAO, COD_CPF, DTA_CONSENTIMENTO, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO, TXT_ORIGEM }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void Resetar()
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_LGPD_CONSENTIMENTO", new {  }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_LGPD_CONSENTIMENTO", new {  }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual void ResetarPorCPF(string CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF = @CPF", new { CPF }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM WEB_LGPD_CONSENTIMENTO WHERE COD_CPF=:CPF", new { CPF }, Transaction);
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