﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT CC_FICHA_FINANCEIRA.*
FROM CC_FICHA_FINANCEIRA
INNER JOIN TB_TIPO_CONTRIBUICAO ON TB_TIPO_CONTRIBUICAO.CD_TIPO_CONTRIBUICAO = CC_FICHA_FINANCEIRA.CD_TIPO_CONTRIBUICAO
WHERE (CC_FICHA_FINANCEIRA.CD_FUNDACAO = @CD_FUNDACAO)
  AND (CC_FICHA_FINANCEIRA.NUM_INSCRICAO = @NUM_INSCRICAO)
  AND (CC_FICHA_FINANCEIRA.CD_PLANO IN ('0001', '0002'))
  AND (TB_TIPO_CONTRIBUICAO.CALC_MARGEM_CONSIG = 'S')