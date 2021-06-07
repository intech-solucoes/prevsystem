﻿/*Config
    RetornaLista
    Retorno
        -DependenteEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-CD_PLANO:string
		-DT_ATUAL:DateTime
*/

SELECT * 
FROM CS_DEPENDENTE
INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO
WHERE CD_FUNDACAO        = @CD_FUNDACAO
  AND NUM_INSCRICAO      = @NUM_INSCRICAO
  AND CD_PLANO           = @CD_PLANO
  AND DT_TERM_IRRF       >= @DT_ATUAL