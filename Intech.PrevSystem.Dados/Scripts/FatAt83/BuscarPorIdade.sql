/*Config
    RetornaLista
    Retorno
        -FatAt83Entidade
    Parametros
        -IDADE_APOSENTADORIA:int
*/

SELECT *
FROM GB_FAT_AT83
WHERE IDADE >= @IDADE_APOSENTADORIA
ORDER BY IDADE