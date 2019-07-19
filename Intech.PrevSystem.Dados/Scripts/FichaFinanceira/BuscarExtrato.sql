﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -DT_INICIO:DateTime
        -DT_FIM:DateTime
*/

SELECT TC.DS_TIPO_CONTRIBUICAO,
       TC.CALC_MARGEM_CONSIG,
       FI.* 
FROM CC_FICHA_FINANCEIRA FI
INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO
WHERE FI.CD_FUNDACAO = @CD_FUNDACAO
  AND FI.CD_PLANO = @CD_PLANO
  AND FI.NUM_INSCRICAO = @NUM_INSCRICAO
  AND '' + FI.ANO_REF + '-' + FI.MES_REF + '-01' BETWEEN @DT_INICIO AND @DT_FIM 
ORDER BY FI.ANO_REF, 
         FI.MES_REF,
         FI.ANO_COMP, 
         FI.MES_COMP,
         FI.CD_TIPO_CONTRIBUICAO