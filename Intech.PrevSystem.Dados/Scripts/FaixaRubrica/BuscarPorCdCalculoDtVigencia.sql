/*Config
    RetornaLista
    Retorno
        -FaixaRubricaEntidade
    Parametros
        -CD_CALCULO:decimal
        -DT_VIGENCIA:DateTime
*/

SELECT *
  FROM GB_FAIXA_RUBRICA
 WHERE ( CD_CALCULO = @CD_CALCULO )
   AND ( DT_VIGENCIA <= @DT_VIGENCIA )