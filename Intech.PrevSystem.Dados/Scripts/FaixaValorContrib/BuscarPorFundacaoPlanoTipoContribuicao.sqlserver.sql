/*Config
    RetornaLista
    Retorno
        -FaixaValorContribEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -CD_TIPO_CONTRIBUICAO:string
*/

SELECT * FROM TB_FAIXA_VALOR_CONTRIB FVC
WHERE FVC.CD_FUNDACAO = @CD_FUNDACAO
  AND FVC.CD_PLANO = @CD_PLANO
  AND FVC.CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO
  AND (FVC.ANO_REF * 12 + FVC.MES_REF) = (SELECT MAX(FVC2.ANO_REF * 12 + FVC2.MES_REF)
                                          FROM TB_FAIXA_VALOR_CONTRIB FVC2 
                                         WHERE FVC2.CD_FUNDACAO = FVC.CD_FUNDACAO
                                           AND FVC2.CD_PLANO = FVC.CD_PLANO
                                           AND FVC2.CD_TIPO_CONTRIBUICAO = FVC.CD_TIPO_CONTRIBUICAO
                                           AND FVC.CD_MANTENEDORA = '2')