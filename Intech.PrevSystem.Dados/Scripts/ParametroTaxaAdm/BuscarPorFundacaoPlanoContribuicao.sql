/*Config
    RetornaLista
    Retorno
        -ParametroTaxaAdmEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -CD_TIPO_CONTRIBUICAO:string
*/

SELECT *
FROM   TB_PARAMETRO_TAXA_ADM
WHERE  CD_FUNDACAO = @CD_FUNDACAO
       AND CD_PLANO = @CD_PLANO
       AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO
       AND ( '' + ANO_REF + MES_REF = (SELECT MAX('' + ANO_REF + MES_REF)
                                       FROM   TB_PARAMETRO_TAXA_ADM PARAMETRO_TAXA_ADM
                                       WHERE  PARAMETRO_TAXA_ADM.CD_FUNDACAO = @CD_FUNDACAO
                                              AND PARAMETRO_TAXA_ADM.CD_PLANO = @CD_PLANO
                                              AND PARAMETRO_TAXA_ADM.CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO) ) 
