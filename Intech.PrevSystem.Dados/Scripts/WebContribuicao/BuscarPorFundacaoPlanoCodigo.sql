/*Config
    RetornaLista
    Retorno
        -WebContribuicaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -COD_GRUPO_CONTRIBUICAO:string
*/


SELECT *
FROM   WEB_CONTRIBUICAO
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_PLANO = @CD_PLANO )
       AND ( COD_GRUPO_CONTRIBUICAO = @COD_GRUPO_CONTRIBUICAO ) 