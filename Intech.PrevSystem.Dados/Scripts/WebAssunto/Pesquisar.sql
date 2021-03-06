﻿/*Config
    RetornaLista
    Retorno
        -WebAssuntoEntidade
    Parametros
        -TXT_ASSUNTO:string
*/

SELECT WA.OID_ASSUNTO, WA.OID_AREA_FUNDACAO, WA.CD_FUNDACAO, WA.TXT_ASSUNTO, WA.IND_ATIVO, WAF.DES_AREA_FUNDACAO
FROM WEB_ASSUNTO WA JOIN WEB_AREA_FUNDACAO WAF
ON WA.OID_AREA_FUNDACAO = WAF.OID_AREA_FUNDACAO
WHERE (TXT_ASSUNTO LIKE '%' +@TXT_ASSUNTO + '%' OR @TXT_ASSUNTO IS NULL)
ORDER BY WA.OID_ASSUNTO