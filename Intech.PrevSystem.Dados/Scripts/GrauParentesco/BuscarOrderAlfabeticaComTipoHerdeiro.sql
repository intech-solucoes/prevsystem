/*Config
	RetornaLista
    Retorno
        -GrauParentescoEntidade
*/

SELECT * 
FROM TB_GRAU_PARENTESCO
WHERE TIPO_HERDEIRO IS NOT NULL
ORDER BY DS_GRAU_PARENTESCO