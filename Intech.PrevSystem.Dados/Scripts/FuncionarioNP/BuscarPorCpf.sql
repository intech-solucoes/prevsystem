/*Config
    RetornaLista
    Retorno
        -FuncionarioNPEntidade
    Parametros
        -CPF_CGC:string
*/

SELECT *
FROM CS_FUNCIONARIO_NP
WHERE CPF_CGC = @CPF_CGC