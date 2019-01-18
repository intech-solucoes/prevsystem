/*Config
    RetornaLista
    Retorno
        -RubricasAdicionaisEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
*/

SELECT *
FROM CE_RUBRICAS_ADCIONAIS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND NUM_MATRICULA = @NUM_MATRICULA