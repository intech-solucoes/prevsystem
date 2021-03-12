﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN 0 ELSE CASE WHEN FF.CD_OPERACAO = 'D' THEN FF.CONTRIB_PARTICIPANTE * -1 ELSE FF.CONTRIB_PARTICIPANTE END END) AS CONTRIB_PARTICIPANTE,
       SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN 0 ELSE CASE WHEN FF.CD_OPERACAO = 'D' THEN FF.CONTRIB_EMPRESA * -1 ELSE FF.CONTRIB_EMPRESA END END) AS CONTRIB_EMPRESA,
       SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN 0 ELSE CASE WHEN FF.CD_OPERACAO = 'D' THEN ISNULL(FF.QTD_COTA_RP_PARTICIPANTE,0) * -1 ELSE ISNULL(FF.QTD_COTA_RP_PARTICIPANTE,0) END END) AS QTD_COTA_RP_PARTICIPANTE,
       SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN 0 ELSE CASE WHEN FF.CD_OPERACAO = 'D' THEN ISNULL(FF.QTD_COTA_RP_EMPRESA,0) * -1 ELSE ISNULL(FF.QTD_COTA_RP_EMPRESA,0) END END) AS QTD_COTA_RP_EMPRESA,
       SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN CASE WHEN FF.CD_OPERACAO = 'D' THEN FF.CONTRIB_PARTICIPANTE * -1 ELSE FF.CONTRIB_PARTICIPANTE END ELSE 0 END) AS CONTRIB_PORTABILIDADE,
       SUM(CASE TC.IND_PORTABILIDADE WHEN 'S' THEN CASE WHEN FF.CD_OPERACAO = 'D' THEN FF.QTD_COTA_RP_PARTICIPANTE * -1 ELSE FF.QTD_COTA_RP_PARTICIPANTE END ELSE 0 END) AS QTD_COTA_RP_PORTABILIDADE
FROM CC_FICHA_FINANCEIRA FF
    INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
	INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = FF.CD_FUNDACAO AND FN.NUM_INSCRICAO = FF.NUM_INSCRICAO
    INNER JOIN TB_EMPRESA_PLANOS EP ON EP.CD_FUNDACAO = FF.CD_FUNDACAO
       AND EP.CD_EMPRESA = FN.CD_EMPRESA
       AND EP.CD_PLANO   = FF.CD_PLANO
    LEFT OUTER JOIN TB_IND_VALORES IV ON IV.COD_IND = EP.IND_RESERVA_POUP
WHERE FF.CD_FUNDACAO   = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO      = @CD_PLANO
  AND TC.COMPOE_SALDO_BENEFICIO = 'S'
  AND IV.DT_IND = (SELECT MAX(IV2.DT_IND)
                     FROM TB_IND_VALORES IV2
                    WHERE IV2.COD_IND = IV.COD_IND
                      AND MONTH(IV2.DT_IND) = MONTH(DATEADD(MONTH, 1, DATEFROMPARTS(CAST(FF.ANO_REF AS INT) , CAST(FF.MES_REF AS INT), 1 )))
                      AND YEAR(IV2.DT_IND)  = YEAR(DATEADD(MONTH, 1, DATEFROMPARTS(CAST(FF.ANO_REF AS INT) , CAST(FF.MES_REF AS INT), 1 ))));