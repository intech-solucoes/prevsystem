/*==============================================================*/
/* Cria uma campanha de recadastramento e                       */
/* popula o publico alvo                                        */
/* Query para ser utilizada em base SQL SERVER                  */
/*==============================================================*/

set dateformat dmy;


/*CRIA CAMPANHA DE RECADASTRAMENTO DE TESTES*/
--SELECT * FROM WEB_RECAD_CAMPANHA
INSERT INTO WEB_RECAD_CAMPANHA (CD_FUNDACAO, NOM_CAMPANHA, DTA_INICIO, DTA_TERMINO, IND_ATIVO)
VALUES ('01','CAMPANHA DE RECADASTRAMENTO TESTES DESENVOLVIMENTO', '01/01/2020', '31/12/2020', 'SIM');


/* 
CARGA NO PUBLICO ALVO
*/

--ASSISTIDOS/PENSIONISTAS
INSERT INTO WEB_RECAD_PUBLICO_ALVO (OID_RECAD_CAMPANHA, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR, IND_SITUACAO_RECAD, DTA_EFETIVACAO, NOM_USUARIO_ACAO)
(SELECT DISTINCT 1 AS OID_RECAD_CAMPANHA /*VERIFICAR O OID GERADO NO INSERT ANTERIOR*/, RB.CD_FUNDACAO, RB.NUM_INSCRICAO, RB.SEQ_RECEBEDOR, 'AGU' AS IND_SITUACAO_RECAD, NULL AS DTA_EFETIVACAO, 'INTECH' AS NOM_USUARIO_ACAO
   FROM GB_RECEBEDOR_BENEFICIO RB
            INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO
    AND PB.CD_SITUACAO IN ('09', '07'));

--ATIVOS
INSERT INTO WEB_RECAD_PUBLICO_ALVO (OID_RECAD_CAMPANHA, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR, IND_SITUACAO_RECAD, DTA_EFETIVACAO, NOM_USUARIO_ACAO)
SELECT DISTINCT 1 AS OID_RECAD_CAMPANHA /*VERIFICAR O OID GERADO NO INSERT ANTERIOR*/, FN.CD_FUNDACAO, FN.NUM_INSCRICAO, 0, 'AGU' AS IND_SITUACAO_RECAD, NULL AS DTA_EFETIVACAO, 'INTECH' AS NOM_USUARIO_ACAO
   FROM CS_FUNCIONARIO FN
            INNER JOIN CS_PLANOS_VINC PV ON PV.CD_FUNDACAO = FN.CD_FUNDACAO AND PV.NUM_INSCRICAO = FN.NUM_INSCRICAO
			INNER JOIN TB_SIT_PLANO SP ON SP.CD_SIT_PLANO = PV.CD_SIT_PLANO
    WHERE SP.CD_CATEGORIA IN ('1', '3', '6')
      AND FN.NUM_INSCRICAO NOT IN (SELECT NUM_INSCRICAO FROM WEB_RECAD_PUBLICO_ALVO)
  
--SELECT * FROM WEB_RECAD_PUBLICO_ALVO  
