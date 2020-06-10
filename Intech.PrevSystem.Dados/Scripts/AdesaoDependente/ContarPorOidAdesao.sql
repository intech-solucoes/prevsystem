/*Config
    Retorno
        -int
    Parametros
        -OID_ADESAO:decimal
*/

SELECT COUNT(*)
FROM WEB_ADESAO_DEPENDENTE
WHERE OID_ADESAO = @OID_ADESAO