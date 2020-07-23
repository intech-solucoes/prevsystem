/*Config
    Retorno
        -MargensEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
*/

SELECT TOP 1 *
FROM CE_MARGENS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND DT_VIGENCIA = (SELECT MAX(MAR.DT_VIGENCIA)
                       FROM CE_MARGENS MAR
                       WHERE MAR.CD_FUNDACAO = CE_MARGENS.CD_FUNDACAO
                         AND MAR.CD_EMPRESA = CE_MARGENS.CD_EMPRESA
                         AND MAR.CD_MODAL = CE_MARGENS.CD_MODAL
                         AND MAR.CD_NATUR = CE_MARGENS.CD_NATUR)
  AND TETO_MAXIMO_ATIVO IS NOT NULL