/*Config
    RetornaLista
    Retorno
        -TaxasSegurosTabeladosEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -PRAZO:decimal
        -DATA_CREDITO:DateTime
        -IDADE:int
*/

SELECT *
FROM  CE_TAXAS_SEGUROS_TABELADOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND DT_VIGENCIA = (SELECT MAX(DT_VIGENCIA)
                      FROM   CE_TAXAS_SEGUROS_TABELADOS
                      WHERE  CD_FUNDACAO = @CD_FUNDACAO
                              AND CD_EMPRESA = @CD_EMPRESA
                              AND PRAZO = @PRAZO
                              AND DT_VIGENCIA <= @DATA_CREDITO)
  AND ( IDADE = @IDADE OR @IDADE IS NULL )
  AND PRAZO = @PRAZO 