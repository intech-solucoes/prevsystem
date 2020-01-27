﻿/*Config
    RetornaLista
    Retorno
        -MensagemCChequeEntidade
    Parametros
        -CD_FUNDACAO:string
        -DT_REFERENCIA:DateTime
        -CD_TIPO_FOLHA:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_ESPECIE:string
        -SEQ_RECEBEDOR:int?
*/

SELECT *
FROM GB_MENSAGEM_CCHEQUE
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND DT_REFERENCIA = @DT_REFERENCIA
  AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO
  AND CD_ESPECIE = @CD_ESPECIE
  AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR