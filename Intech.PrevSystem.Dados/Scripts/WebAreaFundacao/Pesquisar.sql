/*Config
    RetornaLista
    Retorno
        -WebAreaFundacaoEntidade
    Parametros
        -DES_AREA_FUNDACAO:string
*/

SELECT *
FROM WEB_AREA_FUNDACAO
WHERE (DES_AREA_FUNDACAO LIKE '%' +@DES_AREA_FUNDACAO + '%' OR @DES_AREA_FUNDACAO IS NULL)
ORDER BY OID_AREA_FUNDACAO