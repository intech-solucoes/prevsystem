﻿/*Config
    RetornaLista
    Retorno
        -DocumentoPastaEntidade
    Parametros
        -OID_DOCUMENTO_PASTA_PAI:decimal?
*/

SELECT *
FROM WEB_DOCUMENTO_PASTA
WHERE (OID_DOCUMENTO_PASTA_PAI = @OID_DOCUMENTO_PASTA_PAI) 
   OR (@OID_DOCUMENTO_PASTA_PAI IS NULL AND OID_DOCUMENTO_PASTA_PAI IS NULL)