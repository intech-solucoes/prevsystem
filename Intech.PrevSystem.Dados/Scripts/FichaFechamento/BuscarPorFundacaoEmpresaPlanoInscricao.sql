/*Config
    RetornaLista
    Retorno
        -FichaFechamentoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT *
FROM CC_FICHA_FECHAMENTO FF
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.CD_EMPRESA = @CD_EMPRESA
  AND FF.CD_PLANO = @CD_PLANO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
ORDER BY FF.DT_FECHAMENTO DESC