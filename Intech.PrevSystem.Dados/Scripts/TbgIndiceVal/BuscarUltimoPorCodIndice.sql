﻿/*Config
    RetornaLista
    Retorno
        -TbgIndiceValEntidade
    Parametros
        -COD_INDICE:string
*/

SELECT *
FROM TBG_INDICE_VAL
INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE
WHERE TBG_INDICE.COD_INDICE = @COD_INDICE
  AND DTA_INDICE = (SELECT MAX(DTA_INDICE)
                    FROM TBG_INDICE_VAL 
                    INNER JOIN TBG_INDICE ON TBG_INDICE.OID_INDICE = TBG_INDICE_VAL.OID_INDICE
                    WHERE TBG_INDICE.COD_INDICE = @COD_INDICE)
ORDER BY DTA_INDICE DESC