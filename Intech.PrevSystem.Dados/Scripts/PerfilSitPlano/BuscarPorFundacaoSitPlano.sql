/*Config
    RetornaLista
    Retorno
        -PerfilSitPlanoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_SIT_PLANO:string
*/

SELECT *
FROM TB_PERFIL_SIT_PLANO
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_SIT_PLANO = @CD_SIT_PLANO