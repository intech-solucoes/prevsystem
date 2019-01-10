﻿/*Config
    RetornaLista
    Retorno
        -FichaFechamentoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
        -DT_INICIO:string
        -DT_FIM:string
*/

SELECT FF.*,
	LO.DS_LOTACAO
FROM CC_FICHA_FECHAMENTO FF
INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO
INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO
						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.CD_EMPRESA = @CD_EMPRESA
  AND FF.CD_PLANO = @CD_PLANO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND ('' + FF.ANO_REF + FF.MES_REF BETWEEN @DT_INICIO AND @DT_FIM)
ORDER BY FF.CD_FUNDACAO,
         FF.CD_EMPRESA,
         FF.NUM_INSCRICAO,
         FF.ANO_REF,
         FF.MES_REF