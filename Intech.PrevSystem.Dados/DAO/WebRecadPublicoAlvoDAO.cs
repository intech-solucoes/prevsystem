﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebRecadPublicoAlvoDAO : BaseDAO<WebRecadPublicoAlvoEntidade>
	{
		public WebRecadPublicoAlvoDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual bool AtualizarUsuarioAcao( decimal OID_RECAD_PUBLICO_ALVO,  string IND_SITUACAO_RECAD,  string NOM_USUARIO_ACAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<bool>("UPDATE WEB_RECAD_PUBLICO_ALVO  	SET IND_SITUACAO_RECAD = @IND_SITUACAO_RECAD, NOM_USUARIO_ACAO = @NOM_USUARIO_ACAO  	WHERE OID_RECAD_PUBLICO_ALVO = @OID_RECAD_PUBLICO_ALVO", new { OID_RECAD_PUBLICO_ALVO, IND_SITUACAO_RECAD, NOM_USUARIO_ACAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<bool>("UPDATE WEB_RECAD_PUBLICO_ALVO SET IND_SITUACAO_RECAD=:IND_SITUACAO_RECAD, NOM_USUARIO_ACAO=:NOM_USUARIO_ACAO WHERE OID_RECAD_PUBLICO_ALVO=:OID_RECAD_PUBLICO_ALVO", new { OID_RECAD_PUBLICO_ALVO, IND_SITUACAO_RECAD, NOM_USUARIO_ACAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadParticipanteDadosEntidade> BuscarDadosPorCdFundacaoNumInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadParticipanteDadosEntidade>("SELECT FN.CD_FUNDACAO,         0 AS SEQ_RECEBEDOR,         FN.NUM_INSCRICAO,          FN.CD_EMPRESA,          EE_EMP.SIGLA_ENTID AS NOM_EMPRESA,         FN.NUM_MATRICULA,          EE.NOME_ENTID,         DP.DT_NASCIMENTO,         EE.CPF_CGC,         DP.NU_IDENT,         DP.ORG_EMIS_IDENT,         DP.DT_EMIS_IDENT,         DP.NATURALIDADE,         DP.UF_NATURALIDADE,         DP.NOME_MAE,         DP.NOME_PAI,         DP.CD_ESTADO_CIVIL,         DP.NOME_CONJUGE,         DP.CPF_CONJUGE,         EE.CEP_ENTID,         EE.END_ENTID,         EE.NR_END_ENTID,         EE.COMP_END_ENTID,         EE.BAIRRO_ENTID,         EE.CID_ENTID,         EE.UF_ENTID,                DP.CD_PAIS,         DP.EMAIL_AUX,         DP.FONE_CELULAR,         EE.FONE_ENTID,         EE.NUM_BANCO,         EE.NUM_AGENCIA,         EE.NUM_CONTA,         EE.POLIT_EXP           FROM CS_FUNCIONARIO FN       INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID      INNER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = FN.COD_ENTID      INNER JOIN TB_EMPRESA EP ON EP.CD_FUNDACAO = FN.CD_FUNDACAO AND EP.CD_EMPRESA = FN.CD_EMPRESA      INNER JOIN EE_ENTIDADE EE_EMP ON EE_EMP.COD_ENTID = EP.COD_ENTID  WHERE FN.CD_FUNDACAO = @CD_FUNDACAO    AND FN.NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadParticipanteDadosEntidade>("SELECT FN.CD_FUNDACAO, 0 AS SEQ_RECEBEDOR, FN.NUM_INSCRICAO, FN.CD_EMPRESA, EE_EMP.SIGLA_ENTID AS NOM_EMPRESA, FN.NUM_MATRICULA, EE.NOME_ENTID, DP.DT_NASCIMENTO, EE.CPF_CGC, DP.NU_IDENT, DP.ORG_EMIS_IDENT, DP.DT_EMIS_IDENT, DP.NATURALIDADE, DP.UF_NATURALIDADE, DP.NOME_MAE, DP.NOME_PAI, DP.CD_ESTADO_CIVIL, DP.NOME_CONJUGE, DP.CPF_CONJUGE, EE.CEP_ENTID, EE.END_ENTID, EE.NR_END_ENTID, EE.COMP_END_ENTID, EE.BAIRRO_ENTID, EE.CID_ENTID, EE.UF_ENTID, DP.CD_PAIS, DP.EMAIL_AUX, DP.FONE_CELULAR, EE.FONE_ENTID, EE.NUM_BANCO, EE.NUM_AGENCIA, EE.NUM_CONTA, EE.POLIT_EXP FROM CS_FUNCIONARIO  FN  INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID INNER  JOIN CS_DADOS_PESSOAIS   DP  ON DP.COD_ENTID=FN.COD_ENTID INNER  JOIN TB_EMPRESA   EP  ON EP.CD_FUNDACAO=FN.CD_FUNDACAO AND EP.CD_EMPRESA=FN.CD_EMPRESA INNER  JOIN EE_ENTIDADE   EE_EMP  ON EE_EMP.COD_ENTID=EP.COD_ENTID WHERE FN.CD_FUNDACAO=:CD_FUNDACAO AND FN.NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadParticipanteDadosEntidade> BuscarDadosPorCdFundacaoSeqRecebedor(string CD_FUNDACAO, decimal SEQ_RECEBEDOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadParticipanteDadosEntidade>("SELECT RB.CD_FUNDACAO,         RB.SEQ_RECEBEDOR,         RB.NUM_INSCRICAO,          RB.CD_EMPRESA,          EE_EMP.SIGLA_ENTID AS NOM_EMPRESA,         RB.NUM_MATRICULA,          EE.NOME_ENTID,         DP.DT_NASCIMENTO,         EE.CPF_CGC,         DP.NU_IDENT,         DP.ORG_EMIS_IDENT,         DP.DT_EMIS_IDENT,         DP.NATURALIDADE,         DP.UF_NATURALIDADE,         DP.NOME_MAE,         DP.NOME_PAI,         DP.CD_ESTADO_CIVIL,         DP.NOME_CONJUGE,         DP.CPF_CONJUGE,         EE.CEP_ENTID,         EE.END_ENTID,         EE.NR_END_ENTID,         EE.COMP_END_ENTID,         EE.BAIRRO_ENTID,         EE.CID_ENTID,         EE.UF_ENTID,                DP.CD_PAIS,         DP.EMAIL_AUX,         DP.FONE_CELULAR,         EE.FONE_ENTID,         EE.NUM_BANCO,         EE.NUM_AGENCIA,         EE.NUM_CONTA,         EE.POLIT_EXP           FROM GB_RECEBEDOR_BENEFICIO RB       INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID      INNER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = RB.COD_ENTID      INNER JOIN TB_EMPRESA EP ON EP.CD_FUNDACAO = RB.CD_FUNDACAO AND EP.CD_EMPRESA = RB.CD_EMPRESA      INNER JOIN EE_ENTIDADE EE_EMP ON EE_EMP.COD_ENTID = EP.COD_ENTID  WHERE RB.CD_FUNDACAO = @CD_FUNDACAO    AND RB.SEQ_RECEBEDOR = @SEQ_RECEBEDOR", new { CD_FUNDACAO, SEQ_RECEBEDOR }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadParticipanteDadosEntidade>("SELECT RB.CD_FUNDACAO, RB.SEQ_RECEBEDOR, RB.NUM_INSCRICAO, RB.CD_EMPRESA, EE_EMP.SIGLA_ENTID AS NOM_EMPRESA, RB.NUM_MATRICULA, EE.NOME_ENTID, DP.DT_NASCIMENTO, EE.CPF_CGC, DP.NU_IDENT, DP.ORG_EMIS_IDENT, DP.DT_EMIS_IDENT, DP.NATURALIDADE, DP.UF_NATURALIDADE, DP.NOME_MAE, DP.NOME_PAI, DP.CD_ESTADO_CIVIL, DP.NOME_CONJUGE, DP.CPF_CONJUGE, EE.CEP_ENTID, EE.END_ENTID, EE.NR_END_ENTID, EE.COMP_END_ENTID, EE.BAIRRO_ENTID, EE.CID_ENTID, EE.UF_ENTID, DP.CD_PAIS, DP.EMAIL_AUX, DP.FONE_CELULAR, EE.FONE_ENTID, EE.NUM_BANCO, EE.NUM_AGENCIA, EE.NUM_CONTA, EE.POLIT_EXP FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID INNER  JOIN CS_DADOS_PESSOAIS   DP  ON DP.COD_ENTID=RB.COD_ENTID INNER  JOIN TB_EMPRESA   EP  ON EP.CD_FUNDACAO=RB.CD_FUNDACAO AND EP.CD_EMPRESA=RB.CD_EMPRESA INNER  JOIN EE_ENTIDADE   EE_EMP  ON EE_EMP.COD_ENTID=EP.COD_ENTID WHERE RB.CD_FUNDACAO=:CD_FUNDACAO AND RB.SEQ_RECEBEDOR=:SEQ_RECEBEDOR", new { CD_FUNDACAO, SEQ_RECEBEDOR }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<PlanoEntidade> BuscarPlanoPorCdFundacaoSeqRecebedor(string CD_FUNDACAO, decimal SEQ_RECEBEDOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT PL.DS_PLANO,  	   PL.CD_PLANO,         EB.DS_ESPECIE,  	   EB.CD_ESPECIE    FROM GB_PROCESSOS_BENEFICIO PB      INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = PB.CD_FUNDACAO AND RB.NUM_INSCRICAO = PB.NUM_INSCRICAO      INNER JOIN TB_PLANOS PL ON PL.CD_FUNDACAO = PB.CD_FUNDACAO AND PL.CD_PLANO= PB.CD_PLANO      INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE  WHERE RB.CD_FUNDACAO = @CD_FUNDACAO    AND RB.SEQ_RECEBEDOR = @SEQ_RECEBEDOR    AND ( (RB.CD_TIPO_RECEBEDOR = 'A' AND EB.CD_GRUPO_ESPECIE IN ('1','3'))         OR (RB.CD_TIPO_RECEBEDOR = 'G' AND EB.CD_GRUPO_ESPECIE IN ('2','4')))  	   AND PB.CD_SITUACAO NOT IN ('03', '04', '06')", new { CD_FUNDACAO, SEQ_RECEBEDOR }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoEntidade>("SELECT PL.DS_PLANO, PL.CD_PLANO, EB.DS_ESPECIE, EB.CD_ESPECIE FROM GB_PROCESSOS_BENEFICIO  PB  INNER  JOIN GB_RECEBEDOR_BENEFICIO   RB  ON RB.CD_FUNDACAO=PB.CD_FUNDACAO AND RB.NUM_INSCRICAO=PB.NUM_INSCRICAO INNER  JOIN TB_PLANOS   PL  ON PL.CD_FUNDACAO=PB.CD_FUNDACAO AND PL.CD_PLANO=PB.CD_PLANO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE RB.CD_FUNDACAO=:CD_FUNDACAO AND RB.SEQ_RECEBEDOR=:SEQ_RECEBEDOR AND ((RB.CD_TIPO_RECEBEDOR='A' AND EB.CD_GRUPO_ESPECIE IN ('1', '3')) OR (RB.CD_TIPO_RECEBEDOR='G' AND EB.CD_GRUPO_ESPECIE IN ('2', '4'))) AND PB.CD_SITUACAO NOT  IN ('03', '04', '06')", new { CD_FUNDACAO, SEQ_RECEBEDOR }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadPublicoAlvoEntidade> BuscarPorCpfDataAtualAssistido(string CPF, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*,         CA.NOM_CAMPANHA,         CA.DTA_TERMINO,         RB.CD_TIPO_RECEBEDOR,         RB.NUM_MATRICULA,                  CASE            WHEN CA.DTA_INICIO <= @DATA_ATUAL            AND CA.DTA_TERMINO >= @DATA_ATUAL            AND CA.IND_ATIVO = 'SIM'              THEN 'S'            ELSE 'N'         END AS PRAZO_RECADASTRAMENTO,    	   'ASSISTIDO' AS 'GRUPO_RECADASTRAMENTO'    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = PA.CD_FUNDACAO        AND RB.SEQ_RECEBEDOR = PA.SEQ_RECEBEDOR      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  WHERE EE.CPF_CGC = @CPF    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO DESC", new { CPF, DATA_ATUAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.NOM_CAMPANHA, CA.DTA_TERMINO, RB.CD_TIPO_RECEBEDOR, RB.NUM_MATRICULA, CASE  WHEN CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' THEN 'S' ELSE 'N' END  AS PRAZO_RECADASTRAMENTO, 'ASSISTIDO' AS GRUPO_RECADASTRAMENTO FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN GB_RECEBEDOR_BENEFICIO   RB  ON RB.CD_FUNDACAO=PA.CD_FUNDACAO AND RB.SEQ_RECEBEDOR=PA.SEQ_RECEBEDOR INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA WHERE EE.CPF_CGC=:CPF AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO DESC", new { CPF, DATA_ATUAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadPublicoAlvoEntidade> BuscarPorCpfDataAtualAssistidoGrupoPrevirb(string CPF, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT  	PA.*,  	CA.DTA_TERMINO,  	RB.CD_TIPO_RECEBEDOR,  	CASE  		   WHEN SP.CD_CATEGORIA = '1' AND SP.CD_SIT_PLANO = '29' THEN 'SALDADO_EXTRAORD'  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO = '20' THEN 'ASSISTIDO_ESPECIAL'  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 'PENSIONISTA'  	       WHEN SP.CD_CATEGORIA = '4' THEN 'ASSISTIDO'  		   ELSE 'ATIVO'  	   END AS 'GRUPO_RECADASTRAMENTO',  	   CASE  		   WHEN SP.CD_CATEGORIA = '1' AND SP.CD_SIT_PLANO = '29' THEN 4  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO = '20' THEN 3  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 2  	       WHEN SP.CD_CATEGORIA = '4' THEN 1  		   ELSE 5  	   END AS 'CD_GRUPO_RECADASTRAMENTO'    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = PA.CD_FUNDACAO        AND RB.SEQ_RECEBEDOR = PA.SEQ_RECEBEDOR      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  	INNER JOIN CS_PLANOS_VINC PV ON PV.CD_FUNDACAO = PA.CD_FUNDACAO    AND PV.NUM_INSCRICAO = PA.NUM_INSCRICAO  INNER JOIN TB_SIT_PLANO SP ON SP.CD_SIT_PLANO = PV.CD_SIT_PLANO  WHERE EE.CPF_CGC = @CPF    AND CA.DTA_INICIO <= @DATA_ATUAL    AND CA.DTA_TERMINO >= @DATA_ATUAL    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO, CD_GRUPO_RECADASTRAMENTO DESC", new { CPF, DATA_ATUAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.DTA_TERMINO, RB.CD_TIPO_RECEBEDOR, CASE  WHEN SP.CD_CATEGORIA='1' AND SP.CD_SIT_PLANO='29' THEN 'SALDADO_EXTRAORD' WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO='20' THEN 'ASSISTIDO_ESPECIAL' WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 'PENSIONISTA' WHEN SP.CD_CATEGORIA='4' THEN 'ASSISTIDO' ELSE 'ATIVO' END  AS GRUPO_RECADASTRAMENTO, CASE  WHEN SP.CD_CATEGORIA='1' AND SP.CD_SIT_PLANO='29' THEN 4 WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO='20' THEN 3 WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 2 WHEN SP.CD_CATEGORIA='4' THEN 1 ELSE 5 END  AS CD_GRUPO_RECADASTRAMENTO FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN GB_RECEBEDOR_BENEFICIO   RB  ON RB.CD_FUNDACAO=PA.CD_FUNDACAO AND RB.SEQ_RECEBEDOR=PA.SEQ_RECEBEDOR INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA INNER  JOIN CS_PLANOS_VINC   PV  ON PV.CD_FUNDACAO=PA.CD_FUNDACAO AND PV.NUM_INSCRICAO=PA.NUM_INSCRICAO INNER  JOIN TB_SIT_PLANO   SP  ON SP.CD_SIT_PLANO=PV.CD_SIT_PLANO WHERE EE.CPF_CGC=:CPF AND CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO, CD_GRUPO_RECADASTRAMENTO DESC", new { CPF, DATA_ATUAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadPublicoAlvoEntidade> BuscarPorCpfDataAtualAtivo(string CPF, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*,         CA.NOM_CAMPANHA,  	   CA.DTA_TERMINO,  	   FN.NUM_MATRICULA,           	   CASE            WHEN CA.DTA_INICIO <= @DATA_ATUAL            AND CA.DTA_TERMINO >= @DATA_ATUAL            AND CA.IND_ATIVO = 'SIM'              THEN 'S'            ELSE 'N'         END AS PRAZO_RECADASTRAMENTO,    	   'ATIVO' AS 'GRUPO_RECADASTRAMENTO'    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = PA.CD_FUNDACAO  		AND FN.NUM_INSCRICAO = PA.NUM_INSCRICAO      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  WHERE EE.CPF_CGC = @CPF    AND CA.DTA_INICIO <= @DATA_ATUAL    AND CA.DTA_TERMINO >= @DATA_ATUAL    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO DESC", new { CPF, DATA_ATUAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.NOM_CAMPANHA, CA.DTA_TERMINO, FN.NUM_MATRICULA, CASE  WHEN CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' THEN 'S' ELSE 'N' END  AS PRAZO_RECADASTRAMENTO, 'ATIVO' AS GRUPO_RECADASTRAMENTO FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=PA.CD_FUNDACAO AND FN.NUM_INSCRICAO=PA.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA WHERE EE.CPF_CGC=:CPF AND CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO DESC", new { CPF, DATA_ATUAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadPublicoAlvoEntidade> BuscarPorCpfDataAtualAtivoGrupoPrevirb(string CPF, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*,  	CA.DTA_TERMINO,  	CASE  		   WHEN SP.CD_CATEGORIA = '1' AND SP.CD_SIT_PLANO = '29' THEN 'SALDADO_EXTRAORD'  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO = '20' THEN 'ASSISTIDO_ESPECIAL'  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 'PENSIONISTA'  	       WHEN SP.CD_CATEGORIA = '4' THEN 'ASSISTIDO'  		   ELSE 'ATIVO'  	   END AS 'GRUPO_RECADASTRAMENTO',  	   CASE  		   WHEN SP.CD_CATEGORIA = '1' AND SP.CD_SIT_PLANO = '29' THEN 4  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO = '20' THEN 3  		   WHEN SP.CD_CATEGORIA = '4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 2  	       WHEN SP.CD_CATEGORIA = '4' THEN 1  		   ELSE 5  	   END AS 'CD_GRUPO_RECADASTRAMENTO'    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = PA.CD_FUNDACAO  		AND FN.NUM_INSCRICAO = PA.NUM_INSCRICAO      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  	INNER JOIN CS_PLANOS_VINC PV ON PV.CD_FUNDACAO = PA.CD_FUNDACAO  	  AND PV.NUM_INSCRICAO = PA.NUM_INSCRICAO  	INNER JOIN TB_SIT_PLANO SP ON SP.CD_SIT_PLANO = PV.CD_SIT_PLANO  WHERE EE.CPF_CGC = @CPF    AND CA.DTA_INICIO <= @DATA_ATUAL    AND CA.DTA_TERMINO >= @DATA_ATUAL    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO, CD_GRUPO_RECADASTRAMENTO DESC", new { CPF, DATA_ATUAL }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.DTA_TERMINO, CASE  WHEN SP.CD_CATEGORIA='1' AND SP.CD_SIT_PLANO='29' THEN 'SALDADO_EXTRAORD' WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO='20' THEN 'ASSISTIDO_ESPECIAL' WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 'PENSIONISTA' WHEN SP.CD_CATEGORIA='4' THEN 'ASSISTIDO' ELSE 'ATIVO' END  AS GRUPO_RECADASTRAMENTO, CASE  WHEN SP.CD_CATEGORIA='1' AND SP.CD_SIT_PLANO='29' THEN 4 WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO='20' THEN 3 WHEN SP.CD_CATEGORIA='4' AND SP.CD_SIT_PLANO IN ('22', '40', '42', '58') THEN 2 WHEN SP.CD_CATEGORIA='4' THEN 1 ELSE 5 END  AS CD_GRUPO_RECADASTRAMENTO FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=PA.CD_FUNDACAO AND FN.NUM_INSCRICAO=PA.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA INNER  JOIN CS_PLANOS_VINC   PV  ON PV.CD_FUNDACAO=PA.CD_FUNDACAO AND PV.NUM_INSCRICAO=PA.NUM_INSCRICAO INNER  JOIN TB_SIT_PLANO   SP  ON SP.CD_SIT_PLANO=PV.CD_SIT_PLANO WHERE EE.CPF_CGC=:CPF AND CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO, CD_GRUPO_RECADASTRAMENTO DESC", new { CPF, DATA_ATUAL }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<WebRecadPublicoAlvoEntidade> BuscarPorInscricao(string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT *    FROM WEB_RECAD_PUBLICO_ALVO PA  WHERE NUM_INSCRICAO = @NUM_INSCRICAO", new { NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<WebRecadPublicoAlvoEntidade>("SELECT * FROM WEB_RECAD_PUBLICO_ALVO  PA  WHERE NUM_INSCRICAO=:NUM_INSCRICAO", new { NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual WebRecadPublicoAlvoEntidade BuscarPorOidDataAtual(string OID_RECAD_PUBLICO_ALVO, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadPublicoAlvoEntidade>("SELECT PA.*,  	   CA.DTA_TERMINO,  	   RB.CD_TIPO_RECEBEDOR,         RB.NUM_MATRICULA    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = PA.CD_FUNDACAO        AND RB.SEQ_RECEBEDOR = PA.SEQ_RECEBEDOR      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  WHERE PA.OID_RECAD_PUBLICO_ALVO = @OID_RECAD_PUBLICO_ALVO    AND CA.DTA_INICIO <= @DATA_ATUAL    AND CA.DTA_TERMINO >= @DATA_ATUAL    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO DESC", new { OID_RECAD_PUBLICO_ALVO, DATA_ATUAL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.DTA_TERMINO, RB.CD_TIPO_RECEBEDOR, RB.NUM_MATRICULA FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN GB_RECEBEDOR_BENEFICIO   RB  ON RB.CD_FUNDACAO=PA.CD_FUNDACAO AND RB.SEQ_RECEBEDOR=PA.SEQ_RECEBEDOR INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA WHERE PA.OID_RECAD_PUBLICO_ALVO=:OID_RECAD_PUBLICO_ALVO AND CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO DESC", new { OID_RECAD_PUBLICO_ALVO, DATA_ATUAL });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual WebRecadPublicoAlvoEntidade BuscarPorOidDataAtualAtivo(string OID_RECAD_PUBLICO_ALVO, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadPublicoAlvoEntidade>("SELECT PA.*,  	   CA.DTA_TERMINO,         FN.NUM_MATRICULA    FROM WEB_RECAD_PUBLICO_ALVO PA      INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = PA.CD_FUNDACAO  		AND FN.NUM_INSCRICAO = PA.NUM_INSCRICAO      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID      INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA  WHERE PA.OID_RECAD_PUBLICO_ALVO = @OID_RECAD_PUBLICO_ALVO    AND CA.DTA_INICIO <= @DATA_ATUAL    AND CA.DTA_TERMINO >= @DATA_ATUAL    AND CA.IND_ATIVO = 'SIM'    ORDER BY DTA_INICIO DESC", new { OID_RECAD_PUBLICO_ALVO, DATA_ATUAL });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadPublicoAlvoEntidade>("SELECT PA.*, CA.DTA_TERMINO, FN.NUM_MATRICULA FROM WEB_RECAD_PUBLICO_ALVO  PA  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=PA.CD_FUNDACAO AND FN.NUM_INSCRICAO=PA.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=FN.COD_ENTID INNER  JOIN WEB_RECAD_CAMPANHA   CA  ON CA.OID_RECAD_CAMPANHA=PA.OID_RECAD_CAMPANHA WHERE PA.OID_RECAD_PUBLICO_ALVO=:OID_RECAD_PUBLICO_ALVO AND CA.DTA_INICIO<=:DATA_ATUAL AND CA.DTA_TERMINO>=:DATA_ATUAL AND CA.IND_ATIVO='SIM' ORDER BY DTA_INICIO DESC", new { OID_RECAD_PUBLICO_ALVO, DATA_ATUAL });
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
