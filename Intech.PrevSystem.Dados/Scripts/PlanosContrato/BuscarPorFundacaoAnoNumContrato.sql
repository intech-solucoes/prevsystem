/*Config
    RetornaLista
    Retorno
        -PlanosContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
*/

SELECT *
FROM CE_PLANOS_CONTRATO
 WHERE CD_FUNDACAO = @CD_FUNDACAO
   AND ANO_CONTRATO = @ANO_CONTRATO 
   AND NUM_CONTRATO = @NUM_CONTRATO
ORDER BY DATA_INSCRICAO DESC