/*Config
	RetornaLista
    Retorno
        -GrauParentescoEntidade
    Parametros
        -LISTA_CD_GRAU_PARENTESCO:string
*/

SELECT * 
FROM TB_GRAU_PARENTESCO
WHERE CD_GRAU_PARENTESCO IN (@LISTA_CD_GRAU_PARENTESCO)
ORDER BY DS_GRAU_PARENTESCO