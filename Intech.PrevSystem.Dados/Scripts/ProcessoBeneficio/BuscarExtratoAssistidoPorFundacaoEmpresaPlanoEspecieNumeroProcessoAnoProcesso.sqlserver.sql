﻿/*Config
    RetornaLista
    Retorno
        -dynamic
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_ESPECIE:string
        -NUM_PROCESSO:decimal
		-ANO_PROCESSO:string
*/

SELECT PB.CD_FUNDACAO,
     PB.CD_EMPRESA,
     PB.CD_PLANO,
     PB.CD_ESPECIE,
     PB.ANO_PROCESSO,
     PB.NUM_PROCESSO,     
     PB.NUM_INSCRICAO,     
     FN.NUM_MATRICULA,
     EB.DS_ESPECIE, 
     PL.DS_PLANO,
     PL.COD_CNPB,
     ST.DS_SITUACAO,
     HP.DT_INICIO_FUND,  
     PB.SALDO_INICIAL AS SALDO_INICIAL,
     PB.SALDO_ATUAL AS SALDO_ATUAL_GERAL,
     ISNULL(PB.VL_PERC_RESGATE,0) AS VL_PERC_RESGATE,
     ISNULL(PB.VL_PARC_RESGATE,0) AS VL_PARC_RESGATE,
     PB.SALDO_INICIAL - ISNULL(PB.VL_PARC_RESGATE,0) AS SALDO_REVERSAO_BENEFICIO,
     PB.NUM_TOT_PARCELAS,
     PB.NUM_PARCELAS_PAG,
     HS.DT_REFERENCIA,
     HS.VALOR_REAIS,
     HS.VALOR_COTAS,
     HS.SALDO_ATUAL,
     HS.SALDO_ATUAL * IV.VALOR_IND AS SALDO_ATUAL_REAIS,
     IV.DT_IND,
     IV.VALOR_IND,
     HS.VALOR_REAIS / HS.VALOR_COTAS AS VALOR_IND2,
     ISNULL(TCD.CD_TIPO_CALC_CD, OPR.CD_OPCAO_RECEB) AS CD_TIPO_RENDA,
     ISNULL(TCD.DS_TIPO_CALC_CD, OPR.DS_OPCAO_RECEB) AS TIPO_RENDA,
     (ISNULL(IV.VALOR_IND,0) / ISNULL(IVA.VALOR_IND,1) - 1) * 100 AS RENTABILIDADE
FROM   GB_PROCESSOS_BENEFICIO PB
INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE 
INNER JOIN GB_SITUACAO ST ON ST.CD_SITUACAO = PB.CD_SITUACAO
INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO   = PB.CD_FUNDACAO
    AND FN.NUM_INSCRICAO = PB.NUM_INSCRICAO 
INNER JOIN GB_HIST_SALDO HS ON PB.CD_FUNDACAO  = HS.CD_FUNDACAO 
    AND PB.CD_EMPRESA   = HS.CD_EMPRESA 
    AND PB.CD_PLANO     = HS.CD_PLANO 
    AND PB.CD_ESPECIE   = HS.CD_ESPECIE 
    AND PB.NUM_PROCESSO = HS.NUM_PROCESSO 
    AND PB.ANO_PROCESSO = HS.ANO_PROCESSO 
INNER JOIN GB_HIST_PROCESSOS HP ON PB.CD_FUNDACAO  = HP.CD_FUNDACAO 
    AND PB.CD_EMPRESA   = HP.CD_EMPRESA 
    AND PB.CD_PLANO     = HP.CD_PLANO 
    AND PB.CD_ESPECIE   = HP.CD_ESPECIE 
    AND PB.NUM_PROCESSO = HP.NUM_PROCESSO 
    AND PB.ANO_PROCESSO = HP.ANO_PROCESSO 
INNER JOIN GB_HIST_RENDAS HR ON PB.CD_FUNDACAO  = HR.CD_FUNDACAO 
    AND PB.CD_EMPRESA   = HR.CD_EMPRESA 
    AND PB.CD_PLANO     = HR.CD_PLANO 
    AND PB.CD_ESPECIE   = HR.CD_ESPECIE 
    AND PB.NUM_PROCESSO = HR.NUM_PROCESSO 
    AND PB.ANO_PROCESSO = HR.ANO_PROCESSO 
INNER JOIN GB_OPCAO_RECEBIMENTO OPR ON OPR.CD_OPCAO_RECEB = HR.CD_OPCAO_RECEB    
INNER JOIN TB_PLANOS PL ON PL.CD_FUNDACAO = PB.CD_FUNDACAO
    AND PL.CD_PLANO = PB.CD_PLANO
INNER JOIN TB_EMPRESA_PLANOS EP ON EP.CD_FUNDACAO = PB.CD_FUNDACAO
    AND EP.CD_EMPRESA = PB.CD_EMPRESA
      AND EP.CD_PLANO = PB.CD_PLANO
LEFT OUTER JOIN TB_IND_VALORES IV ON IV.COD_IND = EP.IND_RESERVA_POUP
LEFT OUTER JOIN TB_IND_VALORES IVA ON IVA.COD_IND = EP.IND_RESERVA_POUP
LEFT OUTER JOIN GB_TIPO_CALC_CD TCD ON TCD.CD_TIPO_CALC_CD = PB.CD_TIPO_CALC_CD
WHERE  HR.DT_INIC_VALIDADE = (SELECT MAX(HR2.DT_INIC_VALIDADE)
                                FROM GB_HIST_RENDAS HR2 
                               WHERE PB.CD_FUNDACAO  = HR2.CD_FUNDACAO 
                                 AND PB.CD_EMPRESA   = HR2.CD_EMPRESA 
                                 AND PB.CD_PLANO     = HR2.CD_PLANO 
                                 AND PB.CD_ESPECIE   = HR2.CD_ESPECIE 
                                 AND PB.NUM_PROCESSO = HR2.NUM_PROCESSO 
                                 AND PB.ANO_PROCESSO = HR2.ANO_PROCESSO)
  AND IV.DT_IND = (SELECT MAX(IV2.DT_IND)
                     FROM TB_IND_VALORES IV2
                    WHERE IV2.COD_IND = IV.COD_IND
                      AND MONTH(IV2.DT_IND) = MONTH(HS.DT_REFERENCIA)
                      AND YEAR(IV2.DT_IND) = YEAR(HS.DT_REFERENCIA))                                
  AND IVA.DT_IND = (SELECT MAX(IV3.DT_IND)
                     FROM TB_IND_VALORES IV3
                    WHERE IV3.COD_IND = IVA.COD_IND
                      AND MONTH(IV3.DT_IND) = MONTH(DATEADD(MONTH, -1, HS.DT_REFERENCIA))
                      AND YEAR(IV3.DT_IND) = YEAR(DATEADD(MONTH, -1, HS.DT_REFERENCIA)))                                
   AND PB.CD_FUNDACAO  = @CD_FUNDACAO
   AND PB.CD_EMPRESA   = @CD_EMPRESA
   AND PB.CD_PLANO     = @CD_PLANO
   AND PB.CD_ESPECIE   = @CD_ESPECIE
   AND PB.NUM_PROCESSO = @NUM_PROCESSO
   AND PB.ANO_PROCESSO = @ANO_PROCESSO
ORDER BY HS.DT_REFERENCIA DESC;