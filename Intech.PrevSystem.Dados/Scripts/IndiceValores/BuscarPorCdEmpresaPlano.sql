/*Config
    RetornaLista
    Retorno
        -IndiceValoresEntidade
    Parametros
        -CD_EMPRESA:string
		-CD_PLANO:string
*/

SELECT *
  FROM TB_IND_VALORES IV
 WHERE IV.COD_IND = (SELECT IND_RESERVA_POUP
                       FROM TB_EMPRESA_PLANOS
                      WHERE CD_EMPRESA = @CD_EMPRESA
                        AND CD_PLANO = @CD_PLANO)
ORDER BY DT_IND DESC