﻿/*Config
    RetornaLista
    Retorno
        -DocumentoPastaEntidade
    Parametros
        -OID_DOCUMENTO_PASTA_PAI:decimal?
		-ORDER_CRITERIA:string
*/

SELECT *
FROM WEB_DOCUMENTO_PASTA WDP LEFT JOIN WEB_GRUPO_USUARIO WGU
ON WDP.OID_GRUPO_USUARIO = WGU.OID_GRUPO_USUARIO
WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI)
   OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)
ORDER BY
CASE
   WHEN @ORDER_CRITERIA = 'nome' THEN WDP.NOM_PASTA
END,
CASE
   WHEN @ORDER_CRITERIA = 'data' THEN WDP.DTA_INCLUSAO
END