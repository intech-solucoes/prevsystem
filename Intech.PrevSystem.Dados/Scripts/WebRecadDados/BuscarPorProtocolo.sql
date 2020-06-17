/*Config
    Retorno
        -WebRecadDadosEntidade
    Parametros
        -COD_PROTOCOLO:string
*/

SELECT * 
FROM WEB_RECAD_DADOS
WHERE COD_PROTOCOLO = @COD_PROTOCOLO