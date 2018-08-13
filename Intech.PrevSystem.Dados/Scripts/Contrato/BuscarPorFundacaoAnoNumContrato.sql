/*Config
    Retorno
        -ContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:string
        -NUM_CONTRATO:string
*/

SELECT * 
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND ANO_CONTRATO = @ANO_CONTRATO
  AND NUM_CONTRATO = @NUM_CONTRATO