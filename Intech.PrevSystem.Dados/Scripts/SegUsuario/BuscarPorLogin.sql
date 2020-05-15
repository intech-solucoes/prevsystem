/*Config
    Retorno
        -SegUsuarioEntidade
    Parametros
        -NOM_LOGIN:string
        -PWD_USUARIO:string
*/

SELECT *
FROM SEG_USUARIO
WHERE NOM_LOGIN = @NOM_LOGIN
  AND PWD_USUARIO = @PWD_USUARIO
