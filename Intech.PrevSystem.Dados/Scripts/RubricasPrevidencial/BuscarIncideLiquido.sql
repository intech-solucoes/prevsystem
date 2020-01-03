/*Config
    RetornaLista
    Retorno
        -RubricasPrevidencialEntidade
    Parametros
        -INCID_LIQUIDO:string
*/

SELECT *
FROM GB_RUBRICAS_PREVIDENCIAL
WHERE INCID_LIQUIDO = @INCID_LIQUIDO