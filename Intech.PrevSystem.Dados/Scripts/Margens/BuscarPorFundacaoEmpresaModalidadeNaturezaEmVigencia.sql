/*Config
    Retorno
        -MargensEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_MODAL:decimal
        -CD_NATUR:decimal
        -DT_VIGENCIA:DateTime
*/

SELECT TOP 1 *
FROM CE_MARGENS
WHERE (CD_FUNDACAO = @CD_FUNDACAO)
  AND (CD_MODAL = @CD_MODAL)
  AND (CD_NATUR = @CD_NATUR)
  AND (CD_EMPRESA = @CD_EMPRESA)
  AND (DT_VIGENCIA <= @DT_VIGENCIA)
ORDER BY DT_VIGENCIA DESC