/*Config
    Retorno
        -UsuarioEntidade
    Parametros
        -NOM_LOGIN:string
*/

SELECT TOP 1 *
FROM WEB_USUARIO
WHERE NOM_LOGIN = @NOM_LOGIN