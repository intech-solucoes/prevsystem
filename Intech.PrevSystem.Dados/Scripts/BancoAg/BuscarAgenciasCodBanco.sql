/*Config
    RetornaLista
    Retorno
        -BancoAgEntidade
    Parametros
        -COD_BANCO:string
*/

SELECT *
FROM  TB_BANCO_AG
WHERE COD_BANCO = @COD_BANCO
  AND COD_AGENC <> '00000'
