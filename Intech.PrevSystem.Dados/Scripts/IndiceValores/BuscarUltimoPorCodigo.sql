/*Config
	RetornaLista
	Retorno
		-IndiceValoresEntidade
	Parametros
		-COD_IND:string
*/

SELECT * 
 FROM TB_IND_VALORES V 
WHERE COD_IND = @COD_IND
  AND V.DT_IND = (SELECT MAX(DT_IND) 
                    FROM TB_IND_VALORES 
                   WHERE COD_IND = V.COD_IND)