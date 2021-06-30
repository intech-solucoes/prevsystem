/*Config
    RetornaLista
    Retorno
        -RubricaConcessaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_RUBRICA:string
        -ADESAO_PCS:string
        -DT_VIGENCIA:DateTime
*/

SELECT *
FROM   GB_RUBRICA_CONCESSAO AS RC
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_EMPRESA = @CD_EMPRESA )
       AND ( CD_RUBRICA = @CD_RUBRICA )
       AND ( ADESAO_PCS = @ADESAO_PCS )
       AND ( DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA) AS EXPR1
                            FROM   GB_RUBRICA_CONCESSAO AS RCC
                            WHERE  ( CD_FUNDACAO = RC.CD_FUNDACAO )
                                   AND ( CD_EMPRESA = RC.CD_EMPRESA )
                                   AND ( CD_RUBRICA = RC.CD_RUBRICA )
                                   AND ( ADESAO_PCS = RC.ADESAO_PCS )
                                   AND ( DT_VIGENCIA <= @DT_VIGENCIA )) ) 
