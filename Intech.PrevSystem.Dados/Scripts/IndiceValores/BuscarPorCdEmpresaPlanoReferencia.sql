/*Config
    RetornaLista
    Retorno
        -IndiceValoresEntidade
    Parametros
        -CD_EMPRESA:string
		-CD_PLANO:string
		-DT_REFERENCIA:string
*/

SELECT *
  FROM TB_IND_VALORES IV
 WHERE IV.COD_IND = (SELECT IND_RESERVA_POUP 
                       FROM TB_EMPRESA_PLANOS 
                      WHERE CD_EMPRESA = @CD_EMPRESA
                        AND CD_PLANO = @CD_PLANO)
  AND IV.DT_IND >= @DT_REFERENCIA
ORDER BY DT_IND