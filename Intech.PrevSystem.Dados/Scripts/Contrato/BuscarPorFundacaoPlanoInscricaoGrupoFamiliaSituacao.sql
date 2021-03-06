﻿/*Config
    RetornaLista
    Retorno
        -ContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -NUM_SEQ_GR_FAMIL:string
        -CD_SITUACAO:decimal
*/

SELECT * 
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND NUM_SEQ_GR_FAMIL = @NUM_SEQ_GR_FAMIL
  AND CD_SITUACAO = @CD_SITUACAO