﻿/*Config
    Retorno
        -int
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:int
*/

SELECT TOP 1 NUM_CONTRATO
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND ANO_CONTRATO = @ANO_CONTRATO
ORDER BY NUM_CONTRATO DESC