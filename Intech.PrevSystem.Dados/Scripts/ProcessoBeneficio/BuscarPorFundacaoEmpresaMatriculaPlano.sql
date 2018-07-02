﻿/*Config
    Retorno
        -ProcessoBeneficioEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -CD_PLANO:string
*/

SELECT GB_PROCESSOS_BENEFICIO.*,
       GB_ESPECIE_BENEFICIO.DS_ESPECIE, 
	   GB_SITUACAO.DS_SITUACAO,
       GB_HIST_PROCESSOS.DT_REQUERIMENTO, 
       GB_HIST_PROCESSOS.DT_AFASTAMENTO, 
       GB_HIST_PROCESSOS.DT_INICIO_PREV, 
       GB_HIST_PROCESSOS.DT_INICIO_FUND 
FROM   GB_PROCESSOS_BENEFICIO 
INNER JOIN GB_ESPECIE_BENEFICIO ON GB_ESPECIE_BENEFICIO.CD_ESPECIE = GB_PROCESSOS_BENEFICIO.CD_ESPECIE 
INNER JOIN GB_SITUACAO ON GB_SITUACAO.CD_SITUACAO = GB_PROCESSOS_BENEFICIO.CD_SITUACAO
INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = GB_PROCESSOS_BENEFICIO.NUM_INSCRICAO 
LEFT OUTER JOIN GB_HIST_PROCESSOS ON GB_PROCESSOS_BENEFICIO.CD_FUNDACAO = GB_HIST_PROCESSOS.CD_FUNDACAO 
    AND GB_PROCESSOS_BENEFICIO.CD_EMPRESA = GB_HIST_PROCESSOS.CD_EMPRESA 
    AND GB_PROCESSOS_BENEFICIO.CD_PLANO = GB_HIST_PROCESSOS.CD_PLANO 
    AND GB_PROCESSOS_BENEFICIO.CD_ESPECIE = GB_HIST_PROCESSOS.CD_ESPECIE 
    AND GB_PROCESSOS_BENEFICIO.NUM_PROCESSO = GB_HIST_PROCESSOS.NUM_PROCESSO 
    AND GB_PROCESSOS_BENEFICIO.ANO_PROCESSO = GB_HIST_PROCESSOS.ANO_PROCESSO 
WHERE  CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO
   AND GB_PROCESSOS_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO
   AND CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA
   AND GB_PROCESSOS_BENEFICIO.CD_EMPRESA = @CD_EMPRESA
   AND CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA
   AND GB_PROCESSOS_BENEFICIO.CD_PLANO = @CD_PLANO