/*Config
    RetornaLista
    Retorno
        -TipoCalculoFaixasEntidade
    Parametros
        -CD_CALCULO:int
*/

SELECT *
FROM   GB_TIPO_CALCULO_FAIXAS
WHERE  ( CD_CALCULO = @CD_CALCULO )
       AND ( DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1
                              FROM   GB_TIPO_CALCULO
                              WHERE  ( CD_CALCULO = @CD_CALCULO )) ) 