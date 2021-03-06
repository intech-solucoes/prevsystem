﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraAssistidoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT FF.*,
       RP.DS_RUBRICA,
       RP.RUBRICA_PROV_DESC
FROM GB_FICHA_FINANC_ASSISTIDO FF
  INNER JOIN GB_PROCESSOS_BENEFICIO PB 
      ON PB.CD_FUNDACAO = FF.CD_FUNDACAO
        AND PB.CD_EMPRESA  = FF.CD_EMPRESA
        AND PB.CD_PLANO = FF.CD_PLANO
        AND PB.CD_ESPECIE = FF.CD_ESPECIE
        AND PB.ANO_PROCESSO = FF.ANO_PROCESSO
        AND PB.NUM_PROCESSO = FF.NUM_PROCESSO
  INNER JOIN GB_RUBRICAS_PREVIDENCIAL RP ON RP.CD_RUBRICA = FF.CD_RUBRICA  
WHERE PB.CD_FUNDACAO = @CD_FUNDACAO
  AND PB.NUM_INSCRICAO = @NUM_INSCRICAO
  AND PB.CD_PLANO = @CD_PLANO
  AND FF.CD_RUBRICA IN ('7403', '7402', '7400', '7401', '2076', '2077', '2074', '2075', '7404')
ORDER BY DT_REFERENCIA DESC;