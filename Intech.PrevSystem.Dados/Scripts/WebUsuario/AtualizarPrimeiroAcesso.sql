/*Config
    Retorno
        -WebUsuarioEntidade
    Parametros
        -NOM_LOGIN:string
*/

UPDATE WEB_USUARIO SET IND_PRIMEIRO_ACESSO = 'N' WHERE NOM_LOGIN = @NOM_LOGIN