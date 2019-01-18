/*Config
    Retorno
        -MargensPlanoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_MODAL:decimal
        -CD_NATUR:decimal
        -DT_VIGENCIA:DateTime
*/

SELECT TOP 1 *
FROM CE_MARGENS_PLANO
WHERE (CD_FUNDACAO = @CD_FUNDACAO)
  AND (CD_EMPRESA = @CD_EMPRESA)
  AND (CD_PLANO = @CD_PLANO)
  AND (CD_MODAL = @CD_MODAL)
  AND (CD_NATUR = @CD_NATUR)
  AND (DT_VIGENCIA <= @DT_VIGENCIA)
ORDER BY DT_VIGENCIA DESC