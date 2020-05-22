﻿/*Config
    RetornaLista
    Retorno
        -PlanoVinculadoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CPF:string
*/

SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, 
       TB_CATEGORIA.CD_CATEGORIA, 
       TB_CATEGORIA.DS_CATEGORIA, 
       TB_PLANOS.DS_PLANO,
       CS_PLANOS_VINC.*
FROM   CS_PLANOS_VINC 
INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO 
                    AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO 
INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO 
LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST 
INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO 
INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID
INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA 
WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA ) 
       AND ( EE_ENTIDADE.CPF_CGC = @CPF )
