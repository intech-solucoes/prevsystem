/*Config
    Retorno
        -ParametroInstalacaoEntidade
    Parametros
        -CD_FUNDACAO:string
*/

SELECT *
FROM   TB_PARAMETRO_INSTALACAO
WHERE  CD_FUNDACAO = @CD_FUNDACAO 