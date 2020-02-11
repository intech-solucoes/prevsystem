/*Config
    RetornaLista
    Retorno
        -WebAssuntoEntidade
    Parametros
        -IND_ATIVO:string
*/

SELECT * FROM WEB_ASSUNTO
 WHERE IND_ATIVO = @IND_ATIVO