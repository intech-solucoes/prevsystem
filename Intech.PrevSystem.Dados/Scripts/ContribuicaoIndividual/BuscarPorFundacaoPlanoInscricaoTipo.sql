/*Config
    Retorno
        -ContribuicaoIndividualEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -CD_TIPO_CONTRIBUICAO:string
*/

SELECT *
 FROM CS_CONTRIB_INDIVIDUAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO