/*Config
	RetornaLista
	Retorno
		-IndiceValoresEntidade
	Parametros
		-COD_IND:string
		-DATA_ATUAL:DateTime
*/

SELECT * 
FROM TB_IND_VALORES 
WHERE COD_IND = @COD_IND
  AND DT_IND = (SELECT MAX(ID2.DT_IND)
                  FROM TB_IND_VALORES ID2
                 WHERE ID2.COD_IND = TB_IND_VALORES.COD_IND
                   AND ID2.DT_IND <= @DATA_ATUAL)