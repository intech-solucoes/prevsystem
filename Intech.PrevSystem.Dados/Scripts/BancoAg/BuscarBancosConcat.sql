/*Config
    RetornaLista
    Retorno
        -BancoAgEntidade
*/

SELECT COD_BANCO, ('' + COD_BANCO + ' - ' + DESC_BCO_AG) AS DESC_BCO_AG
FROM TB_BANCO_AG
WHERE COD_AGENC = '00000'
ORDER BY COD_BANCO