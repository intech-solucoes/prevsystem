/*Config
    RetornaLista
    Retorno
        -PlanoSaudeEntidade
    Parametros
        -NUM_MATRICULA:string
*/

SELECT *
FROM TB_DIRF_PSAUDE
WHERE NUM_MATRICULA = @NUM_MATRICULA
ORDER BY ANO_CALENDARIO DESC