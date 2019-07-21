/*Config
    Retorno
        -LGPDConsentimentoEntidade
    Parametros
        -CPF:string
*/

SELECT *
FROM WEB_LGPD_CONSENTIMENTO
WHERE COD_CPF = @CPF