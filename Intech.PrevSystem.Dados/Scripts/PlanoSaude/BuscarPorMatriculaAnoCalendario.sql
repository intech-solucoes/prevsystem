/*Config
    RetornaLista
    Retorno
        -PlanoSaudeEntidade
    Parametros
        -NUM_MATRICULA:string
        -ANO_CALENDARIO:decimal
*/

SELECT *
FROM TB_DIRF_PSAUDE
WHERE NUM_MATRICULA = @NUM_MATRICULA
  AND ANO_CALENDARIO = @ANO_CALENDARIO