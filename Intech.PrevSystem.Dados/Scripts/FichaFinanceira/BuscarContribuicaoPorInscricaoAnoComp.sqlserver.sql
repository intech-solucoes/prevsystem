/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -NUM_INSCRICAO:string
*/

SELECT FF.ANO_COMP,
       FF.MES_COMP,
       TC.DS_TIPO_CONTRIBUICAO,
       FF.SRC,
       FF.CONTRIB_PARTICIPANTE,
       FF.CONTRIB_EMPRESA,
       FF.*
FROM CC_FICHA_FINANCEIRA FF
    INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
    INNER JOIN TB_FAIXA_VALOR_CONTRIB FVC ON FVC.CD_FUNDACAO = FF.CD_FUNDACAO
        AND FVC.CD_PLANO = FF.CD_PLANO
        AND FVC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
        AND FVC.CD_MANTENEDORA = '2'
WHERE FF.CD_FUNDACAO   = '01'
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO      = '0002'
  AND (FF.ANO_COMP * 12 + FF.MES_COMP) = (SELECT MAX(FF2.ANO_COMP * 12 + FF2.MES_COMP)
                                          FROM CC_FICHA_FINANCEIRA FF2 
                                         WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
                                           AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO
                                           AND FF2.CD_PLANO = FF.CD_PLANO
                                           AND FF2.MES_COMP <> '13'
										   AND (FF2.ANO_REF * 12 + FF2.MES_REF) = (SELECT MAX(FF2.ANO_REF * 12 + FF2.MES_REF)
                                                                                     FROM CC_FICHA_FINANCEIRA FF2 
                                                                                    WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
                                                                                      AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO
                                                                                      AND FF2.CD_PLANO = FF.CD_PLANO
                                                                                      AND FF2.MES_COMP <> '13'))
  AND (FVC.ANO_REF * 12 + FVC.MES_REF) = (SELECT MAX(FVC2.ANO_REF * 12 + FVC2.MES_REF)
                                          FROM TB_FAIXA_VALOR_CONTRIB FVC2 
                                         WHERE FVC2.CD_FUNDACAO = FVC.CD_FUNDACAO
                                           AND FVC2.CD_PLANO = FVC.CD_PLANO
                                           AND FVC2.CD_TIPO_CONTRIBUICAO = FVC.CD_TIPO_CONTRIBUICAO
                                           AND FVC.CD_MANTENEDORA = '2')
ORDER BY FF.CD_TIPO_CONTRIBUICAO