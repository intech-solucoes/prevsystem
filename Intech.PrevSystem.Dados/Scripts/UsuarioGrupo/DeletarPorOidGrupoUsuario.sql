/*Config
    Retorno
        -void
    Parametros
        -OID_GRUPO_USUARIO:decimal
*/

DELETE FROM WEB_USUARIO_GRUPO
WHERE (OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO) 