﻿/*Config
    Retorno
        -UsuarioEntidade
    Parametros
        -NOM_LOGIN:string
        -PWD_USUARIO:string
*/

SELECT TOP 1 *
FROM WEB_USUARIO
WHERE NOM_LOGIN = @NOM_LOGIN
  AND PWD_USUARIO = @PWD_USUARIO