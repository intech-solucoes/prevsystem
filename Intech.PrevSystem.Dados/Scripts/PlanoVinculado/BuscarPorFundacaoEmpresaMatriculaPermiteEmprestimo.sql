﻿/*Config
    RetornaLista
    Retorno
        -PlanoVinculadoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
*/

SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, 
       TB_CATEGORIA.CD_CATEGORIA, 
       TB_CATEGORIA.DS_CATEGORIA, 
       TB_SIT_PLANO.DS_SIT_PLANO,
       TB_PLANOS.DS_PLANO,
       TB_PLANOS.COD_CNPB,
       CS_PLANOS_VINC.*
FROM   CS_PLANOS_VINC 
INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO 
                    AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO 
INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO 
LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST 
INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO 
INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA 
INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_PLANO = CS_PLANOS_VINC.CD_PLANO
WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO ) 
       AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA ) 
       AND ( CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA )
       AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )
       AND ( TB_CATEGORIA.PERMITE_EMPRESTIMO = 'S')
       AND ( TB_EMPRESA_PLANOS.PERMITE_EMPRESTIMO = 'S' )
       AND ( TB_EMPRESA_PLANOS.CD_EMPRESA = @CD_EMPRESA )