﻿/*Config
    RetornaLista
    Retorno
        -DocumentoEntidade
    Parametros
        -OID_DOCUMENTO_PASTA:decimal?
*/

SELECT *
FROM WEB_DOCUMENTO
WHERE ((OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA)
   OR (@OID_DOCUMENTO_PASTA IS NULL AND OID_DOCUMENTO_PASTA IS NULL))