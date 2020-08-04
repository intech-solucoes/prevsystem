/*Config
    RetornaLista
    Retorno
        -WebRecadPublicoAlvoEntidade
    Parametros
        -NUM_INSCRICAO:string
*/

SELECT *
  FROM WEB_RECAD_PUBLICO_ALVO PA
WHERE NUM_INSCRICAO = @NUM_INSCRICAO