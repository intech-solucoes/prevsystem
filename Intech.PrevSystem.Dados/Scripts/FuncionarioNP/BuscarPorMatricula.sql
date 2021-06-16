/*Config
    RetornaLista
    Retorno
        -FuncionarioNPEntidade
    Parametros
        -NUM_MATRICULA:string
*/

SELECT *
FROM CS_FUNCIONARIO_NP
WHERE NUM_MATRICULA = @NUM_MATRICULA