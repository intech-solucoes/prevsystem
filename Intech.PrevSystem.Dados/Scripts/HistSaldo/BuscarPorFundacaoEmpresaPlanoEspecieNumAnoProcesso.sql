/*Config
    RetornaLista
    Retorno
        -HistSaldoEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
        -CD_ESPECIE:string
        -NUM_PROCESSO:decimal
        -ANO_PROCESSO:string
*/

SELECT *
FROM GB_HIST_SALDO
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO
  AND CD_ESPECIE = @CD_ESPECIE
  AND NUM_PROCESSO = @NUM_PROCESSO
  AND ANO_PROCESSO = @ANO_PROCESSO
ORDER BY DT_REFERENCIA DESC