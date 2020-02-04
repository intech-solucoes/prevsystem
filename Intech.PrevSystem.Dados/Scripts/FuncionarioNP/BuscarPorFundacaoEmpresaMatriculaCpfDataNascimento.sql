/*Config
    Retorno
        -FuncionarioNPEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
        -CPF_CGC:string
        -DT_NASCIMENTO:DateTime
*/

SELECT *
FROM CS_FUNCIONARIO_NP
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND NUM_MATRICULA = @NUM_MATRICULA
  AND CPF_CGC = @CPF_CGC
  AND DT_NASCIMENTO = @DT_NASCIMENTO