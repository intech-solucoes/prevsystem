/*Config
    RetornaLista
    Retorno
        -GrupoNaturezaEntidade
    Parametros
        -CD_MODAL:string
*/

SELECT *
FROM CE_GRUPO_NATUREZA
WHERE CD_MODAL = @CD_MODAL