/*Config
    RetornaLista
    Retorno
        -RubricaEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -MARGEM_CONSIG:string
*/

SELECT *
FROM TB_RUBRICA
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND MARGEM_CONSIG = @MARGEM_CONSIG