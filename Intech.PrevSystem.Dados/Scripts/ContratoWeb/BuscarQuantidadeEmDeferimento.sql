﻿/*Config
    Retorno
        -int
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT COUNT(*)
FROM CE_CONTRATOS_WEB
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CONTRATO_MIGRADO IN ('N', 'E')