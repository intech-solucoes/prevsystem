/*Config
    Retorno
        -UsuarioEntidade
    Parametros
        -NOM_LOGIN:string
*/

SELECT *
FROM WEB_USUARIO
WHERE NOM_LOGIN = @NOM_LOGIN