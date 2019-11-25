/*Config
    Retorno
        -ProtocoloEntidade
    Parametros
        -OID_FUNCIONALIDADE:decimal
*/

SELECT *
FROM WEB_PROTOCOLO
WHERE OID_FUNCIONALIDADE = @OID_FUNCIONALIDADE