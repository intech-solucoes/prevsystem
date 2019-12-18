/*Config
    RetornaLista
    Retorno
        -IndiceValoresEntidade
    Parametros
        -CD_PLANO:string
*/

SELECT *
FROM TB_IND_VALORES
WHERE COD_IND = (SELECT DISTINCT IND_RESERVA_POUP 
                   FROM TB_EMPRESA_PLANOS
                   WHERE CD_PLANO = @CD_PLANO)
  AND DT_IND = (SELECT MAX(IV2.DT_IND) 
                  FROM TB_IND_VALORES IV2
                  WHERE IV2.COD_IND = TB_IND_VALORES.COD_IND)
