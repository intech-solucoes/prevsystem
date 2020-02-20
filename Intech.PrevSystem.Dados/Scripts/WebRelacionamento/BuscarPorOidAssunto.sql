/*Config
    RetornaLista
    Retorno
        -WebRelacionamentoEntidade
    Parametros
        -@OID_ASSUNTO:decimal
*/

SELECT *
   FROM WEB_RELACIONAMENTO WR
       JOIN WEB_ASSUNTO WA ON WR.OID_ASSUNTO = WA.OID_ASSUNTO
WHERE WR.OID_ASSUNTO = @OID_ASSUNTO