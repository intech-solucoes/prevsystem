/*Config
    RetornaLista
    Retorno
        -AdesaoPCSEntidade
    Parametros
        -NUM_INSCRICAO:string
*/

SELECT * 
FROM CS_ADESAO_PCS 
WHERE NUM_INSCRICAO = @NUM_INSCRICAO
ORDER BY DT_INICIO DESC