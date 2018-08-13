/*Config
    RetornaLista
    Retorno
        -ContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_SITUACAO:string
*/

SELECT * 
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_SITUACAO = @CD_SITUACAO