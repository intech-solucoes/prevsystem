/*Config
    Retorno
        -BancoAgEntidade
    Parametros
        -COD_BANCO:string
        -COD_AGENC:string
*/

SELECT *
FROM  TB_BANCO_AG
WHERE COD_BANCO = @COD_BANCO
  AND COD_AGENC = @COD_AGENC