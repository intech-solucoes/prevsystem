/*Config
    RetornaLista
    Retorno
        -IRRFEntidade
    Parametros
        -DT_REFERENCIA:DateTime
        -TIPO_IRRF:decimal
*/

SELECT *
FROM   TB_IRRF
WHERE ( DT_REFERENCIA <= @DT_REFERENCIA )
  AND ( TIPO_IRRF = @TIPO_IRRF )
ORDER  BY DT_REFERENCIA DESC 