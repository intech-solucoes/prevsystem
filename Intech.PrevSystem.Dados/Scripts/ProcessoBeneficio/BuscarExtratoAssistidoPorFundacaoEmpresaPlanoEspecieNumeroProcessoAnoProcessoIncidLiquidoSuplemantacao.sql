﻿/*Config
    RetornaLista
    Retorno
        -dynamic
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_ESPECIE:string
        -NUM_PROCESSO:decimal
		-ANO_PROCESSO:string
		-INCID_LIQUIDO:string
		-ID_RUB_SUPLEMENTACAO:string
*/

SELECT PB.CD_FUNDACAO,
     PB.CD_EMPRESA,
     PB.CD_PLANO,
     PB.CD_ESPECIE,
     PB.ANO_PROCESSO,
     PB.NUM_PROCESSO,
     PB.NUM_INSCRICAO,     
     FN.NUM_MATRICULA,
     EB.DS_ESPECIE, 
     PL.DS_PLANO,
     PL.COD_CNPB,
     ST.DS_SITUACAO,
     HP.DT_INICIO_FUND,
     TF.DS_TIPO_FOLHA,
     FF.DT_REFERENCIA,
     RP.DS_RUBRICA,
     FF.VALOR_MC
FROM   GB_PROCESSOS_BENEFICIO PB
INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE 
INNER JOIN GB_SITUACAO ST ON ST.CD_SITUACAO = PB.CD_SITUACAO
INNER JOIN CS_FUNCIONARIO FN ON FN.CD_FUNDACAO   = PB.CD_FUNDACAO
    AND FN.NUM_INSCRICAO = PB.NUM_INSCRICAO 
INNER JOIN GB_HIST_PROCESSOS HP ON PB.CD_FUNDACAO  = HP.CD_FUNDACAO 
    AND PB.CD_EMPRESA   = HP.CD_EMPRESA 
    AND PB.CD_PLANO     = HP.CD_PLANO 
    AND PB.CD_ESPECIE   = HP.CD_ESPECIE 
    AND PB.NUM_PROCESSO = HP.NUM_PROCESSO 
    AND PB.ANO_PROCESSO = HP.ANO_PROCESSO 
INNER JOIN GB_FICHA_FINANC_ASSISTIDO FF ON PB.CD_FUNDACAO  = FF.CD_FUNDACAO 
    AND PB.CD_EMPRESA   = FF.CD_EMPRESA 
    AND PB.CD_PLANO     = FF.CD_PLANO 
    AND PB.CD_ESPECIE   = FF.CD_ESPECIE 
    AND PB.NUM_PROCESSO = FF.NUM_PROCESSO 
    AND PB.ANO_PROCESSO = FF.ANO_PROCESSO 
INNER JOIN TB_PLANOS PL ON PL.CD_FUNDACAO = PB.CD_FUNDACAO
    AND PL.CD_PLANO = PB.CD_PLANO
INNER JOIN GB_RUBRICAS_PREVIDENCIAL RP ON RP.CD_RUBRICA = FF.CD_RUBRICA
INNER JOIN TB_TIPO_FOLHA TF ON TF.CD_TIPO_FOLHA = FF.CD_TIPO_FOLHA
WHERE PB.CD_FUNDACAO  = @CD_FUNDACAO
   AND PB.CD_EMPRESA   = @CD_EMPRESA
   AND PB.CD_PLANO     = @CD_PLANO
   AND PB.CD_ESPECIE   = @CD_ESPECIE
   AND PB.NUM_PROCESSO = @NUM_PROCESSO
   AND PB.ANO_PROCESSO = @ANO_PROCESSO
   AND RP.INCID_LIQUIDO = @INCID_LIQUIDO
   AND RP.ID_RUB_SUPLEMENTACAO = @ID_RUB_SUPLEMENTACAO
ORDER BY FF.DT_REFERENCIA DESC