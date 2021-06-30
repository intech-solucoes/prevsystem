/*Config
    RetornaLista
    Retorno
        -RegraCalcFundacaoEntidade
    Parametros
        -CD_PLANO:string
        -CD_ESPECIE:string
*/

SELECT * 
FROM GB_REGRA_CALC_FUNDACAO 
WHERE (CD_PLANO = @CD_PLANO) 
  AND (CD_ESPECIE = @CD_ESPECIE)
