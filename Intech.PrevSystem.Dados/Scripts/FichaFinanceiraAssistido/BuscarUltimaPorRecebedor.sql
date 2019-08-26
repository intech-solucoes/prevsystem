﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraAssistidoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -SEQ_RECEBEDOR:int
        -CD_PLANO:string
*/

SELECT FF.*
FROM GB_FICHA_FINANC_ASSISTIDO FF
INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON FF.SEQ_RECEBEDOR = RB.SEQ_RECEBEDOR
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND RB.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.CD_EMPRESA = @CD_EMPRESA
  AND RB.CD_EMPRESA = @CD_EMPRESA
  AND FF.CD_PLANO = @CD_PLANO
  AND RB.NUM_MATRICULA = @NUM_MATRICULA
  AND FF.SEQ_RECEBEDOR = @SEQ_RECEBEDOR
AND DT_REFERENCIA = (SELECT MAX(DT_REFERENCIA)
						FROM GB_FICHA_FINANC_ASSISTIDO FF2
						INNER JOIN GB_RECEBEDOR_BENEFICIO RB2 ON FF2.SEQ_RECEBEDOR = RB2.SEQ_RECEBEDOR
						WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
							AND RB2.CD_FUNDACAO = RB.CD_FUNDACAO
							AND FF2.CD_EMPRESA = FF.CD_EMPRESA
							AND RB2.CD_EMPRESA = RB.CD_EMPRESA
							AND FF2.CD_PLANO = FF.CD_PLANO
							AND RB2.NUM_MATRICULA = RB.NUM_MATRICULA
							AND FF2.SEQ_RECEBEDOR = FF.SEQ_RECEBEDOR)
ORDER BY DT_REFERENCIA DESC