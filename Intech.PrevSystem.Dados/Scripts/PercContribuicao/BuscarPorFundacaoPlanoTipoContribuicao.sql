/*Config
    Retorno
        -PercContribuicaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -CD_TIPO_CONTRIBUICAO:string
*/

SELECT *
FROM WEB_PERC_CONTRIBUICAO
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_PLANO = @CD_PLANO
  AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO