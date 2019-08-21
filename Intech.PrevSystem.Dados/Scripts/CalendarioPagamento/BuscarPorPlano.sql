/*Config
    RetornaLista
    Retorno
        -CalendarioPagamentoEntidade
    Parametros
        -CD_PLANO:string
*/

SELECT *
FROM WEB_CALENDARIO_PGT
WHERE CD_PLANO = @CD_PLANO