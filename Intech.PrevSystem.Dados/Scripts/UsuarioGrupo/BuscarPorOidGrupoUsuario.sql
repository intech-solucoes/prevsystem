/*Config
    RetornaLista
    Retorno
        -UsuarioGrupoEntidade
    Parametros
        -@OID_GRUPO_USUARIO:decimal
*/

SELECT * FROM WEB_USUARIO_GRUPO
WHERE OID_GRUPO_USUARIO = @OID_GRUPO_USUARIO