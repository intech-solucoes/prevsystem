/*==============================================================*/
/* Cria uma campanha de recadastramento e                       */
/* popula o publico alvo                                        */
/*==============================================================*/

/*CRIA CAMPANHA DE RECADASTRAMENTO DE TESTES*/
INSERT INTO WEB_RECAD_CAMPANHA (OID_RECAD_CAMPANHA, CD_FUNDACAO, NOM_CAMPANHA, DTA_INICIO, DTA_TERMINO, IND_ATIVO)
VALUES (S_WEB_RECAD_CAMPANHA.NEXTVAL, '01','CAMPANHA DE RECADASTRAMENTO TESTES DESENVOLVIMENTO', '01-04-20', '01-06-20', 'SIM');

--SELECT * FROM WEB_RECAD_CAMPANHA 

/* CARGA NO PUBLICO ALVO

PÚBLICO ALVO:
a) Todos os Recebedores que estejam com a Situação: EM MANUTENCAO.
b) Todos os Recebedores com data de Concessão de Benefício do mês anterior ao do inicio do recadastramento, por exemplo, se iniciarmos o recadastramento em 04/2020, considerar os processos concedidos em 03/2020.
c) Todos os Recebedores que estejam com a Situação: SUSPENSO e com os Motivos: “1-FALTA DE RECADASTRAMENTO”, “3-FALECIDO - AGUARDANDO PENSÃO”, “5-CONTA CORRENTE NÃO INFORMADA” e “6-OBITO DA PENSIONISTA”.
*/

INSERT INTO WEB_RECAD_PUBLICO_ALVO (OID_RECAD_PUBLICO_ALVO, OID_RECAD_CAMPANHA, CD_FUNDACAO, NUM_INSCRICAO, SEQ_RECEBEDOR, IND_SITUACAO_RECAD, DTA_EFETIVACAO, NOM_USUARIO_ACAO)
(SELECT S_WEB_RECAD_PUBLICO_ALVO.NEXTVAL, T.OID_RECAD_CAMPANHA, T.CD_FUNDACAO, T.NUM_INSCRICAO, T.SEQ_RECEBEDOR, T.IND_SITUACAO_RECAD, T.DTA_EFETIVACAO, T.NOM_USUARIO_ACAO
   FROM (SELECT DISTINCT 1 AS OID_RECAD_CAMPANHA /*VERIFICAR O OID GERADO NO INSERT ANTERIOR*/, RB.CD_FUNDACAO, RB.NUM_INSCRICAO, RB.SEQ_RECEBEDOR, 'AGU' AS IND_SITUACAO_RECAD, NULL AS DTA_EFETIVACAO, 'INTECH' AS NOM_USUARIO_ACAO
           FROM GB_RECEBEDOR_BENEFICIO RB
                INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO
          WHERE PB.DT_CONCESSAO <= '01-03-20'
            AND PB.CD_SITUACAO IN ('09', '07')) T);
  
--SELECT * FROM WEB_RECAD_PUBLICO_ALVO  

