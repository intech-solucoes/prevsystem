/*Config
    RetornaLista
    Retorno
        -AdesaoDependenteEntidade
    Parametros
        -OID_ADESAO:decimal
*/

SELECT *
FROM WEB_ADESAO_DEPENDENTE
WHERE OID_ADESAO = @OID_ADESAO