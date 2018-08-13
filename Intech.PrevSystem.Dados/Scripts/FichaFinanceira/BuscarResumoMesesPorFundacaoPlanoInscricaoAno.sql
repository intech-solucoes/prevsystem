/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -ANO_REF:string
*/

SELECT *
 FROM CC_FICHA_FINANCEIRA FI
WHERE FI.CD_FUNDACAO = @CD_FUNDACAO
  AND FI.CD_PLANO = @CD_PLANO
  AND FI.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FI.ANO_REF = @ANO_REF
ORDER BY FI.MES_REF