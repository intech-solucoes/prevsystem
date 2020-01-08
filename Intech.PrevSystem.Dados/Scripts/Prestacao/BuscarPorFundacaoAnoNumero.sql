/*Config
    RetornaLista
    Retorno
        -PrestacaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:string
        -NUM_CONTRATO:string
*/

SELECT * 
FROM CE_PRESTACOES PR
WHERE PR.CD_FUNDACAO = @CD_FUNDACAO
  AND PR.ANO_CONTRATO = @ANO_CONTRATO
  AND PR.NUM_CONTRATO = @NUM_CONTRATO
ORDER BY PR.SEQ_PREST