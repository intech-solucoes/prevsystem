﻿/*Config
    RetornaLista
    Retorno
        -DocumentoEntidade
    Parametros
        -OID_DOCUMENTO_PASTA:decimal?
		-ORDER_CRITERIA:string
*/

SELECT D.OID_DOCUMENTO, D.OID_ARQUIVO_UPLOAD, D.OID_DOCUMENTO_PASTA, D.TXT_TITULO, D.IND_ATIVO, D.DTA_INCLUSAO, P.DS_PLANO, P.CD_PLANO
 FROM WEB_DOCUMENTO D LEFT JOIN WEB_DOCUMENTO_PLANO DP
 ON D.OID_DOCUMENTO = DP.OID_DOCUMENTO
 LEFT JOIN TB_PLANOS P
 ON DP.CD_PLANO = P.CD_PLANO
 WHERE (OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)
   OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL)
ORDER BY
CASE
   WHEN @ORDER_CRITERIA = 'nome' THEN D.TXT_TITULO
END,
CASE
	WHEN @ORDER_CRITERIA = 'data' THEN D.DTA_INCLUSAO
END