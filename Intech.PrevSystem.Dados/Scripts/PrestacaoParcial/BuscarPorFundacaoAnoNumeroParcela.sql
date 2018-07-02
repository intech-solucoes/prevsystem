/*Config
    RetornaLista
    Retorno
        -PrestacaoParcialEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
        -PARCELA:decimal
*/

SELECT *
FROM CE_PRESTACOES_PARCIAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND ANO_CONTRATO = @ANO_CONTRATO
  AND NUM_CONTRATO = @NUM_CONTRATO
  AND PARCELA = @PARCELA