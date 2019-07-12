/*Config
    Retorno
        -PlanoVinculadoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_PLANO:string
        -NUM_INSCRICAO:string
*/

SELECT PL.CD_PLANO,
       ST.DS_SIT_PLANO,
       PV.DT_INSC_PLANO,
       HR.DT_INIC_VALIDADE,
       HR2.VL_RENDA_FUNDACAO as VL_BENEF_SALDADO_INICIAL,
       HR.VL_RENDA_FUNDACAO as VL_BENEF_SALDADO_ATUAL
FROM CS_PLANOS_VINC PV
      INNER JOIN CS_FUNCIONARIO FN ON 
            FN.CD_FUNDACAO   = PV.CD_FUNDACAO AND
            FN.NUM_INSCRICAO = PV.NUM_INSCRICAO
      INNER JOIN TB_SIT_PLANO ST ON
            ST.CD_SIT_PLANO = PV.CD_SIT_PLANO
      INNER JOIN TB_PLANOS PL ON
            PL.CD_FUNDACAO = PV.CD_FUNDACAO AND
            PL.CD_PLANO    = PV.CD_PLANO
      INNER JOIN GB_PROCESSOS_BENEFICIO PB ON
            PB.CD_FUNDACAO   = PV.CD_FUNDACAO AND
            PB.NUM_INSCRICAO = PV.NUM_INSCRICAO AND
            PB.CD_PLANO = PV.CD_PLANO
      INNER JOIN GB_HIST_RENDAS HR ON
            HR.CD_FUNDACAO  = PB.CD_FUNDACAO AND
            HR.CD_EMPRESA   = PB.CD_EMPRESA AND
            HR.CD_PLANO     = PB.CD_PLANO AND
            HR.CD_ESPECIE   = PB.CD_ESPECIE AND
            HR.ANO_PROCESSO = PB.ANO_PROCESSO AND
            HR.NUM_PROCESSO = PB.NUM_PROCESSO
      INNER JOIN GB_HIST_RENDAS HR2 ON
            HR2.CD_FUNDACAO  = PB.CD_FUNDACAO AND
            HR2.CD_EMPRESA   = PB.CD_EMPRESA AND
            HR2.CD_PLANO     = PB.CD_PLANO AND
            HR2.CD_ESPECIE   = PB.CD_ESPECIE AND
            HR2.ANO_PROCESSO = PB.ANO_PROCESSO AND
            HR2.NUM_PROCESSO = PB.NUM_PROCESSO
WHERE PV.CD_FUNDACAO = @CD_FUNDACAO
  AND PV.CD_PLANO = @CD_PLANO
  AND PV.NUM_INSCRICAO = @NUM_INSCRICAO
  AND HR.DT_INIC_VALIDADE = (SELECT MAX(HR2.DT_INIC_VALIDADE)
                               FROM GB_HIST_RENDAS HR2 
                              WHERE HR2.CD_FUNDACAO  = PB.CD_FUNDACAO 
                                AND    HR2.CD_EMPRESA   = PB.CD_EMPRESA 
                                AND    HR2.CD_PLANO     = PB.CD_PLANO 
                                AND    HR2.CD_ESPECIE   = PB.CD_ESPECIE 
                                AND    HR2.ANO_PROCESSO = PB.ANO_PROCESSO 
                                AND    HR2.NUM_PROCESSO = PB.NUM_PROCESSO)
  AND HR2.DT_INIC_VALIDADE = (SELECT MIN(HR2.DT_INIC_VALIDADE)
                               FROM GB_HIST_RENDAS HR2 
                              WHERE HR2.CD_FUNDACAO  = PB.CD_FUNDACAO 
                                AND    HR2.CD_EMPRESA   = PB.CD_EMPRESA 
                                AND    HR2.CD_PLANO     = PB.CD_PLANO 
                                AND    HR2.CD_ESPECIE   = PB.CD_ESPECIE 
                                AND    HR2.ANO_PROCESSO = PB.ANO_PROCESSO 
                                AND    HR2.NUM_PROCESSO = PB.NUM_PROCESSO)