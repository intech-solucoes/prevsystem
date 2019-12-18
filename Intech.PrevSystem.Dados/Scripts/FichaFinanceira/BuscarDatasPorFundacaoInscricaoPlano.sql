/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
	    -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-CD_PLANO:string
*/

SELECT DISTINCT 
       FF.ANO_REF,
       FF.MES_REF
FROM CC_FICHA_FINANCEIRA FF
WHERE FF.CD_FUNDACAO   = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO      = @CD_PLANO
ORDER BY FF.ANO_REF, FF.MES_REF