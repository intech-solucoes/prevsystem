﻿/*Config
    Retorno
        -decimal
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT SUM(CASE 
              WHEN FF.CD_OPERACAO = 'C' THEN FF.QTD_COTA_RP_PARTICIPANTE * PR.VLR_PERC_PARTICIPANTE / 100
              WHEN FF.CD_OPERACAO = 'D' THEN FF.QTD_COTA_RP_PARTICIPANTE * PR.VLR_PERC_PARTICIPANTE / -100
           END) AS QTD_COTA_RP
  FROM CC_FICHA_FINANCEIRA FF
        INNER JOIN DR_PARAMETROS_RESGATE PR ON
            PR.CD_FUNDACAO = FF.CD_FUNDACAO AND
            PR.CD_PLANO = FF.CD_PLANO AND
            PR.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO AND 
            PR.CD_TIPO_RESGATE = '01'
 WHERE FF.CD_FUNDACAO   = @CD_FUNDACAO
   AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
   AND FF.CD_PLANO      = @CD_PLANO