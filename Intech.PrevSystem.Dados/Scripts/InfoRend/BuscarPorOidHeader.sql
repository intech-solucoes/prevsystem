/*Config
    RetornaLista
    Retorno
        -InfoRendEntidade
    Parametros
        -OID_HEADER_INFO_REND:decimal
*/

SELECT *
FROM TB_INFO_REND
WHERE OID_HEADER_INFO_REND = @OID_HEADER_INFO_REND