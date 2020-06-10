/*Config
    Retorno
        -int
    Parametros
        -CPF_CGC:string
*/

SELECT COUNT(*)
FROM EE_ENTIDADE
WHERE CPF_CGC = @CPF_CGC