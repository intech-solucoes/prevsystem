/*CONFIG
    RetornaLista
    Retorno
        -PortabilidadeExtEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT *
FROM   CC_PORTABILIDADE_EXT
WHERE  CD_FUNDACAO = @CD_FUNDACAO
       AND NUM_INSCRICAO = @NUM_INSCRICAO
       AND CD_PLANO = @CD_PLANO 
