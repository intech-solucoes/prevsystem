/*Config
    Retorno
        -FuncionarioNPEntidade
    Parametros
        -CD_FUNDACAO:string
        -CPF_CGC:string
*/

SELECT *
FROM CS_FUNCIONARIO_NP
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CPF_CGC = @CPF_CGC