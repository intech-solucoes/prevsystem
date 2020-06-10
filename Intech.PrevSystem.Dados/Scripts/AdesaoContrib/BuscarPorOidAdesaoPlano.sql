/*Config
    Retorno
        -AdesaoContribEntidade
    Parametros
        -OID_ADESAO_PLANO:decimal
*/

SELECT *
FROM WEB_ADESAO_CONTRIB
WHERE OID_ADESAO_PLANO = @OID_ADESAO_PLANO