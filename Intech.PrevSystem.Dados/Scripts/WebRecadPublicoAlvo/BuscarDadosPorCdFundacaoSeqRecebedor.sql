﻿/*Config
    RetornaLista
    Retorno
        -WebRecadParticipanteDadosEntidade
    Parametros
        -CD_FUNDACAO:string
		-SEQ_RECEBEDOR:decimal
*/

SELECT RB.CD_FUNDACAO,
       RB.SEQ_RECEBEDOR,
       RB.NUM_INSCRICAO, 
       RB.CD_EMPRESA, 
       EE_EMP.SIGLA_ENTID AS NOM_EMPRESA,
       RB.NUM_MATRICULA, 
       EE.NOME_ENTID,
       DP.DT_NASCIMENTO,
       EE.CPF_CGC,
       DP.NU_IDENT,
       DP.ORG_EMIS_IDENT,
       DP.DT_EMIS_IDENT,
       DP.NATURALIDADE,
       DP.UF_NATURALIDADE,
       DP.NOME_MAE,
       DP.NOME_PAI,
       DP.CD_ESTADO_CIVIL,
       DP.NOME_CONJUGE,
       DP.CPF_CONJUGE,
       EE.CEP_ENTID,
       EE.END_ENTID,
       EE.NR_END_ENTID,
       EE.COMP_END_ENTID,
       EE.BAIRRO_ENTID,
       EE.CID_ENTID,
       EE.UF_ENTID,       
       DP.CD_PAIS,
       DP.EMAIL_AUX,
       DP.FONE_CELULAR,
       EE.FONE_ENTID,
       EE.NUM_BANCO,
       EE.NUM_AGENCIA,
       EE.NUM_CONTA,
       EE.POLIT_EXP       
  FROM GB_RECEBEDOR_BENEFICIO RB 
    INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID
    INNER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = RB.COD_ENTID
    INNER JOIN TB_EMPRESA EP ON EP.CD_FUNDACAO = RB.CD_FUNDACAO AND EP.CD_EMPRESA = RB.CD_EMPRESA
    INNER JOIN EE_ENTIDADE EE_EMP ON EE_EMP.COD_ENTID = EP.COD_ENTID
WHERE RB.CD_FUNDACAO = @CD_FUNDACAO
  AND RB.SEQ_RECEBEDOR = @SEQ_RECEBEDOR