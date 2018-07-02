﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -ANO_REF:string
*/

SELECT DISTINCT 
       MES_REF,
       SUM(CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE,
       SUM(CONTRIB_EMPRESA) AS CONTRIB_EMPRESA,
       0 + SUM(CONTRIB_PARTICIPANTE) + SUM(CONTRIB_EMPRESA) AS TOTAL_CONTRIB,
       0 + SUM(QTD_COTA_RP_PARTICIPANTE) + SUM(QTD_COTA_RP_EMPRESA) AS QTD_COTA
 FROM CC_FICHA_FINANCEIRA FI
WHERE FI.CD_FUNDACAO = @CD_FUNDACAO
  AND FI.CD_PLANO = @CD_PLANO
  AND FI.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FI.ANO_REF = @ANO_REF
GROUP BY MES_REF
ORDER BY FI.MES_REF