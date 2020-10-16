/*Config
    Retorno
        -DocumentoEntidade
    Parametros
        -OID_DOCUMENTO:decimal
*/

SELECT *
FROM WEB_DOCUMENTO
WHERE OID_DOCUMENTO = @OID_DOCUMENTO