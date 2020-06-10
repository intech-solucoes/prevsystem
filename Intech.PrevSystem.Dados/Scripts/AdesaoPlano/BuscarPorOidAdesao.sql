/*Config
    Retorno
        -AdesaoPlanoEntidade
    Parametros
        -OID_ADESAO:decimal
*/

SELECT *
FROM WEB_ADESAO_PLANO
WHERE OID_ADESAO = @OID_ADESAO