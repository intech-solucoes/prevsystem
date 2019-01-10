/*Config
    RetornaLista
    Retorno
        -RubricasPrevidencialEntidade
    Parametros
        -INCID_LIQUIDO:string
        -INCID_MARGEM_CONSIG:string
*/

SELECT *
FROM GB_RUBRICAS_PREVIDENCIAL
WHERE INCID_LIQUIDO = @INCID_LIQUIDO
  AND INCID_MARGEM_CONSIG = @INCID_MARGEM_CONSIG