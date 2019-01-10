﻿/*Config
    Retorno
        -MargensCalculadasEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_ORIGEM:decimal
        -NUM_MATRICULA:string
        -NUM_SEQ_GR_FAMIL:decimal
*/

SELECT TOP 1 *
FROM   VMP_MARGENS_CALCULADAS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_ORIGEM = @CD_ORIGEM
  AND NUM_MATRICULA = @NUM_MATRICULA
  AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL
ORDER BY DATA_REF DESC