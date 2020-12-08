/*Config
    RetornaLista
    Retorno
        -FaixaValorContribEntidade
    Parametros
        -CD_TIPO_CONTRIBUICAO:string
        -CD_MANTENEDORA:string
*/

SELECT tb_faixa_valor_contrib.cd_fundacao, 
       tb_faixa_valor_contrib.cd_plano, 
       tb_faixa_valor_contrib.cd_tipo_contribuicao, 
       tb_faixa_valor_contrib.cd_mantenedora, 
       tb_faixa_valor_contrib.ano_ref, 
       tb_faixa_valor_contrib.mes_ref, 
       tb_faixa_valor_contrib.seq_faixa, 
       tb_faixa_valor_contrib.perc_faixa, 
       tb_faixa_valor_contrib.limite_inf_faixa, 
       tb_faixa_valor_contrib.limite_sup_faixa, 
       tb_faixa_valor_contrib.deducao_faixa, 
       tb_faixa_valor_contrib.perc_fundador, 
       tb_faixa_valor_contrib.vl_perc_min, 
       tb_faixa_valor_contrib.vl_perc_max 
FROM   tb_faixa_valor_contrib 
       INNER JOIN (SELECT Max(mes_ref) AS MES_REF, 
                          Max(ano_ref) AS ANO_REF 
                   FROM   tb_faixa_contrib AS TB_FAIXA_CONTRIB_UM 
                   WHERE  ( cd_tipo_contribuicao = @CD_TIPO_CONTRIBUICAO ) 
                          AND ( cd_mantenedora = @CD_MANTENEDORA ) 
                          AND ( ano_ref = (SELECT Max(ano_ref) AS ANO_REF 
                                           FROM   tb_faixa_contrib AS 
                                                  TB_FAIXA_CONTRIB_DOIS 
                                           WHERE  ( cd_tipo_contribuicao = 
                                                    @CD_TIPO_CONTRIBUICAO ) 
                                                  AND ( cd_mantenedora = 
                                                        @CD_MANTENEDORA )) )) AS 
                  TB 
               ON TB.ano_ref = tb_faixa_valor_contrib.ano_ref 
                  AND tb_faixa_valor_contrib.ano_ref = TB.ano_ref 
                  AND tb_faixa_valor_contrib.mes_ref = TB.mes_ref 
WHERE  ( tb_faixa_valor_contrib.cd_tipo_contribuicao = @CD_TIPO_CONTRIBUICAO ) 
       AND ( tb_faixa_valor_contrib.cd_mantenedora = @CD_MANTENEDORA ) 