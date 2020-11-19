﻿/*Config
    Retorno
        -BoletaEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -DT_INICIO:DateTime
        -DT_REFERENCIA:DateTime
*/

SELECT AM_BOLETA.*,
    TB_PLANOS.DS_PLANO
FROM AM_BOLETA   
     INNER JOIN TB_PLANOS ON TB_PLANOS.CD_FUNDACAO = AM_BOLETA.CD_FUNDACAO AND TB_PLANOS.CD_PLANO = AM_BOLETA.CD_PLANO
WHERE AM_BOLETA.SITUACAO = 2
  AND AM_BOLETA.CD_TIPO_COBRANCA = '02'
  AND AM_BOLETA.DT_PAGTO IS NULL     
  AND AM_BOLETA.CD_FUNDACAO = @CD_FUNDACAO
  AND AM_BOLETA.NUM_INSCRICAO = @NUM_INSCRICAO
  AND AM_BOLETA.DT_INICIO = @DT_INICIO
  AND AM_BOLETA.DT_REFERENCIA = @DT_REFERENCIA