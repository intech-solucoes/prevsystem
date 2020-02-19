/*Config
    Retorno
        -void
    Parametros
        -OID_GRUPO_USUARIO:decimal
*/

DELETE FROM WEB_DOCUMENTO_PASTA
WHERE (OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO) 