/*Config
    RetornaLista
    Retorno
        -FaixasIRRFEntidade
    Parametros
        -DT_REFERENCIA:DateTime
        -TIPO_IRRF:decimal
*/

SELECT *
FROM   TB_FAIXAS_IRRF
WHERE ( DT_REFERENCIA = @DT_REFERENCIA )
  AND ( TIPO_IRRF = @TIPO_IRRF )
ORDER  BY FAIXA_IRRF 