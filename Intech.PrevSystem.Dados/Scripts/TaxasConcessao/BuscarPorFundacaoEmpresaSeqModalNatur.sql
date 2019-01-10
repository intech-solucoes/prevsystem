/*Config
    RetornaLista
    Retorno
        -TaxasConcessaoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -SEQUENCIA:decimal
        -CD_MODAL:decimal
        -CD_NATUR:decimal
*/

SELECT *
FROM CE_TAXAS_CONCESSAO
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND SEQUENCIA = @SEQUENCIA
  AND CD_MODAL = @CD_MODAL
  AND CD_NATUR = @CD_NATUR