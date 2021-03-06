﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-ANO:string
*/

SELECT FF.CD_PLANO,
	   SUM(FF.CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE,
	   SUM(FF.CONTRIB_EMPRESA) AS CONTRIB_EMPRESA
FROM CC_FICHA_FINANCEIRA FF
	INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = FF.CD_FUNDACAO 
			AND FN.NUM_INSCRICAO = FF.NUM_INSCRICAO
	INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
WHERE TC.CK_COMPOE_IR_AM = 'S'
  AND FF.CD_FUNDACAO =:CD_FUNDACAO
  AND FF.NUM_INSCRICAO =:NUM_INSCRICAO
  AND FF.ANO_REF =:ANO
  AND FF.CD_ORIGEM NOT IN ('GB', 'G0', 'DR')
  AND FF.CD_TIPO_CONTRIBUICAO NOT IN ('73', '70', '74', '34', 'B4', 'B6', 'B5', 'B1', 'B2', 'B3', 'B7', 'B8', 'B9', 'C1', 'C5', 'C6', 'D5')
GROUP BY FF.CD_PLANO