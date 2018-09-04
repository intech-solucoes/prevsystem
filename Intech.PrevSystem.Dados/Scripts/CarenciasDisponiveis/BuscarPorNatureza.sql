/*Config
    RetornaLista
    Retorno
        -CarenciasDisponiveisEntidade
    Parametros
        -CD_NATUR:decimal
*/

SELECT *
FROM CE_CARENCIAS_DISPONIVEIS
WHERE CD_NATUR = @CD_NATUR
  AND DISPONIVEL = 'S'