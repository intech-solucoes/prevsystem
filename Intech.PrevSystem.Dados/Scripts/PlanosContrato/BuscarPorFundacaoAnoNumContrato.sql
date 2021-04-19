﻿/*Config
    RetornaLista
    Retorno
        -PlanosContratoEntidade
    Parametros
        -CD_FUNDACAO:string
        -ANO_CONTRATO:decimal
        -NUM_CONTRATO:decimal
*/

SELECT CE_PLANOS_CONTRATO.*, 
    TB_PLANOS.DS_PLANO
FROM CE_PLANOS_CONTRATO
INNER JOIN TB_PLANOS ON TB_PLANOS.CD_PLANO = CE_PLANOS_CONTRATO.CD_PLANO
 WHERE CE_PLANOS_CONTRATO.CD_FUNDACAO = @CD_FUNDACAO
   AND CE_PLANOS_CONTRATO.ANO_CONTRATO = @ANO_CONTRATO 
   AND CE_PLANOS_CONTRATO.NUM_CONTRATO = @NUM_CONTRATO
ORDER BY CE_PLANOS_CONTRATO.DATA_INSCRICAO DESC