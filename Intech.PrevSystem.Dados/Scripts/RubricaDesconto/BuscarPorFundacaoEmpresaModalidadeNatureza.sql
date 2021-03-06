﻿/*Config
    RetornaLista
    Retorno
        -RubricaDescontoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_MODAL:decimal
        -CD_NATUR:decimal
*/

SELECT *
FROM   CE_RUBRICA_DESCONTO
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_EMPRESA = @CD_EMPRESA )
       AND ( CD_MODAL = @CD_MODAL )
       AND ( CD_NATUR = @CD_NATUR )
ORDER  BY SEQ_RUBRICA 
