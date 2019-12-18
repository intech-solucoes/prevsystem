/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraAssistidoEntidade
    Parametros
        -SQ_PROCESSO:int
*/

SELECT DISTINCT CR.DT_REFERENCIA,
    FF.SQ_PROCESSO
FROM fi_ficha_financ_assistido FF
     INNER JOIN fi_rubrica_folha_pagamento RU ON RU.SQ_RUBRICA = FF.SQ_RUBRICA
     INNER JOIN fi_cronograma_credito CR ON CR.SQ_CRONOGRAMA = FF.SQ_CRONOGRAMA
WHERE FF.SQ_PROCESSO = @SQ_PROCESSO
  AND RU.IR_LANCAMENTO IN ('P', 'D')
  AND RU.EE_INCIDE_LIQUIDO = 'S'
ORDER BY CR.DT_REFERENCIA DESC