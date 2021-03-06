﻿/*Config
	RetornaLista
	Retorno
		-NaturezaEntidade
	Parametros
		-CD_PLANO:string
		-CD_MODAL:decimal
*/

SELECT *
FROM CE_NATUREZA
INNER JOIN CE_GRUPO_NATUREZA ON CE_GRUPO_NATUREZA.CD_GRUPO = CE_NATUREZA.CD_GRUPO
WHERE CE_GRUPO_NATUREZA.CD_PLANO = @CD_PLANO
AND CE_GRUPO_NATUREZA.CD_MODAL = @CD_MODAL
AND CE_NATUREZA.PERMITE_CONCESSAO_WEB = 'S'
ORDER BY CE_NATUREZA.PRAZO_MAX