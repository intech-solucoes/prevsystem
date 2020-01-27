/*Config
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
        -CD_RUBRICA:string
*/

SELECT MCC.*
FROM GB_MENSAGEM_CCHEQUE MCC
INNER JOIN GB_FICHA_FINANC_ASSISTIDO FF ON FF.CD_EMPRESA = MCC.CD_EMPRESA
                                       AND FF.CD_PLANO = MCC.CD_PLANO
                                       AND FF.CD_ESPECIE = MCC.CD_ESPECIE
                                       AND FF.CD_RUBRICA = MCC.CD_RUBRICA
                                       AND FF.DT_REFERENCIA = MCC.DT_REFERENCIA
                                       AND FF.CD_TIPO_FOLHA = MCC.CD_TIPO_FOLHA
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND DT_REFERENCIA = @DT_REFERENCIA
  AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO
  AND CD_ESPECIE = @CD_ESPECIE
  AND SEQ_RECEBEDOR = @SEQ_RECEBEDOR