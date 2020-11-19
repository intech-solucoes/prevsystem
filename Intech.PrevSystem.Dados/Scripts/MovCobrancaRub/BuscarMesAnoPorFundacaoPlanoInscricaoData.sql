/*Config
    RetornaLista
    Retorno
        -MovCobrancaRubEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -DT_REFERENCIA:DateTime
 */

SELECT DISTINCT mes_comp, 
                ano_comp 
FROM   am_mov_cobranca_rub 
WHERE  cd_fundacao = @CD_FUNDACAO 
       AND cd_plano = @CD_PLANO 
       AND num_inscricao = @NUM_INSCRICAO 
       AND dt_referencia = @DT_REFERENCIA 
       AND cd_rubrica_cobranca NOT IN (SELECT DISTINCT cd_rubrica_cobranca 
                                       FROM   am_rubrica_contrib 
                                       WHERE  cd_fundacao = @CD_FUNDACAO 
                                              AND cd_tipo_contribuicao IN 
                                                  (SELECT DISTINCT cd_contrib_juros 
                                                   FROM   am_parametro 
                                                   WHERE  cd_contrib_juros IS NOT NULL 
                                                          AND cd_fundacao = @CD_FUNDACAO) 
                                       UNION 
                                       SELECT DISTINCT cd_rubrica_cobranca 
                                       FROM   am_rubrica_contrib 
                                       WHERE  cd_fundacao = @CD_FUNDACAO 
                                              AND cd_tipo_contribuicao IN 
                                                  (SELECT DISTINCT cd_contrib_multa 
                                                   FROM   am_parametro 
                                                   WHERE  cd_contrib_multa IS NOT NULL 
                                                          AND cd_fundacao = @CD_FUNDACAO) 
                                       UNION 
                                       SELECT DISTINCT cd_rubrica_cobranca 
                                       FROM   am_rubrica_contrib 
                                       WHERE  cd_fundacao = @CD_FUNDACAO 
                                              AND cd_tipo_contribuicao IN 
                                                  (SELECT DISTINCT cd_contrib_atul_monet 
                                                   FROM   am_parametro 
                                                   WHERE  cd_contrib_atul_monet IS NOT NULL 
                                                          AND cd_fundacao = @CD_FUNDACAO)) 
ORDER  BY ano_comp, 
          mes_comp 