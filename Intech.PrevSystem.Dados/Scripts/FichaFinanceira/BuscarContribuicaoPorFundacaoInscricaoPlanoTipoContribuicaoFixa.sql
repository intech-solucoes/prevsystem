/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
		-CD_PLANO:string
*/

SELECT FF.*
FROM CC_FICHA_FINANCEIRA FF
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO = @CD_PLANO
  AND FF.CD_TIPO_CONTRIBUICAO IN ('65', '25')
  AND FF.ANO_COMP * 13 + FF.MES_COMP = (SELECT MAX(FF2.ANO_COMP * 13 + FF2.MES_COMP) 
                                        FROM CC_FICHA_FINANCEIRA FF2
                                        WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
                                          AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO
                                          AND FF2.CD_PLANO = FF.CD_PLANO)