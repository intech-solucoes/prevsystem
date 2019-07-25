/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -ANOMES_INICIO:string
        -ANOMES_FIM:string
        -CD_TIPO_RESGATE:string
*/

SELECT TC.DS_TIPO_CONTRIBUICAO,
       TC.CALC_MARGEM_CONSIG,
       FI.* 
FROM CC_FICHA_FINANCEIRA FI
INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO
WHERE FI.CD_FUNDACAO = @CD_FUNDACAO
  AND FI.CD_PLANO = @CD_PLANO
  AND FI.NUM_INSCRICAO = @NUM_INSCRICAO
  AND '' + FI.ANO_REF + FI.MES_REF BETWEEN @ANOMES_INICIO AND @ANOMES_FIM 
  AND FI.CD_TIPO_CONTRIBUICAO IN (SELECT CD_TIPO_CONTRIBUICAO
                                  FROM DR_PARAMETROS_RESGATE
                                 WHERE CD_FUNDACAO = FI.CD_FUNDACAO 
                                   AND CD_PLANO = FI.CD_PLANO 
                                   AND CD_TIPO_CONTRIBUICAO = FI.CD_TIPO_CONTRIBUICAO 
                                   AND CD_TIPO_RESGATE = @CD_TIPO_RESGATE)
ORDER BY FI.ANO_REF, 
         FI.MES_REF,
         FI.ANO_COMP, 
         FI.MES_COMP,
         FI.CD_TIPO_CONTRIBUICAO