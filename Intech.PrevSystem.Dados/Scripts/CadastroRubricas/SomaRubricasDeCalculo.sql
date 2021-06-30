/*Config
    Retorno
        -decimal
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_INSCRICAO:string
        -ANO_COMPETENCIA:string
        -MES_COMPETENCIA:string
        -CD_CALCULO:decimal
        -DT_VIGENCIA:DateTime
*/

SELECT SUM(VALOR_RUBRICA)
FROM   CC_CADASTRO_RUBRICAS
WHERE  ( CD_FUNDACAO = @CD_FUNDACAO )
       AND ( CD_EMPRESA = @CD_EMPRESA )
       AND ( NUM_INSCRICAO = @NUM_INSCRICAO )
       AND ( ANO_COMPETENCIA = @ANO_COMPETENCIA )
       AND ( MES_COMPETENCIA = @MES_COMPETENCIA )
       AND ( CD_RUBRICA IN (SELECT CD_RUBRICA
                            FROM   GB_COMP_RUBRICA AS RC
                            WHERE  ( CD_CALCULO = @CD_CALCULO )
                                   AND ( DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA) AS DATA_VIGENCIA
                                                        FROM   GB_COMP_RUBRICA AS RCC
                                                        WHERE  ( CD_CALCULO = RC.CD_CALCULO )
                                                               AND ( DT_VIGENCIA <= @DT_VIGENCIA )) )) ) 