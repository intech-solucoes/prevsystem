﻿/*Config
    RetornaLista
    Retorno
        -WebRecadPublicoAlvoEntidade
    Parametros
        -CPF:string
		-DATA_ATUAL:DateTime
*/

SELECT PA.*
  FROM WEB_RECAD_PUBLICO_ALVO PA
    INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO = PA.CD_FUNDACAO
		AND FN.NUM_INSCRICAO = PA.NUM_INSCRICAO
    INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = FN.COD_ENTID
    INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA
WHERE EE.CPF_CGC = @CPF
  AND CA.DTA_INICIO <= @DATA_ATUAL
  AND CA.DTA_TERMINO >= @DATA_ATUAL
  AND CA.IND_ATIVO = 'SIM'