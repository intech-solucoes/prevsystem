/*Config
    Retorno
        -void
    Parametros
        -OID_REQ_BENEFICIO:decimal
        -IND_SITUACAO:string
*/

UPDATE WEB_REQ_BENEFICIO 
SET IND_SITUACAO = @IND_SITUACAO
WHERE OID_REQ_BENEFICIO = @OID_REQ_BENEFICIO