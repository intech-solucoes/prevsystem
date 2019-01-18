/*Config
    RetornaLista
    Retorno
        -CadastroRubricasEntidade
    Parametros
        -CD_FUNDACAO:string
        -NUM_INSCRICAO:string
        -CD_EMPRESA:string
*/

SELECT *
FROM CC_CADASTRO_RUBRICAS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND NUM_INSCRICAO = @NUM_INSCRICAO
  AND CD_EMPRESA = @CD_EMPRESA