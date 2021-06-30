/*Config
    RetornaLista
    Retorno
        -FatorPlanoBDEntidade
    Parametros
        -DT_VALIDADE:DateTime
        -IDADE_ENTRADA:int
        -IDADE_SAIDA:int
*/

SELECT *
FROM   GB_FATOR_PLANO_BD
WHERE  ( DT_VALIDADE <= @DT_VALIDADE )
       AND ( IDADE_ENTRADA = @IDADE_ENTRADA )
       AND ( IDADE_SAIDA = @IDADE_SAIDA )
       AND ( DT_VALIDADE = (SELECT MAX(DT_VALIDADE) AS DT_VALIDADE
                            FROM   GB_FATOR_PLANO_BD
                            WHERE  IDADE_ENTRADA = @IDADE_ENTRADA
                                   AND IDADE_SAIDA = @IDADE_SAIDA) )