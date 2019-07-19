/*Config
    Retorno
        -decimal
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT VI.PERCENTUAL 
  FROM DR_VALORES_PERC_IDADE VI, 
       DR_PERC_IDADE PI 
 WHERE VI.CD_FUNDACAO       = PI.CD_FUNDACAO 
   AND VI.CD_TIPO_RESGATE   = PI.CD_TIPO_RESGATE 
   AND VI.CD_PLANO          = PI.CD_PLANO 
   AND VI.CD_MANTENEDORA    = PI.CD_MANTENEDORA 
   AND VI.CD_FUNDACAO       = @CD_FUNDACAO
   AND VI.CD_TIPO_RESGATE   = '01'
   AND VI.CD_PLANO          = '0001'
   AND VI.CD_MANTENEDORA    = '2'
   AND VI.QTD_CONTRIB      >= (SELECT COUNT(DISTINCT CF.ANO_REF + CF.MES_REF)
                                 FROM CC_FICHA_FINANCEIRA CF                              
                                WHERE CF.CD_FUNDACAO   = @CD_FUNDACAO 
                                  AND CF.CD_PLANO      = @CD_PLANO   
                                  AND CF.NUM_INSCRICAO = @NUM_INSCRICAO
                                  AND (CF.CONTRIB_PARTICIPANTE <> 0 OR CF.CONTRIB_EMPRESA <> 0) )                                  
ORDER BY VI.CD_FUNDACAO, VI.CD_TIPO_RESGATE,  VI.CD_PLANO,  VI.CD_MANTENEDORA, 
         VI.ANOS_IDADE, VI.ANOS_CONTRIBUICAO, VI.ANOS_PATROC, VI.QTD_CONTRIB 