/*Config
    RetornaLista
    Retorno
        -LGPDConsentimentoEntidade
    Parametros
        -CPF:string
		-TXT_ORIGEM:string
		-DataExpiracao:DateTime
*/

SELECT *
FROM WEB_LGPD_CONSENTIMENTO
WHERE COD_CPF = @CPF AND TXT_ORIGEM = @TXT_ORIGEM AND DTA_CONSENTIMENTO >= @DataExpiracao