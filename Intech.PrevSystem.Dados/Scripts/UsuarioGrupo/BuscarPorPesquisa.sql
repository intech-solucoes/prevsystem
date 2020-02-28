/*Config
	RetornaLista
    Retorno
        -UsuarioGrupoEntidade
    Parametros
        -CPF:string
        -NOME:string
*/

SELECT DISTINCT *
FROM   VW_FUNC_PLANO_DADOS FPD
JOIN WEB_USUARIO U ON FPD.CPF_CGC = U.NOM_LOGIN
WHERE (CPF_CGC = @CPF OR @CPF IS NULL)
  AND (NOME_ENTID LIKE '%' + @NOME + '%' OR @NOME IS NULL)