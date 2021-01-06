/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-CD_PLANO:string
*/

SELECT TC.DS_TIPO_CONTRIBUICAO,
       FF.*
FROM CC_FICHA_FINANCEIRA FF
    INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO = @CD_PLANO
  AND FF.ANO_COMP * 13 + FF.MES_COMP = (SELECT MAX(FF2.ANO_COMP * 13 + FF2.MES_COMP) 
                                        FROM CC_FICHA_FINANCEIRA FF2
                                        WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
                                          AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO
                                          AND FF2.CD_PLANO = FF.CD_PLANO
										  AND FF2.MES_COMP <> 13)
ORDER BY FF.CD_TIPO_CONTRIBUICAO