using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class LogSMSDAO : BaseDAO<LogSMSEntidade>
	{
		public virtual void Insert(string RESPOSTA_ENVIO, string NUM_TELEFONE, string NUM_MATRICULA, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO TBG_LOG_SMS  (      RESPOSTA_ENVIO,       NUM_TELEFONE,       NUM_MATRICULA,       NUM_INSCRICAO,       DTA_ENVIO  )   VALUES (      @RESPOSTA_ENVIO,       @NUM_TELEFONE,       @NUM_MATRICULA,       @NUM_INSCRICAO,       GETDATE()  )", new { RESPOSTA_ENVIO, NUM_TELEFONE, NUM_MATRICULA, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO TBG_LOG_SMS (OID_LOG_SMS,RESPOSTA_ENVIO, NUM_TELEFONE, NUM_MATRICULA, NUM_INSCRICAO, DTA_ENVIO)   VALUES (S_TBG_LOG_SMS.NEXTVAL,:RESPOSTA_ENVIO, :NUM_TELEFONE, :NUM_MATRICULA, :NUM_INSCRICAO, SYSDATE)", new { RESPOSTA_ENVIO, NUM_TELEFONE, NUM_MATRICULA, NUM_INSCRICAO });
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
