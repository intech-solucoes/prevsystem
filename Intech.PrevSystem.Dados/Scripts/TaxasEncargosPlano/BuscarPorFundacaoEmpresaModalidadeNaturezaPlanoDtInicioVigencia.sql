/*Config
    RetornaLista
    Retorno
        -TaxasEncargosPlanoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_MODAL:decimal
        -CD_NATUR:decimal
        -CD_PLANO:string
        -DT_INIC_VIGENCIA:DateTime
*/

SELECT *
FROM CE_TAXAS_ENCARGOS_PLANO
WHERE (CD_FUNDACAO = @CD_FUNDACAO)
  AND (CD_EMPRESA = @CD_EMPRESA)
  AND (CD_MODAL = @CD_MODAL)
  AND (CD_NATUR = @CD_NATUR)
  AND (CD_PLANO = @CD_PLANO)
  AND (DT_INIC_VIGENCIA <= @DT_INIC_VIGENCIA)
  AND (DT_TERM_VIGENCIA IS NULL OR DT_TERM_VIGENCIA = '')
ORDER BY DT_INIC_VIGENCIA DESC