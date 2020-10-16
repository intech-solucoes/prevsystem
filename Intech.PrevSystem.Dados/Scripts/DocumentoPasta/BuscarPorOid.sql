/*Config
    Retorno
        -DocumentoPastaEntidade
    Parametros
        -OID_DOCUMENTO_PASTA:decimal
*/

SELECT *
FROM WEB_DOCUMENTO_PASTA
WHERE OID_DOCUMENTO_PASTA = @OID_DOCUMENTO_PASTA