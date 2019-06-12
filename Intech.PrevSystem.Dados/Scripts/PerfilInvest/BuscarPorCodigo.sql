/*Config
    Retorno
        -PerfilInvestEntidade
    Parametros
        -CD_PERFIL_INVEST:string
*/

SELECT *
FROM TB_PERFIL_INVEST
WHERE CD_PERFIL_INVEST = @CD_PERFIL_INVEST