/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT FF.ANO_REF,
       FF.MES_REF, 
       TC.COD_AGRUPADOR_WEB,
	   CASE 
			WHEN TC.COD_AGRUPADOR_WEB = 'ADMPA' THEN 'Adm. Participante'
			WHEN TC.COD_AGRUPADOR_WEB = 'ADMPT' THEN 'Adm. Patrocinadora'
			WHEN TC.COD_AGRUPADOR_WEB = 'RIPA' THEN 'Risco Participante'
			WHEN TC.COD_AGRUPADOR_WEB = 'RIPT' THEN 'Risco Patrocinadora'
			else 'Falta Agrupador WEB'
		end as DS_AGRUPADOR_WEB,
       SUM(FF.CONTRIB_EMPRESA + FF.CONTRIB_PARTICIPANTE) AS CONTRIB_PARTICIPANTE 
FROM CC_FICHA_FINANCEIRA FF
    INNER JOIN TB_TIPO_CONTRIBUICAO TC ON TC.CD_TIPO_CONTRIBUICAO = FF.CD_TIPO_CONTRIBUICAO
WHERE FF.CD_FUNDACAO = @CD_FUNDACAO
  AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
  AND FF.CD_PLANO = @CD_PLANO
  AND TC.COD_AGRUPADOR_WEB IN ('ADMPA', 'ADMPT', 'RIPA', 'RIPT')
  AND (FF.ANO_REF * 12 + FF.MES_REF) = (SELECT MAX(YEAR(FF2.DT_FECHAMENTO) * 12 + MONTH(FF2.DT_FECHAMENTO))
                                          FROM CC_FICHA_FECHAMENTO FF2 
                                         WHERE FF2.CD_FUNDACAO = FF.CD_FUNDACAO
                                           AND FF2.NUM_INSCRICAO = FF.NUM_INSCRICAO
                                           AND FF2.CD_PLANO = FF.CD_PLANO)
GROUP BY FF.ANO_REF,
         FF.MES_REF, 
         TC.COD_AGRUPADOR_WEB