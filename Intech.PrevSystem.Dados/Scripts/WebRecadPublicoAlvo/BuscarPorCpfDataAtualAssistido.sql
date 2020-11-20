﻿/*Config
    RetornaLista
    Retorno
        -WebRecadPublicoAlvoEntidade
    Parametros
        -CPF:string
		-DATA_ATUAL:DateTime
*/

SELECT PA.*,
       CA.DTA_TERMINO,
       RB.CD_TIPO_RECEBEDOR,
       RB.NUM_MATRICULA,
       
       CASE
          WHEN CA.DTA_INICIO <= @DATA_ATUAL
          AND CA.DTA_TERMINO >= @DATA_ATUAL
          AND CA.IND_ATIVO = 'SIM'
            THEN 'S'
          ELSE 'N'
       END AS PRAZO_RECADASTRAMENTO,

	   'ASSISTIDO' AS 'GRUPO_RECADASTRAMENTO'
  FROM WEB_RECAD_PUBLICO_ALVO PA
    INNER JOIN GB_RECEBEDOR_BENEFICIO RB ON RB.CD_FUNDACAO = PA.CD_FUNDACAO
      AND RB.SEQ_RECEBEDOR = PA.SEQ_RECEBEDOR
    INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID
    INNER JOIN WEB_RECAD_CAMPANHA CA ON CA.OID_RECAD_CAMPANHA = PA.OID_RECAD_CAMPANHA
WHERE EE.CPF_CGC = @CPF
  AND CA.IND_ATIVO = 'SIM'
  ORDER BY DTA_INICIO DESC