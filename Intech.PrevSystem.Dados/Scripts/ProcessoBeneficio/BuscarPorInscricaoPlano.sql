﻿/*Config
    RetornaLista
    Retorno
        -ProcessoBeneficioEntidade
    Parametros
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT PB.*,
       EB.DS_ESPECIE,
       HP.DT_INICIO_FUND,
	   ST.DS_SITUACAO,
	   HR.VL_PARCELA_MENSAL,
	   OP.DS_OPCAO_RECEB,
       HR.OPCAO_RECB_13
FROM GB_PROCESSOS_BENEFICIO PB
	 INNER JOIN GB_HIST_RENDAS HR ON
			PB.CD_FUNDACAO  = HR.CD_FUNDACAO AND
			PB.CD_EMPRESA   = HR.CD_EMPRESA AND
			PB.CD_PLANO     = HR.CD_PLANO AND
			PB.CD_ESPECIE   = HR.CD_ESPECIE AND
			PB.NUM_PROCESSO = HR.NUM_PROCESSO AND 
			PB.ANO_PROCESSO = HR.ANO_PROCESSO AND 
			PB.VERSAO       = HR.VERSAO
	 INNER JOIN GB_HIST_PROCESSOS HP ON
			PB.CD_FUNDACAO  = HP.CD_FUNDACAO AND
			PB.CD_EMPRESA   = HP.CD_EMPRESA AND
			PB.CD_PLANO     = HP.CD_PLANO AND
			PB.CD_ESPECIE   = HP.CD_ESPECIE AND
			PB.NUM_PROCESSO = HP.NUM_PROCESSO AND 
			PB.ANO_PROCESSO = HP.ANO_PROCESSO AND
			PB.VERSAO       = HP.VERSAO
	 INNER JOIN GB_HIST_SALDO HS ON
			PB.CD_FUNDACAO  = HS.CD_FUNDACAO AND
			PB.CD_EMPRESA   = HS.CD_EMPRESA AND
			PB.CD_PLANO     = HS.CD_PLANO AND
			PB.CD_ESPECIE   = HS.CD_ESPECIE AND
			PB.NUM_PROCESSO = HS.NUM_PROCESSO AND 
			PB.ANO_PROCESSO = HS.ANO_PROCESSO AND
			PB.VERSAO       = HS.VERSAO
	 INNER JOIN GB_ESPECIE_BENEFICIO EB ON
			EB.CD_ESPECIE = PB.CD_ESPECIE
	 INNER JOIN GB_SITUACAO ST ON
			ST.CD_SITUACAO = PB.CD_SITUACAO
	 INNER JOIN GB_OPCAO_RECEBIMENTO OP ON
	        OP.CD_OPCAO_RECEB = HR.CD_OPCAO_RECEB
WHERE HR.DT_INIC_VALIDADE = (SELECT MAX(HR2.DT_INIC_VALIDADE)
                               FROM GB_HIST_RENDAS HR2
                              WHERE HR2.CD_FUNDACAO  = HR.CD_FUNDACAO AND
			                        HR2.CD_EMPRESA   = HR.CD_EMPRESA AND
                         			HR2.CD_PLANO     = HR.CD_PLANO AND
			                        HR2.CD_ESPECIE   = HR.CD_ESPECIE AND
			                        HR2.NUM_PROCESSO = HR.NUM_PROCESSO AND 
									HR2.ANO_PROCESSO = HR.ANO_PROCESSO AND
			                        HR2.VERSAO       = HR.VERSAO)
	 AND HS.DT_REFERENCIA = (SELECT MAX(HS2.DT_REFERENCIA)
                            FROM GB_HIST_SALDO HS2
                           WHERE HS2.CD_FUNDACAO  = HR.CD_FUNDACAO AND
			                     HS2.CD_EMPRESA   = HR.CD_EMPRESA AND
                         		 HS2.CD_PLANO     = HR.CD_PLANO AND
			                     HS2.CD_ESPECIE   = HR.CD_ESPECIE AND
			                     HS2.NUM_PROCESSO = HR.NUM_PROCESSO AND 
								 HS2.ANO_PROCESSO = HR.ANO_PROCESSO AND
			                     HS2.VERSAO       = HR.VERSAO)
  AND PB.CD_PLANO = @CD_PLANO
  AND PB.NUM_INSCRICAO = @NUM_INSCRICAO