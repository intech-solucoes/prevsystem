using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebRelacionamentoDAO : BaseDAO<WebRelacionamentoEntidade>
	{
		public virtual List<WebRelacionamentoEntidade> BuscarPorOidAssunto(decimal @OID_ASSUNTO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRelacionamentoEntidade>("SELECT *     FROM WEB_RELACIONAMENTO WR         JOIN WEB_ASSUNTO WA ON WR.OID_ASSUNTO = WA.OID_ASSUNTO  WHERE WR.OID_ASSUNTO = @OID_ASSUNTO", new { @OID_ASSUNTO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRelacionamentoEntidade>("SELECT * FROM WEB_RELACIONAMENTO  WR   JOIN WEB_ASSUNTO   WA  ON WR.OID_ASSUNTO=WA.OID_ASSUNTO WHERE WR.OID_ASSUNTO=:OID_ASSUNTO", new { @OID_ASSUNTO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual void Insert(string CD_FUNDACAO, string COD_CPF, DateTime DTA_ENVIO, string TXT_EMAIL_DESTINATARIO, string TXT_EMAIL_REMETENTE, decimal OID_ASSUNTO, string TXT_MENSAGEM, string TXT_IPV4, string TXT_IPV6, string TXT_DISPOSITIVO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_RELACIONAMENTO   (  	 CD_FUNDACAO  	,COD_CPF  	,DTA_ENVIO  	,TXT_EMAIL_DESTINATARIO  	,TXT_EMAIL_REMETENTE  	,OID_ASSUNTO  	,TXT_MENSAGEM  	,TXT_IPV4  	,TXT_IPV6  	,TXT_DISPOSITIVO  )  VALUES (  	 @CD_FUNDACAO  	,@COD_CPF  	,@DTA_ENVIO  	,@TXT_EMAIL_DESTINATARIO  	,@TXT_EMAIL_REMETENTE  	,@OID_ASSUNTO  	,@TXT_MENSAGEM  	,@TXT_IPV4  	,@TXT_IPV6  	,@TXT_DISPOSITIVO  )", new { CD_FUNDACAO, COD_CPF, DTA_ENVIO, TXT_EMAIL_DESTINATARIO, TXT_EMAIL_REMETENTE, OID_ASSUNTO, TXT_MENSAGEM, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO WEB_RELACIONAMENTO (OID_RELACIONAMENTO,CD_FUNDACAO, COD_CPF, DTA_ENVIO, TXT_EMAIL_DESTINATARIO, TXT_EMAIL_REMETENTE, OID_ASSUNTO, TXT_MENSAGEM, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO) VALUES (S_WEB_RELACIONAMENTO.NEXTVAL,:CD_FUNDACAO, :COD_CPF, :DTA_ENVIO, :TXT_EMAIL_DESTINATARIO, :TXT_EMAIL_REMETENTE, :OID_ASSUNTO, :TXT_MENSAGEM, :TXT_IPV4, :TXT_IPV6, :TXT_DISPOSITIVO)", new { CD_FUNDACAO, COD_CPF, DTA_ENVIO, TXT_EMAIL_DESTINATARIO, TXT_EMAIL_REMETENTE, OID_ASSUNTO, TXT_MENSAGEM, TXT_IPV4, TXT_IPV6, TXT_DISPOSITIVO });
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
