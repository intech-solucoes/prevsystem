/*Config
    Retorno
        -SitPlanoEntidade
    Parametros
        -CD_SIT_PLANO:string
*/

SELECT *
FROM TB_SIT_PLANO
WHERE CD_SIT_PLANO = @CD_SIT_PLANO