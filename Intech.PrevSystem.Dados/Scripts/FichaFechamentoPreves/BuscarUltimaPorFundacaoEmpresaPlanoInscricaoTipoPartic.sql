/*Config
    Retorno
        -FichaFechamentoPrevesEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
		-TIPO:string
		-IND_PARTIC:string
*/


SELECT TOP 1 FF.*, 
             LO.DS_LOTACAO 
FROM   CC_FICHA_FECHAMENTO_PREVES FF 
       INNER JOIN CS_FUNCIONARIO FUNC 
               ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO 
       INNER JOIN TB_LOTACAO LO 
               ON LO.CD_LOTACAO = FUNC.CD_LOTACAO 
                  AND LO.CD_EMPRESA = FUNC.CD_EMPRESA 
WHERE  FF.CD_FUNDACAO = @CD_FUNDACAO
       AND FF.CD_EMPRESA = @CD_EMPRESA
       AND FF.CD_PLANO = @CD_PLANO
       AND FF.NUM_INSCRICAO = @NUM_INSCRICAO
       AND FF.IND_ANALITICO_SINTETICO = @TIPO
       AND IND_PARTIC = @IND_PARTIC
       AND IND_TIPO = 'CN' 
ORDER  BY FF.CD_FUNDACAO, 
          FF.CD_EMPRESA, 
          FF.NUM_INSCRICAO, 
          FF.ANO_REF DESC, 
          FF.MES_REF DESC, 
          FF.ANO_COMP DESC, 
          FF.MES_COMP DESC, 
          FF.NUM_SEQ, 
          FF.IND_TIPO 