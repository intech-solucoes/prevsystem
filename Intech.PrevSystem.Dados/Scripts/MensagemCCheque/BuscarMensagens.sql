/*Config
    RetornaLista
    Retorno
        -MensagemCChequeEntidade
    Parametros
        -CD_FUNDACAO:string
        -DT_REFERENCIA:DateTime
        -CD_TIPO_FOLHA:string
*/

SELECT *
FROM GB_MENSAGEM_CCHEQUE
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND DT_REFERENCIA = @DT_REFERENCIA
  AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA