/*Config
    RetornaLista
    Retorno
        -FuncionalidadeEntidade
	Parametros
        -@IND_ATIVO:string
*/

SELECT *   
FROM WEB_FUNCIONALIDADE
WHERE IND_ATIVO = @IND_ATIVO
ORDER BY DES_FUNCIONALIDADE