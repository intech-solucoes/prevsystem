/*Config
    RetornaLista
    Retorno
        -FaixasIRRFEntidade
    Parametros
        -VALOR_FAIXA:decimal
*/

SELECT 
    TB_FAIXAS_IRRF.*, 
    TB_IRRF.VALOR_ABATIMENTO_DEP, 
    TB_IRRF.ABATIMENTO_ACIMA_65ANOS 
FROM   TB_FAIXAS_IRRF 
       INNER JOIN TB_IRRF 
               ON TB_FAIXAS_IRRF.DT_REFERENCIA = TB_IRRF.DT_REFERENCIA 
                  AND TB_FAIXAS_IRRF.TIPO_IRRF = TB_IRRF.TIPO_IRRF 
WHERE  ( TB_FAIXAS_IRRF.TIPO_IRRF = 1 ) 
       AND ( TB_FAIXAS_IRRF.DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1 
                                             FROM   TB_FAIXAS_IRRF AS A 
                                             WHERE  ( TIPO_IRRF = 1 )) ) 
       AND ( TB_IRRF.DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA) AS EXPR1 
                                      FROM   TB_IRRF AS B 
                                      WHERE  ( TIPO_IRRF = 1 )) ) 
       AND ( TB_FAIXAS_IRRF.VALOR_FAIXA >= @VALOR_FAIXA ) 
ORDER  BY TB_FAIXAS_IRRF.VALOR_FAIXA 