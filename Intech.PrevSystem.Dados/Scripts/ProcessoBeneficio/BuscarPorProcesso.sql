/*Config
    Retorno
        -ProcessoBeneficioEntidade
    Parametros
        -SQ_PROCESSO:int
*/

SELECT PB.*,
       EB.DS_ESPECIE,
       MT.DS_MOT_SITUACAO
FROM fi_processo_beneficio PB
     INNER JOIN fi_especie_beneficio EB ON EB.SQ_ESPECIE = PB.SQ_ESPECIE
     INNER JOIN fi_mot_sit_processo MT ON MT.SQ_MOT_SITUACAO = PB.SQ_MOT_SITUACAO
WHERE PB.SQ_PROCESSO = @SQ_PROCESSO