/*Config
    RetornaLista
    Retorno
        -ReservaMatematicaEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_PLANO:string
*/

SELECT CD_FUNDACAO,
       NUM_INSCRICAO,
       CD_PLANO,
       MES_REF,
       ANO_REF,
       SEQ_CONTRIBUICAO,
       VL_RESERVA,
       CT_RP_RESERVA,
       CT_FD_RESERVA,
       CT_RM_RESERVA
FROM   CC_RESERVA_MATEMATICA
WHERE  CD_FUNDACAO = @CD_FUNDACAO
       AND NUM_INSCRICAO = @NUM_INSCRICAO
       AND CD_PLANO = @CD_PLANO
       AND ANO_REF = (SELECT MAX(ANO_REF) AS ANO_REF_AUX
                      FROM   CC_RESERVA_MATEMATICA
                      WHERE  CD_FUNDACAO = @CD_FUNDACAO
                             AND NUM_INSCRICAO = @NUM_INSCRICAO
                             AND CD_PLANO = @CD_PLANO) 