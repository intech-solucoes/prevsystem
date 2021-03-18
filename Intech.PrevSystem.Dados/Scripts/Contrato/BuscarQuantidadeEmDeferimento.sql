/*Config
    Retorno
        -int
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT COUNT(*)
FROM CE_CONTRATOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_SITUACAO = 1