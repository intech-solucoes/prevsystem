/*Config
    RetornaLista
    Retorno
        -PrazosDisponiveisEntidade
    Parametros
        -CD_NATUR:decimal
        -PRAZO:decimal
*/

SELECT *
FROM CE_PRAZOS_DISPONIVEIS
WHERE CD_NATUR = @CD_NATUR
  AND PRAZO = @PRAZO