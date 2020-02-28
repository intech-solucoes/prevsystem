/*Config
    RetornaLista
    Retorno
        -GrupoUsuarioEntidade
    Parametros
        -@IND_ATIVO:string
*/

SELECT * FROM WEB_GRUPO_USUARIO
WHERE IND_ATIVO = @IND_ATIVO