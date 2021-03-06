﻿/*Config
    RetornaLista
    Retorno
        -FichaFinanceiraAssistidoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -SEQ_RECEBEDOR:int
        -CD_PLANO:string
        -DT_COMPETENCIA:DateTime
        -CD_TIPO_FOLHA:string
*/

SELECT GB_FICHA_FINANC_ASSISTIDO.*,
       GB_RUBRICAS_PREVIDENCIAL.DS_RUBRICA,
       GB_RUBRICAS_PREVIDENCIAL.RUBRICA_PROV_DESC,
       GB_RUBRICAS_PREVIDENCIAL.ID_RUB_SUPLEMENTACAO,
       GB_ESPECIE_BENEFICIO.DS_ESPECIE
FROM GB_FICHA_FINANC_ASSISTIDO
INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR
INNER JOIN GB_RUBRICAS_PREVIDENCIAL ON GB_RUBRICAS_PREVIDENCIAL.CD_RUBRICA = GB_FICHA_FINANC_ASSISTIDO.CD_RUBRICA
INNER JOIN GB_ESPECIE_BENEFICIO ON GB_ESPECIE_BENEFICIO.CD_ESPECIE = GB_FICHA_FINANC_ASSISTIDO.CD_ESPECIE 
WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO
  AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO
  AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA
  AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = @SEQ_RECEBEDOR
  AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA
  AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO
  AND GB_RECEBEDOR_BENEFICIO.NUM_MATRICULA = @NUM_MATRICULA
  AND GB_RUBRICAS_PREVIDENCIAL.EMITE_FOLHA = 'S'
  AND GB_RUBRICAS_PREVIDENCIAL.INCID_LIQUIDO = 'S'
  AND GB_FICHA_FINANC_ASSISTIDO.DT_COMPETENCIA = @DT_COMPETENCIA
  AND GB_FICHA_FINANC_ASSISTIDO.CD_TIPO_FOLHA = @CD_TIPO_FOLHA