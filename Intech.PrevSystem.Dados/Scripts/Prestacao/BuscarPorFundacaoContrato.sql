/*Config
    RetornaLista
    Retorno
        -PrestacaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
*/

SELECT *
FROM CE_PRESTACOES
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND ANO_CONTRATO = @ANO_CONTRATO
  AND NUM_CONTRATO = @NUM_CONTRATO
ORDER BY SEQ_PREST