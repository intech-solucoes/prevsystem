/*Config
    Retorno
        -CronogProcEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_TIPO_FOLHA:string
        -DT_REFERENCIA:DateTime
*/

SELECT *
FROM GB_CRONOG_PROC
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_TIPO_FOLHA = @CD_TIPO_FOLHA
  AND DT_REFERENCIA = @DT_REFERENCIA