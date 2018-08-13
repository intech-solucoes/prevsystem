/*Config
    RetornaLista
    Retorno
        -ContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT * 
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND NUM_INSCRICAO = @NUM_INSCRICAO