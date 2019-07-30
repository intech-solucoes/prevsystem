﻿/*Config
    Retorno
        -DateTime
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -SEQ_RECEBEDOR:int
        -CD_PLANO:string
*/

SELECT TOP 1 MAX(DT_REFERENCIA)
FROM GB_FICHA_FINANC_ASSISTIDO
INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR
WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO
  AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO
  AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA
  AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = @SEQ_RECEBEDOR
  AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA
  AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO
  AND NUM_MATRICULA = @NUM_MATRICULA
GROUP BY DT_REFERENCIA
ORDER BY DT_REFERENCIA DESC