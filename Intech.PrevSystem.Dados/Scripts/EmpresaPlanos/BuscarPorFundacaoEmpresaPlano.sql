/*Config
    Retorno
        -EmpresaPlanosEntidade
    Parametros
        -CD_FUNDACAO:string
        -CD_EMPRESA:string
        -CD_PLANO:string
*/

SELECT * 
FROM TB_EMPRESA_PLANOS
WHERE CD_FUNDACAO = @CD_FUNDACAO
  AND CD_EMPRESA = @CD_EMPRESA
  AND CD_PLANO = @CD_PLANO