#region Usings
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
    public abstract class MensagemDAO : BaseDAO<MensagemEntidade>
    {
        
		public virtual IEnumerable<MensagemEntidade> BuscarPorFundacaoEmpresaPlanoSitPlanoCodEntid(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_SIT_PLANO, string COD_ENTID)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<MensagemEntidade>("SELECT MSG.*, 	ENT_FUND.NOME_ENTID AS NOM_FUNDACAO, 	ENT_EMP.NOME_ENTID AS NOM_EMPRESA, 	PL.DS_PLANO, 	SIT_PL.DS_SIT_PLANO, 	FUNC.NUM_MATRICULA FROM WEB_MENSAGEM MSG INNER JOIN TB_FUNDACAO FUND ON FUND.CD_FUNDACAO = MSG.CD_FUNDACAO INNER JOIN EE_ENTIDADE ENT_FUND ON ENT_FUND.COD_ENTID = FUND.COD_ENTID  LEFT JOIN TB_EMPRESA EMP ON EMP.CD_EMPRESA = MSG.CD_EMPRESA LEFT JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID  LEFT JOIN TB_PLANOS PL ON PL.CD_PLANO = MSG.CD_PLANO LEFT JOIN TB_SIT_PLANO SIT_PL ON SIT_PL.CD_SIT_PLANO = MSG.CD_SIT_PLANO LEFT JOIN CS_FUNCIONARIO FUNC ON FUNC.COD_ENTID = MSG.COD_ENTID WHERE DTA_EXPIRACAO > GETDATE()   AND (MSG.CD_FUNDACAO = @CD_FUNDACAO)   AND ((MSG.CD_EMPRESA = @CD_EMPRESA) OR (@CD_EMPRESA IS NULL OR MSG.CD_EMPRESA IS NULL))   AND ((MSG.CD_PLANO = @CD_PLANO) OR (@CD_PLANO IS NULL OR MSG.CD_PLANO IS NULL))   AND ((MSG.CD_SIT_PLANO = @CD_SIT_PLANO) OR (@CD_SIT_PLANO IS NULL OR MSG.CD_SIT_PLANO IS NULL))   AND ((MSG.COD_ENTID = @COD_ENTID) OR (MSG.COD_ENTID IS NULL))", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<MensagemEntidade>("SELECT MSG.*, ENT_FUND.NOME_ENTID AS NOM_FUNDACAO, ENT_EMP.NOME_ENTID AS NOM_EMPRESA, PL.DS_PLANO, SIT_PL.DS_SIT_PLANO, FUNC.NUM_MATRICULA FROM WEB_MENSAGEM  MSG  INNER  JOIN TB_FUNDACAO   FUND  ON FUND.CD_FUNDACAO=MSG.CD_FUNDACAO INNER  JOIN EE_ENTIDADE   ENT_FUND  ON ENT_FUND.COD_ENTID=FUND.COD_ENTID LEFT JOIN TB_EMPRESA   EMP  ON EMP.CD_EMPRESA=MSG.CD_EMPRESA LEFT JOIN EE_ENTIDADE   ENT_EMP  ON ENT_EMP.COD_ENTID=EMP.COD_ENTID LEFT JOIN TB_PLANOS   PL  ON PL.CD_PLANO=MSG.CD_PLANO LEFT JOIN TB_SIT_PLANO   SIT_PL  ON SIT_PL.CD_SIT_PLANO=MSG.CD_SIT_PLANO LEFT JOIN CS_FUNCIONARIO   FUNC  ON FUNC.COD_ENTID=MSG.COD_ENTID WHERE DTA_EXPIRACAO>SYSDATE AND (MSG.CD_FUNDACAO=:CD_FUNDACAO) AND ((MSG.CD_EMPRESA=:CD_EMPRESA) OR (:CD_EMPRESA IS NULL  OR MSG.CD_EMPRESA IS NULL )) AND ((MSG.CD_PLANO=:CD_PLANO) OR (:CD_PLANO IS NULL  OR MSG.CD_PLANO IS NULL )) AND ((MSG.CD_SIT_PLANO=:CD_SIT_PLANO) OR (:CD_SIT_PLANO IS NULL  OR MSG.CD_SIT_PLANO IS NULL )) AND ((MSG.COD_ENTID=:COD_ENTID) OR (MSG.COD_ENTID IS NULL ))", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<MensagemEntidade> BuscarTodas()
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<MensagemEntidade>("SELECT MSG.*, 	ENT_FUND.NOME_ENTID AS NOM_FUNDACAO, 	ENT_EMP.NOME_ENTID AS NOM_EMPRESA, 	PL.DS_PLANO, 	SIT_PL.DS_SIT_PLANO, 	FUNC.NUM_MATRICULA FROM WEB_MENSAGEM MSG INNER JOIN TB_FUNDACAO FUND ON FUND.CD_FUNDACAO = MSG.CD_FUNDACAO INNER JOIN EE_ENTIDADE ENT_FUND ON ENT_FUND.COD_ENTID = FUND.COD_ENTID  LEFT JOIN TB_EMPRESA EMP ON EMP.CD_EMPRESA = MSG.CD_EMPRESA LEFT JOIN EE_ENTIDADE ENT_EMP ON ENT_EMP.COD_ENTID = EMP.COD_ENTID  LEFT JOIN TB_PLANOS PL ON PL.CD_PLANO = MSG.CD_PLANO LEFT JOIN TB_SIT_PLANO SIT_PL ON SIT_PL.CD_SIT_PLANO = MSG.CD_SIT_PLANO LEFT JOIN CS_FUNCIONARIO FUNC ON FUNC.COD_ENTID = MSG.COD_ENTID  ORDER BY OID_MENSAGEM", new {  });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<MensagemEntidade>("SELECT MSG.*, ENT_FUND.NOME_ENTID AS NOM_FUNDACAO, ENT_EMP.NOME_ENTID AS NOM_EMPRESA, PL.DS_PLANO, SIT_PL.DS_SIT_PLANO, FUNC.NUM_MATRICULA FROM WEB_MENSAGEM  MSG  INNER  JOIN TB_FUNDACAO   FUND  ON FUND.CD_FUNDACAO=MSG.CD_FUNDACAO INNER  JOIN EE_ENTIDADE   ENT_FUND  ON ENT_FUND.COD_ENTID=FUND.COD_ENTID LEFT JOIN TB_EMPRESA   EMP  ON EMP.CD_EMPRESA=MSG.CD_EMPRESA LEFT JOIN EE_ENTIDADE   ENT_EMP  ON ENT_EMP.COD_ENTID=EMP.COD_ENTID LEFT JOIN TB_PLANOS   PL  ON PL.CD_PLANO=MSG.CD_PLANO LEFT JOIN TB_SIT_PLANO   SIT_PL  ON SIT_PL.CD_SIT_PLANO=MSG.CD_SIT_PLANO LEFT JOIN CS_FUNCIONARIO   FUNC  ON FUNC.COD_ENTID=MSG.COD_ENTID ORDER BY OID_MENSAGEM", new {  });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual MensagemEntidade Insert(string TXT_TITULO, string TXT_CORPO, DateTime DTA_MENSAGEM, DateTime? DTA_EXPIRACAO, string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string CD_SIT_PLANO, decimal? COD_ENTID, string IND_MOBILE, string IND_PORTAL, string IND_EMAIL, string IND_SMS)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.QuerySingleOrDefault<MensagemEntidade>("INSERT INTO WEB_MENSAGEM(TXT_TITULO, TXT_CORPO, DTA_MENSAGEM, DTA_EXPIRACAO, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID, IND_MOBILE, IND_PORTAL, IND_EMAIL, IND_SMS) VALUES (@TXT_TITULO,@TXT_CORPO,@DTA_MENSAGEM,@DTA_EXPIRACAO,@CD_FUNDACAO,@CD_EMPRESA,@CD_PLANO,@CD_SIT_PLANO,@COD_ENTID,@IND_MOBILE,@IND_PORTAL,@IND_EMAIL,@IND_SMS)", new { TXT_TITULO, TXT_CORPO, DTA_MENSAGEM, DTA_EXPIRACAO, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID, IND_MOBILE, IND_PORTAL, IND_EMAIL, IND_SMS });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.QuerySingleOrDefault<MensagemEntidade>("INSERT INTO WEB_MENSAGEM (OID_MENSAGEM,TXT_TITULO, TXT_CORPO, DTA_MENSAGEM, DTA_EXPIRACAO, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID, IND_MOBILE, IND_PORTAL, IND_EMAIL, IND_SMS) VALUES (S_WEB_MENSAGEM.NEXTVAL,:TXT_TITULO, :TXT_CORPO, :DTA_MENSAGEM, :DTA_EXPIRACAO, :CD_FUNDACAO, :CD_EMPRESA, :CD_PLANO, :CD_SIT_PLANO, :COD_ENTID, :IND_MOBILE, :IND_PORTAL, :IND_EMAIL, :IND_SMS) RETURNING OID_MENSAGEM INTO :PK", new { TXT_TITULO, TXT_CORPO, DTA_MENSAGEM, DTA_EXPIRACAO, CD_FUNDACAO, CD_EMPRESA, CD_PLANO, CD_SIT_PLANO, COD_ENTID, IND_MOBILE, IND_PORTAL, IND_EMAIL, IND_SMS });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
