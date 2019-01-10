/*Config
    RetornaLista
    Retorno
        -PrazosDisponiveisEntidade
    Parametros
        -CD_NATUR:decimal
*/

SELECT *
FROM CE_PRAZOS_DISPONIVEIS
WHERE CD_NATUR = @CD_NATUR