/*Config
    Retorno
        -IRRFEntidade
    Parametros
        -DT_REFERENCIA:DateTime
*/

SELECT *
FROM TB_IRRF
WHERE DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA)
                         FROM TB_IRRF
                        WHERE DT_REFERENCIA <= @DT_REFERENCIA)