﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraAssistidoEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -SEQ_RECEBEDOR:int
*/

SELECT PL.DS_PLANO, 
       EB.DS_ESPECIE,
       FF.DT_REFERENCIA,
       TF.CD_TIPO_FOLHA,
       TF.DS_TIPO_FOLHA,
       SUM(CASE
                WHEN RP.RUBRICA_PROV_DESC = 'P' THEN FF.VALOR_MC
                ELSE 0
            END) AS VAL_BRUTO,
       SUM(CASE
                WHEN RP.RUBRICA_PROV_DESC = 'D' THEN FF.VALOR_MC
                ELSE 0
            END) AS VAL_DESCONTOS,
       SUM(CASE
                WHEN RP.RUBRICA_PROV_DESC = 'P' THEN FF.VALOR_MC
                ELSE FF.VALOR_MC * -1
            END) AS VAL_LIQUIDO
  FROM GB_FICHA_FINANC_ASSISTIDO FF
       INNER JOIN GB_PROCESSOS_BENEFICIO PB ON
            PB.CD_FUNDACAO  = FF.CD_FUNDACAO AND
            PB.CD_EMPRESA   = FF.CD_EMPRESA AND
            PB.CD_PLANO     = FF.CD_PLANO AND
            PB.CD_ESPECIE   = FF.CD_ESPECIE AND
            PB.NUM_PROCESSO = FF.NUM_PROCESSO AND 
            PB.ANO_PROCESSO = FF.ANO_PROCESSO 
       INNER JOIN TB_TIPO_FOLHA TF ON 
            TF.CD_TIPO_FOLHA = FF.CD_TIPO_FOLHA
       INNER JOIN TB_PLANOS PL ON 
            PL.CD_FUNDACAO = FF.CD_FUNDACAO AND
            PL.CD_PLANO = FF.CD_PLANO
       INNER JOIN GB_ESPECIE_BENEFICIO EB ON
            EB.CD_ESPECIE = FF.CD_ESPECIE
       INNER JOIN GB_RUBRICAS_PREVIDENCIAL RP ON
            RP.CD_RUBRICA = FF.CD_RUBRICA
WHERE PB.CD_FUNDACAO = @CD_FUNDACAO
  AND PB.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.SEQ_RECEBEDOR = @SEQ_RECEBEDOR
GROUP BY PL.DS_PLANO, 
       EB.DS_ESPECIE,
       FF.DT_REFERENCIA,
       TF.CD_TIPO_FOLHA,
       TF.DS_TIPO_FOLHA
ORDER BY PL.DS_PLANO, 
       EB.DS_ESPECIE,
       FF.DT_REFERENCIA DESC,
       TF.DS_TIPO_FOLHA