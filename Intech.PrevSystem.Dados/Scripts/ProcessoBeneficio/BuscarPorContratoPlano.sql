/*Config
    Retorno
        -ProcessoBeneficioEntidade
    Parametros
        -SQ_CONTRATO_TRABALHO:int
        -SQ_PLANO_PREVIDENCIAL:int
*/

SELECT PB.*,
       EB.DS_ESPECIE,
       MT.DS_MOT_SITUACAO
FROM fi_processo_beneficio PB
     INNER JOIN fi_especie_beneficio EB ON EB.SQ_ESPECIE = PB.SQ_ESPECIE
     INNER JOIN fi_mot_sit_processo MT ON MT.SQ_MOT_SITUACAO = PB.SQ_MOT_SITUACAO
WHERE PB.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL
  AND PB.SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO