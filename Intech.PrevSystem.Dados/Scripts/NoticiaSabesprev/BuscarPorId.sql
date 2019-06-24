/*Config
    Retorno
        -NoticiaSabesprevEntidade
    Parametros
        -ID:decimal
*/

SELECT *
FROM VW_APP_INSTITUCIONAL_NOTICIA
WHERE INSTITUCIONAL_ID = @ID