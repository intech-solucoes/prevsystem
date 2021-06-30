/*Config
    RetornaLista
    Retorno
        -RubricaEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_RUBRICA:string
*/

SELECT *
 FROM TB_RUBRICA
WHERE ( CD_FUNDACAO = @CD_FUNDACAO )
  AND ( CD_EMPRESA = @CD_EMPRESA )
  AND ( CD_RUBRICA = @CD_RUBRICA ) 