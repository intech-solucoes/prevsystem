/*Config
    Retorno
        -SalarioBaseEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -NUM_MATRICULA:string
*/


SELECT TOP 1 * 
FROM CS_SALARIO_BASE
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND NUM_MATRICULA = @NUM_MATRICULA
ORDER BY DT_BASE DESC