/*Config
    RetornaLista
    Retorno
        -GrupoUsuarioEntidade
    Parametros
        -NOM_GRUPO_USUARIO:string
*/

SELECT *
FROM WEB_GRUPO_USUARIO
WHERE (NOM_GRUPO_USUARIO LIKE '%' +@NOM_GRUPO_USUARIO + '%' OR @NOM_GRUPO_USUARIO IS NULL)
ORDER BY OID_GRUPO_USUARIO