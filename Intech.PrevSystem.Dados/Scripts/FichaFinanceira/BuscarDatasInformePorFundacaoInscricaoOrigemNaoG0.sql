﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
*/

SELECT DISTINCT FF.ANO_REF
FROM CC_FICHA_FINANCEIRA FF
	INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = FF.CD_FUNDACAO 
			AND FN.NUM_INSCRICAO = FF.NUM_INSCRICAO
	INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
WHERE TC.CK_COMPOE_IR_AM = 'S'
  AND FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_ORIGEM NOT IN ('G0')
GROUP BY FF.ANO_REF
ORDER BY FF.ANO_REF DESC