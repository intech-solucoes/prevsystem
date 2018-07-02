/*Config
	RetornaLista
	Retorno
		-IndiceValoresEntidade
	Parametros
		-COD_IND:string
*/

SELECT TOP 1 * 
FROM TB_IND_VALORES 
WHERE COD_IND = @COD_IND
ORDER BY DT_IND DESC