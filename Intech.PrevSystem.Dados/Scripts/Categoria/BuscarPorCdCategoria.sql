/*Config
    Retorno
        -CategoriaEntidade
    Parametros
        -CD_CATEGORIA:string
*/

SELECT *
FROM TB_CATEGORIA
WHERE CD_CATEGORIA = @CD_CATEGORIA